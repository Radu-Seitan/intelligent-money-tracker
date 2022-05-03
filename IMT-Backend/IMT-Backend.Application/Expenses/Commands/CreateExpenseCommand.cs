using FluentValidation;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Expenses.Commands
{
    public class CreateExpenseCommand : IRequest<Unit>
    {
        public double Quantity { get; set; }
        public ExpenseCategory Category { get; set; }
        public string UserId { get; set; }
        public int StoreId { get; set; }
    }

    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Unit>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;
        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                Quantity = request.Quantity,
                Category = request.Category,
                UserId = request.UserId,
                StoreId = request.StoreId
            };

            await _expenseRepository.CreateExpense(expense);
            await _userRepository.DecreaseSum(request.UserId,request.Quantity);
            return Unit.Value;
        }
    }
    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(e => e.Quantity)
                .NotNull();
            RuleFor(e => e.Category)
                .NotNull();
            RuleFor(e => e.UserId)
                .NotNull();
            RuleFor(e => e.StoreId)
                .NotNull();
        }
    }
}
