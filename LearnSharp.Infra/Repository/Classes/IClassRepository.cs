using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.Classes
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        Task<IEnumerable<Class>> GetByModuleAsync(Guid moduleId);
        Task<Class> GetWithCompleteAsync(Guid id);
    }
}