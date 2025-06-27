using LearnSharp.Infra.Sql.Repository.Classes;
using LearnSharp.Infra.Sql.Repository.Courses;
using LearnSharp.Infra.Sql.Repository.Generic;
using LearnSharp.Infra.Sql.Repository.Modules;
using LearnSharp.Infra.Sql.Repository.PaymentsSubscriptions;
using LearnSharp.Infra.Sql.Repository.Subscriptions;
using LearnSharp.Infra.Sql.Repository.UserClassesCompleted;
using LearnSharp.Infra.Sql.Repository.Users;
using LearnSharp.Infra.Sql.Repository.UserSubscriptions;
using LearnSharp.Infra.Sql.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnSharp.Infra.Sql.DependencyInjection
{
    public static class DbContextDependencyInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesAndServices();
            services.AddSqlConnection(configuration);
            //services.AddAuth(configuration);

            return services;
        }

        private static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPaymentsSubscriptionsRepository, PaymentsSubscriptionsRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserClassesCompletedRepository, UserClassesCompletedRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LearnSharp");
            services.AddDbContext<LearnSharpDbContext>(optitons =>
                optitons.UseSqlServer(connectionString));

            return services;
        }
    }
}