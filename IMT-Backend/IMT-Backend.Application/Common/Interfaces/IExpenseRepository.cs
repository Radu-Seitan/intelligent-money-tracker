using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IExpenseRepository
    {
        Task CreateExpense(Expense expense);
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<IEnumerable<Expense>> GetAllUserExpenses(string userId);
        Task<IEnumerable<Expense>> GetUserExpensesByCategory(string userId, ExpenseCategory category);
        Task<IEnumerable<Expense>> GetAllExpensesByCategory(ExpenseCategory expenseCategory);
        Task<IEnumerable<Expense>> GetAllStoreExpenses(int storeId);
        Task<IEnumerable<Expense>> GetStoreExpensesByCategory(int storeId, ExpenseCategory expenseCategory);
    }
}
