using BL.Intefaces;
using BL.Service;
using DAL.DBContext;
using DAL.Interfaces;
using DAL.Reposytory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTaskManagerBL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskManageService, TaskManageService>();
            services.AddDbContext<AppDBContext>((sp, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
