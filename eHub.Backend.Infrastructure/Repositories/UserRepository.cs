using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Domain.Entities;

namespace eHub.Backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
