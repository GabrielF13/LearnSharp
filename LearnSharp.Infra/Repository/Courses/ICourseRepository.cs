using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.Courses
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetByNameAsync(string name);
        Task<Course> GetWithModulesAsync(Guid id);
        Task<IEnumerable<Course>> GetBySubscriptionAsync(Guid userId);
    }
}