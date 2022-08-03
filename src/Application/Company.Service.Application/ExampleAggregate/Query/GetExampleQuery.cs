namespace Company.Service.Application.ExampleAggregate.Query
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Company.Service.Application.Contracts.Http;
    using Company.Service.Application.ExampleAggregate.Common.Responses;
    using Company.Service.Domain;
    using System.Threading;
    using System.Threading.Tasks;

    public record GetExampleQuery(Guid Id) : IRequest<ExampleResponse>;

    internal sealed class GetExampleQueryValidator : AbstractValidator<ExampleResponse>
    {
        public GetExampleQueryValidator()
        {
            // TODO: Add validation.
        }
    }

    internal sealed class GetExampleQueryHandler : IRequestHandler<GetExampleQuery, ExampleResponse>
    {
        private readonly IExampleAdapter _exampleAdapter;
        private readonly IMapper _mapper;

        public GetExampleQueryHandler(
            IExampleAdapter exampleAdapter,
            IMapper mapper)
        {
            _exampleAdapter = exampleAdapter;
            _mapper = mapper;
        }

        public async Task<ExampleResponse> Handle(GetExampleQuery request, CancellationToken cancellationToken)
        {
            Example example = await _exampleAdapter.GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<ExampleResponse>(example);
        }
    }
}
