namespace Company.Service
{
    using Company.Service.Application;
    using Company.Service.Blocks.Common.Mapping.Configuration;
    using Company.Service.Blocks.Common.Serilog.Configuration;
    using Company.Service.Blocks.Common.Swagger.Configuration;
    using Company.Service.Blocks.Presentation.Api.Configuration;
    using Company.Service.Infrastructure.ExampleAdapter;
    using Company.Service.Presentation.Api;
    using Hellang.Middleware.ProblemDetails;

    public sealed class Startup
    {
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public ExampleAdapterSettings ExampleAdapterSettings =>
            Configuration
                .GetSection(ExampleAdapterSettings.Key)
                .Get<ExampleAdapterSettings>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddHealthChecks();
            services.AddInfrastructureExampleAdapter(ExampleAdapterSettings);
            services.AddApplicationLayer();
            services.AddPresentationLayer(Environment);
            services.AddAutoMapperConfiguration(AppDomain.CurrentDomain);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseProblemDetails();

            if (!Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSerilogConfiguration();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapDefaultHealthCheckRoute();
            });
        }
    }
}
