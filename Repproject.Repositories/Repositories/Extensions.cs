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
            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            return services;
        }
    }
}
