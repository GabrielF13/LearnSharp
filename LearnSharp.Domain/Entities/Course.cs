namespace LearnSharp.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<Module> Module { get; set; }
        public ICollection<Subscription> Subscription { get; set; }
    }
}