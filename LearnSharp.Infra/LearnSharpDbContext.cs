using LearnSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearnSharp.Infra
{
    public class LearnSharpDbContext : DbContext
    {
        public LearnSharpDbContext(DbContextOptions<LearnSharpDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Domain.Entities.Module> Modules { get; set; }
        public DbSet<PaymentSubscription> PaymentSubscriptions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserClassCompleted> UserClassCompleteds { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}