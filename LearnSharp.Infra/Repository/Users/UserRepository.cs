using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(LearnSharpDbContext context) : base(context, context.Set<User>())
        {
            _dbSet = context.Set<User>();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByDocumentAsync(string document)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Document == document);
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _dbSet
                .Where(u => u.Active)
                .ToListAsync();
        }

        public Task<User> GetWithSubscriptionsAsync(Guid id)
        {
            return _dbSet
                .Include(u => u.UserSubscriptions)
                .ThenInclude(us => us.Subscription)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<bool> DocumentExistsAsync(string documento)
        {
            return _dbSet.AnyAsync(u => u.Document == documento);
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            return _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}