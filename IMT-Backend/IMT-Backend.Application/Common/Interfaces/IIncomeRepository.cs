using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IIncomeRepository
    {
        Task CreateIncome(Income income);
        Task<double> ComputeIncomes(string userId);
        Task<IEnumerable<Income>> GetUserIncomesByCategory(string userId, IncomeCategory incomeCategory);
        Task<IEnumerable<Income>> GetAllIncomesByCategory(IncomeCategory incomeCategory);
    }
}
