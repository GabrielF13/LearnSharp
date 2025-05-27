using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.Subscriptions
{
    public class SubscriptionRepository : GenericRepository<Domain.Entities.Subscription>, ISubscriptionRepository
    {
        private readonly DbSet<Subscription> _dbSet;

        public SubscriptionRepository(LearnSharpDbContext context) : base(context, context.Set<Subscription>())
        {
            _dbSet = context.Set<Subscription>();
        }

        public async Task<IEnumerable<Subscription>> GetWithCourseAsync()
        {
            return await _dbSet
                .Include(s => s.Courses)
                .ToListAsync();
        }

        public async Task<Subscription> GetWithCoursesAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}