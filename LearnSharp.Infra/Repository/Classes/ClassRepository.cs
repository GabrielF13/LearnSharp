using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.Classes
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly DbSet<Class> _dbSet;

        public ClassRepository(LearnSharpDbContext context) : base(context, context.Set<Class>())
        {
            _dbSet = context.Set<Class>();
        }

        public async Task<IEnumerable<Class>> GetByModuleAsync(Guid moduleId)
        {
            return await _dbSet.Where(c => c.IdModule == moduleId).ToListAsync();
        }

        public async Task<Class> GetWithCompleteAsync(Guid id)
        {
            return await _dbSet
                .Include(a => a.userClassCompleteds)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}