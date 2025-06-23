namespace LearnSharp.Application.Dtos
{
    public class ClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkVideo { get; set; }
        public int Duration { get; set; }
        public Guid IdModule { get; set; }
    }
}