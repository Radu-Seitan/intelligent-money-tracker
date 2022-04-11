using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
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
        public async Task<double> ComputeIncomes(string userId)
        {
            var totalIncome = await _appDbContext.Incomes
                .Where(i => i.UserId == userId)
                .Select(i => i.Quantity)
                .SumAsync();
            return totalIncome;
        }
    }
}
