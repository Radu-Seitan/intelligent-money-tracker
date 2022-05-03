using AutoMapper;
using FluentValidation;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Expenses.Queries
{
    public class GetStoreExpensesByCategoryQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        public int StoreId { get; set; }
        public ExpenseCategory Category { get; set; }
    }

    public class GetStoreExpensesByCategoryQueryHandler : IRequestHandler<GetStoreExpensesByCategoryQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        public GetStoreExpensesByCategoryQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<IEnumerable<ExpenseDto>> Handle(GetStoreExpensesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetStoreExpensesByCategory(request.StoreId, request.Category);

            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
    public class GetStoreExpensesByCategoryQueryValidator : AbstractValidator<GetStoreExpensesByCategoryQuery>
    {
        public GetStoreExpensesByCategoryQueryValidator()
        {
            RuleFor(e => e.StoreId).NotNull();
            RuleFor(e => e.Category).NotNull();
        }
    }
}
