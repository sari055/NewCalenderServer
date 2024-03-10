using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repproject.Repositories.Interfaces;
using Repproject.Repositories.Repositories;
using RepProject.Context;
using RepProject.Services;
using RepProject.WebAPI.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepProject.Services.Services;
using RepProject.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using RepProject.WebAPI.Controllers;
using RepProject.WebAPI.Models;
using Repproject.Repositories.Entities;

namespace RepProject.WebAPI
{
    public class Startup
    {
        private string MyOrigin = "myOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // services.AddSingleton<IContext>();
            services.AddServices();
            //services.AddSingleton<IContext, MockContext>();
            services.AddDbContext<IContext, DataContext>();

            services.AddScoped<IYearEventService, YearEventService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICalenderService, CalenderService>();
            services.AddScoped<ICalenderYearService, CalenderYearService>();
            services.AddScoped<ICalenderUserService, CalenderUserService>();

            services.AddAutoMapper(typeof(Mapping));
           services.AddAutoMapper(typeof(YearEventModel), typeof(YearEventModel));
           services.AddAutoMapper(typeof(UserTypeModel), typeof(UserTypeModel));
           services.AddAutoMapper(typeof(LevelModel), typeof(LevelModel));
           services.AddAutoMapper(typeof(EventModel), typeof(EventModel));
           services.AddAutoMapper(typeof(CalenderYearModel), typeof(CalenderYearModel));
           services.AddAutoMapper(typeof(CalenderUserModel), typeof(CalenderUserModel));
           services.AddAutoMapper(typeof(CalenderModel), typeof(CalenderModel));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RepProject.WebAPI", Version = "v1" });
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyOrigin,
            //                      policy =>
            //                      {
            //                          policy.WithOrigins("*");
            //                      });
            //});
        }
      
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RepProject.WebAPI v1"));
            }
           
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
          
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseTrack();

           // app.UseShabbos();
            //app.Use(function(req, res, next) {
            //    res.header('Access-Control-Allow-Origin', req.headers.origin);
            //    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            //    next();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
