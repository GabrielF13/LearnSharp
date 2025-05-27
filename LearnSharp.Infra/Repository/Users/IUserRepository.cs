using LearnSharp.Infra.Sql.Repository.Generic;
using LearnSharp.Domain.Entities;

namespace LearnSharp.Infra.Sql.Repository.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByDocumentAsync(string documento);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> DocumentExistsAsync(string documento);
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<User> GetWithSubscriptionsAsync(Guid id);
    }
}
