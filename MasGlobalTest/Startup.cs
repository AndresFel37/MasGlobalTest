﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using MasGlobalTest.Service.Service;
using MasGlobalTest.Data.Repository;
using MasGlobalTest.Data.Configuration;

namespace MasGlobalTest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Mas Global Test by Andres Betancur"

                });
            });            

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();           
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMapper, Mapper>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                // specifying the Swagger JSON endpoint.
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "");
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
