using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.Modules
{
    public interface IModuleRepository : IGenericRepository<Module>
    {
        Task<Module> GetModuleByNameAsync(string name);

        Task<IEnumerable<Module>> GetModulesByCourseIdAsync(Guid courseId);

        Task<Module> GetModuleWithClassesAsync(Guid id);

        Task<IEnumerable<Module>> GetAllModulesWithCoursesAsync();
    }
}