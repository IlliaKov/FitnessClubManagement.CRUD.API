using FCManagement.BL.ABSTRACT;
using FCManagement.BL.IMPL;
using FCManagement.DAL.ABSTRACT;
using FCManagement.DAL.IMPL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClubManagement.CRUD.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _currentEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            Configuration = configuration;
            _currentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            if (_currentEnvironment.IsEnvironment("Testing"))
            {
                services.AddDbContext<FitnessDbContext>(options =>
                    options.UseInMemoryDatabase("Server=DESKTOP-O2OB7P9;Database=fitnessClubCRUDDb; Trusted_Connection=True;"));
            }
            else
            {
                services.AddDbContext<FitnessDbContext>(options =>
                    options.UseSqlServer(connection, p => { p.EnableRetryOnFailure(); p.MigrationsAssembly("FCManagement.DAL.IMPL"); }));
            }

            

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<IWorkoutRepository, WorkoutRepository>();
            services.AddTransient<IWorkoutPlanRepository, WorkoutPlanRepository>();

            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IMembershipService, MembershipService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<IWorkoutService, WorkoutService>();
            services.AddTransient<IWorkoutPlanService, WorkoutPlanService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
