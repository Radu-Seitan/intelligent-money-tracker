using IMT_Backend.Application.Common.Interfaces;
using MediatR;

namespace IMT_Backend.Application.Incomes.Queries
{
    public class GetUserTotalIncomeQuery : IRequest<double>
    {
        public string UserId { get; set; }
    }
    public class GetUserTotalIncomeQueryHandler : IRequestHandler<GetUserTotalIncomeQuery, double>
    {
        private readonly IIncomeRepository _incomeRepository;
        public GetUserTotalIncomeQueryHandler(IIncomeRepository incomeRepositorys)
        {
            _incomeRepository = incomeRepositorys;
        }
        public async Task<double> Handle(GetUserTotalIncomeQuery request, CancellationToken cancellationToken)
        {
            return await _incomeRepository.ComputeIncomes(request.UserId);
        }
    }
}
