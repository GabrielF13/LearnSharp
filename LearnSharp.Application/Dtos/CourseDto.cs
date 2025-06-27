using LearnSharp.Domain.Entities;

namespace LearnSharp.Application.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<ModuleDto> Modules { get; set; }
        public ICollection<SubscriptionDto> Subscriptions { get; set; } 
    }
}