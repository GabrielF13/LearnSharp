using LearnSharp.Domain.Entities.Enum;

namespace LearnSharp.Domain.Entities
{
    public class UserSubscription
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdSubscription { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateDue { get; set; }

        public User User { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<PaymentSubscription> PaymentSubscriptions { get; set; }
    }
}