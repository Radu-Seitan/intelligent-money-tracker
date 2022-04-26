using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Incomes.Queries
{
    public class GetAllIncomesQuery : IRequest<IEnumerable<IncomeDto>>
    {
    }

    public class GetAllIncomesQueryHandler : IRequestHandler<GetAllIncomesQuery, IEnumerable<IncomeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIncomeRepository _incomeRepository;
        public GetAllIncomesQueryHandler(IMapper mapper, IIncomeRepository incomeRepository)
        {
            _mapper = mapper;
            _incomeRepository = incomeRepository;
        }

        public async Task<IEnumerable<IncomeDto>> Handle(GetAllIncomesQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _incomeRepository.GetAllIncomes();

            return _mapper.Map<IEnumerable<IncomeDto>>(incomes);
        }
    }
}
