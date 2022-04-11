using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
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
        public async Task CreateExpense(Expense expense)
        {
            await _appDbContext.Expenses.AddAsync(expense);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<double> ComputeExpensesForUser(string userId)
        {
            var totalExpenseForUser = await _appDbContext.Expenses
                .Where(e => e.UserId == userId)
                .Select(e => e.Quantity)
                .SumAsync();
            return totalExpenseForUser;
        }
        public async Task<double> ComputeExpensesForStore(int storeId)
        {
            var totalExpenseForStore = await _appDbContext.Expenses
                .Where(e => e.StoreId == storeId)
                .Select(e => e.Quantity)
                .SumAsync();
            return totalExpenseForStore;
        }
    }
}
