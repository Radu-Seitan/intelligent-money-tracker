using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Enums;
using MediatR;

namespace IMT_Backend.Application.Incomes.Queries
{
    public class GetAllIncomesByCategoryQuery : IRequest<IEnumerable<IncomeDto>>
    {
        public IncomeCategory Category { get; set; }
    }

    public class GetAllIncomesByCategoryQueryHandler : IRequestHandler<GetAllIncomesByCategoryQuery, IEnumerable<IncomeDto>>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        public GetAllIncomesByCategoryQueryHandler(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IncomeDto>> Handle(GetAllIncomesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _incomeRepository.GetAllIncomesByCategory(request.Category);

            return _mapper.Map<IEnumerable<IncomeDto>>(incomes);
        }
    }
}
