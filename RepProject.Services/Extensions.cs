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

            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IParentService, PrentService>();
            return services;
        }
    }
}
