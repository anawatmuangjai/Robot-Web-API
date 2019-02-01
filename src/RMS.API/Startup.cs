using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RMS.API.Infarstructure;
using RMS.Core.Interfaces;
using RMS.Infrastructure.Context;
using RMS.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace RMS.API
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
            services.AddDbContext<RobotContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RobotConnection"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly("RMS.Infrastructure")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            services.AddAutoMapper(
                options => options.AddProfile<MappingProfile>());

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Robot API", Version = "v1" });

                //var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "help";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Robot API V1");
                //c.InjectStylesheet("/css/swagger.min.css");
            });

            app.UseMvc();
        }
    }
}
