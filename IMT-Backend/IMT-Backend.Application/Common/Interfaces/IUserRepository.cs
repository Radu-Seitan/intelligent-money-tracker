using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUser(string id);
        Task<IEnumerable<User>> GetUsers();
        Task IncreaseSum(string id, double amount);
        Task DecreaseSum(string id, double amount);
    }
}
