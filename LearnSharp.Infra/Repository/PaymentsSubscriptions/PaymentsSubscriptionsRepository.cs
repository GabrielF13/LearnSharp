using LearnSharp.Domain.Entities;
using LearnSharp.Domain.Entities.Enum;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.PaymentsSubscriptions
{
    public class PaymentsSubscriptionsRepository : GenericRepository<PaymentSubscription>, IPaymentsSubscriptionsRepository
    {
        private readonly DbSet<PaymentSubscription> _dbSet;

        public PaymentsSubscriptionsRepository(LearnSharpDbContext context) : base(context, context.Set<PaymentSubscription>())
        {
            _dbSet = context.Set<PaymentSubscription>();
        }

        public async Task<PaymentSubscription> GetByIdExternalAsync(string idExterno)
        {
            return await _dbSet
                .Include(p => p.UserSubscription)
                .FirstOrDefaultAsync(p => p.IdExternalPayment == idExterno);
        }

        public async Task<IEnumerable<PaymentSubscription>> GetByUserSubscriptionsAsync(Guid userSubscriptionId)
        {
            return await _dbSet
                .Where(p => p.IdUserSubscription == userSubscriptionId)
                .OrderByDescending(p => p.DateProcess)
                .ToListAsync();
        }

        public async Task<IEnumerable<PaymentSubscription>> GetExpiredAsync()
        {
            return await _dbSet
                .Include(p => p.UserSubscription)
                .Where(p => p.Status == PaymentStatus.Expired)
                .ToListAsync();
        }

        public async Task<IEnumerable<PaymentSubscription>> GetPendingAsync()
        {
            return await _dbSet
                .Include(p => p.UserSubscription)
                .Where(p => p.Status == PaymentStatus.Pending)
                .ToListAsync();
        }
    }
}