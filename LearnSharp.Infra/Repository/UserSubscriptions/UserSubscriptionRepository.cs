using LearnSharp.Domain.Entities;
using LearnSharp.Domain.Entities.Enum;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.UserSubscriptions
{
    public class UserSubscriptionRepository : GenericRepository<UserSubscription>, IUserSubscriptionRepository
    {
        private readonly DbSet<UserSubscription> _dbSet;

        public UserSubscriptionRepository(LearnSharpDbContext context)
            : base(context, context.Set<UserSubscription>())
        {
            _dbSet = context.Set<UserSubscription>();
        }

        public async Task<IEnumerable<UserSubscription>> GetActivesAsync()
        {
            return await _dbSet
               .Include(ua => ua.User)
               .Include(ua => ua.Subscription)
               .Where(ua => ua.Status == SubscriptionStatus.Active)
               .ToListAsync();
        }

        public async Task<IEnumerable<UserSubscription>> GetByUsersAsync(Guid userId)
        {
            return await _dbSet
                .Include(ua => ua.Subscription)
                .Where(ua => ua.IdUser == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSubscription>> GetExpiredAsync(int days)
        {
            var limitDate = DateTime.Now.AddDays(days);
            return await _dbSet
                .Include(ua => ua.User)
                .Include(ua => ua.Subscription)
                .Where(ua => ua.Status == SubscriptionStatus.Active && ua.DateDue <= limitDate)
                .ToListAsync();
        }

        public async Task<UserSubscription> GetWithPaymentsAsync(Guid id)
        {
            return await _dbSet
                .Include(ua => ua.PaymentSubscriptions)
                .FirstOrDefaultAsync(ua => ua.Id == id);
        }
    }
}