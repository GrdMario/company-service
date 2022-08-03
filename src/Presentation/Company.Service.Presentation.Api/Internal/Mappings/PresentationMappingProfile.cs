namespace Company.Service.Presentation.Api.Internal.Mappings
{
    using Company.Service.Application.ExampleAggregate.Command;
    using Company.Service.Application.ExampleAggregate.Query;
    using Company.Service.Blocks.Common.Mapping.Core;
    using Company.Service.Presentation.Api.Controllers.V1.Models.Examples;

    internal sealed class PresentationMappingProfile : MappingProfileBase
    {
        public PresentationMappingProfile()
        {
            CreateMap<GetExampleQueryDto, GetExampleQuery>();
            CreateMap<GetExamplesQueryDto, GetExamplesQuery>();
            CreateMap<CreateExampleCommandDto, CreateExampleCommand>();
            CreateMap<UpdateExampleCommandDto, UpdateExampleCommand>();
        }
    }
}
