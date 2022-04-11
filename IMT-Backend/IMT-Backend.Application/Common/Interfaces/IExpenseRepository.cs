using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IExpenseRepository
    {
        Task CreateExpense(Expense expense);
        Task<double> ComputeExpensesForUser(string userId);
        Task<double> ComputeExpensesForStore(int storeId);
    }
}
