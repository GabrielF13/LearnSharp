using LearnSharp.Application.Services;
using LearnSharp.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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