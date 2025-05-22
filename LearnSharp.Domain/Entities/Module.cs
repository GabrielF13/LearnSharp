namespace LearnSharp.Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public Course Course { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}