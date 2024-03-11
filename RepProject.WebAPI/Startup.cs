using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repproject.Repositories.Interfaces;
using Repproject.Repositories.Repositories;
using RepProject.Context;
using RepProject.Services;
using RepProject.WebAPI.Middlewares;


namespace RepProject.WebAPI
{
    public class Startup
    {
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
            services.AddRepositories();

            services.AddDbContext<IContext, DataContext>();

            services.AddAutoMapper(typeof(Mapping));
            
            

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
