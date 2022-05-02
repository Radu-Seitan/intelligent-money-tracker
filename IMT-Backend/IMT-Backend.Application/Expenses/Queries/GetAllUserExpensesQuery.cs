using AutoMapper;
using FluentValidation;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Expenses.Queries
{
    public class GetAllUserExpensesQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        public string UserId { get; set; }
    }

    public class GetAllUserExpensesQueryHandler : IRequestHandler<GetAllUserExpensesQuery,IEnumerable<ExpenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        public GetAllUserExpensesQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<IEnumerable<ExpenseDto>> Handle(GetAllUserExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllUserExpenses(request.UserId);

            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
    public class GetAllUserExpensesQueryValidator : AbstractValidator<GetAllUserExpensesQuery>
    {
        public GetAllUserExpensesQueryValidator()
        {
            RuleFor(e => e.UserId).NotNull();
        }
    }
}
