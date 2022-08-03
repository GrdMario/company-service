namespace Company.Service.Application.ExampleAggregate.Command
{
    using Company.Service.Application.Contracts.Http;
    using Company.Service.Blocks.Application.Contracts;
    using Company.Service.Domain;
    using FluentValidation;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public record CreateExampleCommand(string Name) : IRequest;

    public class CreateExampleCommandValidator : AbstractValidator<CreateExampleCommand>
    {
        public CreateExampleCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }

    internal sealed class CreateExampleCommandHandler : AsyncRequestHandler<CreateExampleCommand>
    {
        private readonly IExampleAdapter _exampleAdapter;

        public CreateExampleCommandHandler(
            IExampleAdapter exampleAdapter)
        {
            _exampleAdapter = exampleAdapter;
        }

        protected override async Task Handle(CreateExampleCommand request, CancellationToken cancellationToken)
        {
            Example example = new(SystemGuid.NewGuid, request.Name);

            await _exampleAdapter.CreateAsync(example, cancellationToken);
        }
    }
}
