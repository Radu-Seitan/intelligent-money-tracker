using AutoMapper;
using FluentValidation;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Expenses.Queries
{
    public class GetAllStoreExpensesQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        public int StoreId { get; set; }
    }

    public class GetAllStoreExpensesQueryHandler : IRequestHandler<GetAllStoreExpensesQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        public GetAllStoreExpensesQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<IEnumerable<ExpenseDto>> Handle(GetAllStoreExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllStoreExpenses(request.StoreId);

            return  _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
    public class GetAllStoreExpensesQueryValidator : AbstractValidator<GetAllStoreExpensesQuery>
    {
        public GetAllStoreExpensesQueryValidator()
        {
            RuleFor(e => e.StoreId).NotNull();
        }
    }
}
