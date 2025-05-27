using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.Courses
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly DbSet<Course> _dbSet;

        public CourseRepository(LearnSharpDbContext context) : base(context, context.Set<Course>())
        {
            _dbSet = context.Set<Course>();
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Course>> GetBySubscriptionAsync(Guid subscriptionId)
        {
            return await _dbSet
                .Where(c => c.Subscription.Any(s => s.Id == subscriptionId))
                .ToListAsync();
        }

        public Task<Course> GetWithModulesAsync(Guid id)
        {
            return _dbSet
                .Include(c => c.Module)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}