using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.UserClassesCompleted
{
    public interface IUserClassesCompletedRepository : IGenericRepository<UserClassCompleted>
    {
        Task<IEnumerable<UserClassCompleted>> GetByUserAsync(Guid userId);

        Task<UserClassCompleted> GetByUserAndClassAsync(Guid userId, Guid classId);

        Task<bool> UserCompletedClassAsync(Guid userId, Guid classId);

        Task CompleteClassAsync(Guid userId, Guid classId, int note);
    }
}