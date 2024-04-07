using Microsoft.Extensions.DependencyInjection;
using CalendarApp.Repositories.Repositories;
using CalendarApp.Services.Interfaces;
using CalendarApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarApp.WebAPI.Services;

namespace CalendarApp.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<IYearEventService, YearEventService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISiteUserService, SiteUserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IEventService,EventService>();
            services.AddScoped<ICalenderService, CalenderService>();
            services.AddScoped<ICalenderYearService, CalenderYearService>();
            services.AddScoped<ICalenderUserService, CalenderUserService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
