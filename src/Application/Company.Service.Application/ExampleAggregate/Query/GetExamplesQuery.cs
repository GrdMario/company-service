namespace Company.Service.Application.ExampleAggregate.Query
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Company.Service.Application.Contracts.Http;
    using Company.Service.Application.ExampleAggregate.Common.Responses;
    using Company.Service.Domain;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetExamplesQuery: IRequest<List<ExampleResponse>>
    {
        public string? Name { get; set; }

        public int? Page { get; set; }

        public int? Size { get; set; }
    }

    internal sealed class GetExamplesQueryValidator : AbstractValidator<GetExamplesQuery>
    {
        public GetExamplesQueryValidator()
        {
        }
    }

    internal sealed class GetExamplesQueryHandler : IRequestHandler<GetExamplesQuery, List<ExampleResponse>>
    {
        private readonly IExampleAdapter _exampleAdapter;
        private readonly IMapper _mapper;

        public GetExamplesQueryHandler(
            IExampleAdapter exampleAdapter,
            IMapper mapper)
        {
            _exampleAdapter = exampleAdapter;
            _mapper = mapper;
        }

        public async Task<List<ExampleResponse>> Handle(GetExamplesQuery request, CancellationToken cancellationToken)
        {
            List<Example> examples = await _exampleAdapter.GetAsync(cancellationToken);

            return _mapper.Map<List<ExampleResponse>>(examples);
        }
    }
}
