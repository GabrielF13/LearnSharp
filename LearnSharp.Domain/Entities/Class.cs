namespace LearnSharp.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkVideo { get; set; }
        public int Duration { get; set; }

        public Guid IdModule { get; set; }

        public Module Module { get; set; }
        public ICollection<UserClassCompleted> userClassCompleteds { get; set; }
    }
}