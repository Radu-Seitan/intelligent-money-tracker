using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Infrastructure.Persistence;

namespace IMT_Backend.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _appDbContext;
        public StoreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateStore(Store store)
        {
            await _appDbContext.Stores.AddAsync(store);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<Store> GetStore(int id)
        {
            return await _appDbContext.Stores.FindAsync(id);
        }
        public async Task<IEnumerable<Store>> GetStores()
        {
            return _appDbContext.Stores;
        }
    }
}
