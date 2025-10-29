using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;

namespace LearnSharp.Infra.Sql.Repository.Subscriptions
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Task<IEnumerable<Subscription>> GetWithCourseAsync();

        Task<Subscription> GetWithCoursesAsync(Guid id);
    }
}