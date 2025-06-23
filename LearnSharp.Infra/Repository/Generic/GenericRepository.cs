using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearnSharp.Infra.Sql.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LearnSharpDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(LearnSharpDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet.FindAsync(id) != null;
        }

        public async Task SaveChangesAsync(Guid id)
        {
            await _context.SaveChangesAsync();
        }
    }
}