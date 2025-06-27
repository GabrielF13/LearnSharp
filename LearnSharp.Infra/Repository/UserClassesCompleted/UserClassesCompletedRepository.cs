using LearnSharp.Domain.Entities;
using LearnSharp.Infra.Sql.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnSharp.Infra.Sql.Repository.UserClassesCompleted
{
    public class UserClassesCompletedRepository : GenericRepository<UserClassCompleted>, IUserClassesCompletedRepository
    {
        private readonly DbSet<UserClassCompleted> _dbSet;

        public UserClassesCompletedRepository(LearnSharpDbContext context) : base(context, context.Set<UserClassCompleted>())
        {
            _dbSet = context.Set<UserClassCompleted>();
        }

        public async Task CompleteClassAsync(Guid userId, Guid classId, int note)
        {
            var completed = await UserCompletedClassAsync(userId, classId);

            if (!completed)
            {
                var conclusion = new UserClassCompleted
                {
                    Id = Guid.NewGuid(),
                    IdUser = userId,
                    IdClass = classId,
                    DateCompleted = DateTime.Now,
                    Note = note
                };

                await AddAsync(conclusion);
            }
        }

        public async Task<UserClassCompleted> GetByUserAndClassAsync(Guid userId, Guid classId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(uac => uac.IdUser == userId && uac.IdClass == classId);
        }

        public async Task<IEnumerable<UserClassCompleted>> GetByUserAsync(Guid userId)
        {
            return await _dbSet
                .Include(uac => uac.Class)
                .ThenInclude(a => a.Module)
                .ThenInclude(m => m.Course)
                .Where(uac => uac.IdUser == userId)
                .OrderByDescending(uac => uac.DateCompleted)
                .ToListAsync();
        }

        public async Task<bool> UserCompletedClassAsync(Guid userId, Guid classId)
        {
            return await _dbSet
               .AnyAsync(uac => uac.IdUser == userId && uac.IdClass == classId);
        }
    }
}