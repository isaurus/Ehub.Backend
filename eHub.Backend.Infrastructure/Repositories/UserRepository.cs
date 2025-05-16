using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Domain.Entities;
using eHub.Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace eHub.Backend.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public readonly AppDbContext _context = context;

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            user.IsEnabled = false;
            user.DeletedTimeUtc = DateTime.UtcNow;

            _context.Set<User>().Attach(user);
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users.FindAsync(id);

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateAsync(int id, User entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;

            _context.Set<User>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;   // Cuando se actualiza una entidad no se modifica el CreatedAt

            await _context.SaveChangesAsync();
        }
    }
}
