namespace LearnSharp.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}