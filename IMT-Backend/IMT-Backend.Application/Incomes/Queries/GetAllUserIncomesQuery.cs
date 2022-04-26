using AutoMapper;
using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Incomes.Queries
{
    public class GetAllUserIncomesQuery : IRequest<IEnumerable<IncomeDto>>
    {
        public string UserId { get; set; }
    }
    public class GetUserTotalIncomeQueryHandler : IRequestHandler<GetAllUserIncomesQuery, IEnumerable<IncomeDto>>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        public GetUserTotalIncomeQueryHandler(IIncomeRepository incomeRepositorys, IMapper mapper)
        {
            _incomeRepository = incomeRepositorys;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IncomeDto>> Handle(GetAllUserIncomesQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _incomeRepository.GetAllUserIncomes(request.UserId);

            return _mapper.Map<IEnumerable<IncomeDto>>(incomes);
        }
    }
}
