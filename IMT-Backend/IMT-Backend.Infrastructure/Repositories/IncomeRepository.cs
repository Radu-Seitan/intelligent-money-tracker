using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;
using IMT_Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMT_Backend.Infrastructure.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly AppDbContext _appDbContext;
        public IncomeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateIncome(Income income)
        {
            await _appDbContext.Incomes.AddAsync(income);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Income>> GetAllIncomes()
        {
            return await _appDbContext.Incomes.ToListAsync();
        }
        public async Task<IEnumerable<Income>> GetAllUserIncomes(string userId)
        {
            var incomes = await _appDbContext.Incomes
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return incomes;
        }
        public async Task<IEnumerable<Income>> GetUserIncomesByCategory(string userId, IncomeCategory incomeCategory)
        {
            var incomes = await _appDbContext.Incomes
                .Where(i => i.UserId == userId && i.Category == incomeCategory)
                .ToListAsync();

            return incomes;
        }
        public async Task<IEnumerable<Income>> GetAllIncomesByCategory(IncomeCategory incomeCategory)
        {
            var incomes = await _appDbContext.Incomes
                .Where(i => i.Category == incomeCategory)
                .ToListAsync();

            return incomes;
        }
    }
}
