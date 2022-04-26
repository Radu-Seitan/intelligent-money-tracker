using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;
using IMT_Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMT_Backend.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExpenseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await _appDbContext.Expenses.ToListAsync();
        }
        public async Task CreateExpense(Expense expense)
        {
            await _appDbContext.Expenses.AddAsync(expense);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Expense>> GetAllUserExpenses(string userId)
        {
            var expenses = await _appDbContext.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync();
            return expenses;
        }
        public async Task<IEnumerable<Expense>> GetAllStoreExpenses(int storeId)
        {
            var expenses = await _appDbContext.Expenses
                .Where(e => e.StoreId == storeId)
                .ToListAsync();
            return expenses;
        }
        public async Task<IEnumerable<Expense>> GetUserExpensesByCategory(string userId, ExpenseCategory expenseCategory)
        {
            var expenses = await _appDbContext.Expenses
               .Where(i => i.UserId == userId && i.Category == expenseCategory)
               .ToListAsync();

            return expenses;
        }
        public async Task<IEnumerable<Expense>> GetAllExpensesByCategory(ExpenseCategory expenseCategory)
        {
            var expenses = await _appDbContext.Expenses
                .Where(e => e.Category == expenseCategory)
                .ToListAsync();

            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetStoreExpensesByCategory(int storeId, ExpenseCategory expenseCategory)
        {
            var expenses = await _appDbContext.Expenses
                .Where(e => e.StoreId == storeId && e.Category == expenseCategory)
                .ToListAsync();
            return expenses;
        }
    }
}
