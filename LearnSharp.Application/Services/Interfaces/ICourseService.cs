using LearnSharp.Application.Dtos;

namespace LearnSharp.Application.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDto> GetByNameAsync(string name);

        Task<CourseDto> GetWithModulesAsync(Guid id);

        Task<IEnumerable<CourseDto>> GetBySubscriptionAsync(Guid courseId);

        Task<bool> CreateCourseAsync(CourseDto courseDto, CancellationToken cancellationToken);

        Task<bool> UpdateCourseAsync(CourseDto courseDto, CancellationToken cancellationToken);

        Task<bool> DeleteCourseAsync(Guid courseId, CancellationToken cancellationToken);
    }
}