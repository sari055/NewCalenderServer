using Microsoft.Extensions.DependencyInjection;
using Repproject.Repositories.Repositories;
using RepProject.Services.Interfaces;
using RepProject.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<IYearEventService, YearEventService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IEventService,EventService>();
            services.AddScoped<ICalenderService, CalenderService>();
            services.AddScoped<ICalenderYearService, CalenderYearService>();
            services.AddScoped<ICalenderUserService, CalenderUserService>();
          
            return services;
        }
    }
}
