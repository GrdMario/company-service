namespace Company.Service.Infrastructure.ExampleAdapter
{
    using Microsoft.Extensions.DependencyInjection;
    using Company.Service.Application.Contracts.Http;
    using Company.Service.Infrastructure.ExampleAdapter.Internal;

    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureExampleAdapter(this IServiceCollection services, ExampleAdapterSettings settings)
        {
            services.AddScoped<IExampleAdapter, ExampleServiceAdapter>();

            return services;
        }
    }

    public class ExampleAdapterSettings
    {
        public const string Key = nameof(ExampleAdapterSettings);

        public string? Url { get; set; }
    }
}
