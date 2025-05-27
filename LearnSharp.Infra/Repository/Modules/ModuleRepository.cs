using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.Modules
{
    public class ModuleRepository : GenericRepository<Domain.Entities.Module>, IModuleRepository
    {
        private readonly DbSet<Module> _dbSet;

        public ModuleRepository(LearnSharpDbContext context) : base(context, context.Set<Module>())
        {
            _dbSet = context.Set<Module>();
        }

        public async Task<IEnumerable<Module>> GetAllModulesWithCoursesAsync()
        {
            return await _dbSet
                .Include(m => m.Course)
                .ToListAsync();
        }

        public async Task<Module> GetModuleByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<IEnumerable<Module>> GetModulesByCourseIdAsync(Guid courseId)
        {
            return await _dbSet
                .Where(m => m.Course.Id == courseId)
                .ToListAsync();
        }

        public Task<Module> GetModuleWithClassesAsync(Guid id)
        {
            return _dbSet
                .Include(m => m.Classes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}