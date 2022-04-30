using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Expenses.Queries
{
    public class GetAllExpensesByCategoryQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        public ExpenseCategory Category { get; set; }   
    }

    public class GetAllExpensesByCategoryQueryHandler : IRequestHandler<GetAllExpensesByCategoryQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        public GetAllExpensesByCategoryQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<IEnumerable<ExpenseDto>> Handle(GetAllExpensesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllExpensesByCategory(request.Category);
            
            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
}
