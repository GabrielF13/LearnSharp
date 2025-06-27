using LearnSharp.Application.Dtos;

namespace LearnSharp.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<UserDto> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<UserDto> GetUserByDocumentAsync(string document, CancellationToken cancellationToken);
        Task<bool> CreateUserAsync(UserDto userDto, CancellationToken cancellationToken);
        Task<bool> UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken);
        Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
        Task<bool> UserExistsAsync(Guid userId, CancellationToken cancellationToken);
    }
}