using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IStoreRepository
    {
        Task CreateStore(Store store);
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetStore(int id);
    }
}
