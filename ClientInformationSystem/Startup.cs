using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Repositories;
using ApplicationCore.Entities;

namespace ClientInformationSystem
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
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IAsyncRepository<Employees>, EfRepository<Employees>>();

            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IAsyncRepository<Clients>, EfRepository<Clients>>();


            services.AddScoped<IInteractionRepository, InteractionsRepository>();
            services.AddScoped<IInteractionsService, InteractionsService>();
            services.AddScoped<IAsyncRepository<Interactions>, EfRepository<Interactions>>();

            services.AddControllers();
            services.AddDbContext<ClientInfoSystemDbContext>(option => option.UseSqlServer(
    Configuration.GetConnectionString("ClientInfoSystemDbConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientInformationSystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientInformationSystem v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
