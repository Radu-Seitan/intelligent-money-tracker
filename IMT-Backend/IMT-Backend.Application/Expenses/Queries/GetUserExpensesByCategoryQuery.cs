using AutoMapper;
using FluentValidation;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Expenses.Queries
{
    public class GetUserExpensesByCategoryQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        public string UserId { get; set; }
        public ExpenseCategory Category { get; set; }
    }

    public class GetUserExpensesByCategoryQueryHandler : IRequestHandler<GetUserExpensesByCategoryQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;
        public GetUserExpensesByCategoryQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }
        public async Task<IEnumerable<ExpenseDto>> Handle(GetUserExpensesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetUserExpensesByCategory(request.UserId, request.Category);

            return _mapper.Map<IEnumerable<ExpenseDto>>(expenses);
        }
    }
    public class GetUserExpensesByCategoryQueryValidator : AbstractValidator<GetUserExpensesByCategoryQuery>
    {
        public GetUserExpensesByCategoryQueryValidator()
        {
            RuleFor(e => e.UserId).NotNull();
            RuleFor(e => e.Category).NotNull();
        }
    }
}
