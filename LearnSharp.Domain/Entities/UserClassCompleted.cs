namespace LearnSharp.Domain.Entities
{
    public class UserClassCompleted
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdClass { get; set; }
        public DateTime DateCompleted { get; set; }
        public int Note { get; set; }

        public User User { get; set; }
        public Class Class { get; set; }
    }
}