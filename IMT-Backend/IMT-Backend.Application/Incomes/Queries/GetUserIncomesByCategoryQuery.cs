using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Incomes.Queries
{
    public class GetUserIncomesByCategoryQuery : IRequest<IEnumerable<IncomeDto>>
    {
        public string UserId { get; set; }
        public IncomeCategory Category { get; set; }
    }

    public class GetUserIncomesByCategoryQueryHandler : IRequestHandler<GetUserIncomesByCategoryQuery, IEnumerable<IncomeDto>>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        public GetUserIncomesByCategoryQueryHandler(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IncomeDto>> Handle(GetUserIncomesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _incomeRepository.GetUserIncomesByCategory(request.UserId, request.Category);

            return _mapper.Map<IEnumerable<IncomeDto>>(incomes);
        }
    }
}
