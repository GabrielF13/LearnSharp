using LearnSharp.Application.Services;
using LearnSharp.Application.Services.Interfaces;
using LearnSharp.Infra.Sql.Repository.Classes;
using LearnSharp.Infra.Sql.Repository.Courses;
using LearnSharp.Infra.Sql.Repository.Generic;
using LearnSharp.Infra.Sql.Repository.Modules;
using LearnSharp.Infra.Sql.Repository.PaymentsSubscriptions;
using LearnSharp.Infra.Sql.Repository.Subscriptions;
using LearnSharp.Infra.Sql.Repository.Users;
using LearnSharp.Infra.Sql.Repository.UserSubscriptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSharp.Application.DependencyInjection
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IUserClassCompletedService, UserClassCompletedService>();
            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
