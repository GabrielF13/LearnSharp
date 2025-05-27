using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSharp.Infra.Sql.Repository.Subscriptions
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Task<IEnumerable<Subscription>> GetWithCourseAsync();
        Task<Subscription> GetWithCoursesAsync(Guid id);
    }
}
