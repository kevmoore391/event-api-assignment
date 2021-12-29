using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EventApiAssignment.Models;
using EventApiAssignment.Services;
using FluentScheduler;
using System;
using System.Configuration;
using System.Collections.Specialized;

namespace EventApiAssignment
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "event-api", Version = "v1" });
            });
            services.AddScoped<EventService, EventService>();
            services.AddDbContext<EventContext>(options => options.UseSqlServer(System.Configuration.ConfigurationManager.AppSettings.Get("sqlServerConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "event-api V1");
            });

            JobManager.Initialize(new ScheduledEventRoutine());
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}