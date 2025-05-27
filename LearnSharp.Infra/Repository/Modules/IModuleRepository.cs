using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
