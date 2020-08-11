using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mikrite.Core.Logging;
using StudentSystem.Core;
using StudentSystem.DataServiceLayer;

namespace StudentSystem.WebAPI
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
            services.AddDbContext<StudentSystemContext>(builder =>
                builder.UseMySQL(
                    Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? 
                    "Server=mysql_database;Port=3306;Database=student_system;Uid=root;Pwd=root_admin")
                );

            services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("MikriteLogger"));

            services.AddLogging(builder =>
                builder.AddProvider(
                    new FileLoggerProvider(
                        DateTimeOffset.Now.GetStudentSystemLoggerPathName("Logs/StudentSystem.txt"), 
                        new FileLoggerConfiguration
                        {
                            LogLevel = LogLevel.Debug,
                            LogTime = false,
                            OutputLogLevel = false
                        }
                    )
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
