namespace Company.Service.Presentation.Api.Internal.Examples.V1.Example
{
    using Company.Service.Presentation.Api.Controllers.V1.Models.Examples;
    using Swashbuckle.AspNetCore.Filters;

    internal sealed class UpdateExampleCommandDtoExample : IExamplesProvider<UpdateExampleCommandDto>
    {
        public UpdateExampleCommandDto GetExamples()
        {
            return new("My Name");
        }
    }
}
