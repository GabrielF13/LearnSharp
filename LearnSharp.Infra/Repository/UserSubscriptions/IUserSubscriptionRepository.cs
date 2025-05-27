using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.UserSubscriptions
{
    public interface IUserSubscriptionRepository : IGenericRepository<UserSubscription>
    {
        Task<IEnumerable<UserSubscription>> GetByUsersAsync(Guid userId);

        Task<IEnumerable<UserSubscription>> GetActivesAsync();

        Task<IEnumerable<UserSubscription>> GetExpiredAsync(int days);

        Task<UserSubscription> GetWithPaymentsAsync(Guid id);
    }
}