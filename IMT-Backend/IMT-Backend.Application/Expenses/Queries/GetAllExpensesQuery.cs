using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Expenses.Queries
{
    public class GetAllExpensesQuery : IRequest<IEnumerable<ExpenseDto>>
    {
    }

    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        public GetAllExpensesQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;      
        }
        public async Task<IEnumerable<ExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllExpenses();

            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
}
