using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Infrastructure.Persistence;

namespace IMT_Backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<User> GetUser(string id)
        {
            return await _appDbContext.Users.FindAsync(id);
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return _appDbContext.Users;
        }
    }
}
