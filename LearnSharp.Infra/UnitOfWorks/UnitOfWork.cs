using LearnSharp.Infra.Sql.Repository.Classes;
using LearnSharp.Infra.Sql.Repository.Courses;
using LearnSharp.Infra.Sql.Repository.Modules;
using LearnSharp.Infra.Sql.Repository.PaymentsSubscriptions;
using LearnSharp.Infra.Sql.Repository.Subscriptions;
using LearnSharp.Infra.Sql.Repository.UserClassesCompleted;
using LearnSharp.Infra.Sql.Repository.Users;
using LearnSharp.Infra.Sql.Repository.UserSubscriptions;

namespace LearnSharp.Infra.Sql.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearnSharpDbContext _context;

        public UnitOfWork(IClassRepository classes, ICourseRepository courses, IModuleRepository modules, IPaymentsSubscriptionsRepository paymentsSubscriptions, ISubscriptionRepository subscriptions, IUserClassesCompletedRepository userClassesCompleteds, IUserRepository users, IUserSubscriptionRepository userSubscriptions)
        {
            Classes = classes;
            Courses = courses;
            Modules = modules;
            PaymentsSubscriptions = paymentsSubscriptions;
            Subscriptions = subscriptions;
            UserClassesCompleteds = userClassesCompleteds;
            Users = users;
            UserSubscriptions = userSubscriptions;
        }

        public IClassRepository Classes { get; }
        public ICourseRepository Courses { get; }
        public IModuleRepository Modules { get; }
        public IPaymentsSubscriptionsRepository PaymentsSubscriptions { get; }
        public ISubscriptionRepository Subscriptions { get; }
        public IUserClassesCompletedRepository UserClassesCompleteds { get; }
        public IUserRepository Users { get; }
        public IUserSubscriptionRepository UserSubscriptions { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}