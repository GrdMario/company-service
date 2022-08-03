namespace Company.Service.Application.Internal.Mappings
{
    using Company.Service.Application.ExampleAggregate.Common.Responses;
    using Company.Service.Blocks.Common.Mapping.Core;
    using Company.Service.Domain;

    internal sealed class ApplicationMappingProfile : MappingProfileBase
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Example, ExampleResponse>();
        }
    }
}
