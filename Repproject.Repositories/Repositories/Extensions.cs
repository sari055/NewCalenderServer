using Microsoft.Extensions.DependencyInjection;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IYearEventRepository, YearEventRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<CalenderRepository, CalenderRepository>();
            services.AddScoped<CalenderUserRepository, CalenderUserRepository>();
            services.AddScoped<CalenderYearRepository, CalenderYearRepository>();
            
            return services;
        }
    }
}
