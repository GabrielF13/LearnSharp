namespace LearnSharp.Domain.Entities
{
    public class PaymentSubscription
    {
        public Guid Id { get; set; }
        public DateTime DateProcess { get; set; }
        public PaymentSubscription Status { get; set; }
        public string Message { get; set; }
        public decimal Value { get; set; }
        public Guid IdUserSubscription { get; set; }
        public string LinkPayment { get; set; }
        public string IdExternalPayment { get; set; }
        public DateTime DateDue { get; set; }

        public UserSubscription UserSubscription { get; set; }
    }
}