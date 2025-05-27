using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.PaymentsSubscriptions
{
    public interface IPaymentsSubscriptionsRepository : IGenericRepository<PaymentSubscription>
    {
        Task<IEnumerable<PaymentSubscription>> GetByUserSubscriptionsAsync(Guid userSubscriptionId);

        Task<PaymentSubscription> GetByIdExternalAsync(string idExterno);

        Task<IEnumerable<PaymentSubscription>> GetPendingAsync();

        Task<IEnumerable<PaymentSubscription>> GetExpiredAsync();
    }
}