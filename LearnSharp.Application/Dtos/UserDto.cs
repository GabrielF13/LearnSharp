using LearnSharp.Domain.Entities.Enum;

namespace LearnSharp.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string Document { get; set; }
        public string Cellphone { get; set; }
        public Roles Role { get; set; }
        public bool Active { get; set; }
    }
}