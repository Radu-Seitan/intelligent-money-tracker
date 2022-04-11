using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IIncomeRepository
    {
        Task CreateIncome(Income income);
        Task<double> ComputeIncomes(string userId);
    }
}
