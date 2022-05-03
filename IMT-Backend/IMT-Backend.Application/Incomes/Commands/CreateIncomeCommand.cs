using FluentValidation;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Incomes.Commands
{
    public class CreateIncomeCommand : IRequest<Unit>
    {
        public double Quantity { get; set; } 
        public IncomeCategory Category { get; set; }
        public string UserId { get; set; }
    }

    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, Unit>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUserRepository _userRepository;
        public CreateIncomeCommandHandler(IIncomeRepository incomeRepository, IUserRepository userRepository)
        {
            _incomeRepository = incomeRepository;
            _userRepository = userRepository;   
        }
        public async Task<Unit> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = new Income
            {
                Quantity = request.Quantity,
                Category = request.Category,
                UserId = request.UserId
            };

            await _incomeRepository.CreateIncome(income);
            await _userRepository.IncreaseSum(request.UserId, request.Quantity);
            return Unit.Value;
        }
        public class CreateIncomeCommandValidator : AbstractValidator<CreateIncomeCommand>
        {
            public CreateIncomeCommandValidator()
            {
                RuleFor(i => i.Quantity)
                    .NotNull();
                RuleFor(i => i.Category)
                    .NotNull();
                RuleFor(i => i.UserId)
                    .NotNull();
            }
        }
    }
}
