namespace LearnSharp.Application.Dtos
{
    public class UserClassCompletedDto
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdClass { get; set; }
        public DateTime DateCompleted { get; set; }
        public int Note { get; set; }
    }
}