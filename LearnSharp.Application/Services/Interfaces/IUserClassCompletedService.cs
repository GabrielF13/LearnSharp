using LearnSharp.Application.Dtos;

namespace LearnSharp.Application.Services.Interfaces
{
    public interface IUserClassCompletedService
    {
        Task<IEnumerable<UserClassCompletedDto>> GetByUserAsync(Guid userId);

        Task<UserClassCompletedDto> GetByUserAndClassAsync(Guid userId, Guid classId);

        Task<bool> UserCompletedClassAsync(Guid userId, Guid classId);

        Task<bool> CompleteClassAsync(Guid userId, Guid classId, int note);
    }
}