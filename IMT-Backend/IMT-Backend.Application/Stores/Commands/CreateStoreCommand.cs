using FluentValidation;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using MediatR;

namespace IMT_Backend.Application.Stores.Commands
{
    public class CreateStoreCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }

    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Unit>
    {
        private readonly IStoreRepository _storeRepository;
        public CreateStoreCommandHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<Unit> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store
            {
                Name = request.Name,
                Expenses = new List<Expense>()
            };

            await _storeRepository.CreateStore(store);
            return Unit.Value;
        }
    }

    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator()
        {
            RuleFor(s => s.Name)
                .MaximumLength(40)
                .NotNull();
        }
    }
}
