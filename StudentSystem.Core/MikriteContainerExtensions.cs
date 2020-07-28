using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    /// <summary>
    /// The extension methods used for <seealso cref="MikriteContainer"/> to make adding services easier.
    /// </summary>
    public static class MikriteContainerExtensions
    {
        public static MikriteContainer AddTransientService<TService>(this MikriteContainer container) 
            where TService : class
        {
            container.Services.AddTransient<TService>();
            return container;
        }

        public static MikriteContainer AddSingletonService<TService>(this MikriteContainer container)
            where TService : class
        {
            container.Services.AddSingleton<TService>();
            return container;
        }

        public static MikriteContainer AddDbContext<TDbContext>(this MikriteContainer container, Action<DbContextOptionsBuilder> builder)
            where TDbContext : DbContext
        {
            container.Services.AddDbContext<TDbContext>(builder);
            return container;
        }


        public static MikriteContainer AddFileLogger(this MikriteContainer container, string logPath = "log.txt")
        {
            container.Services.AddLogging(options =>
            {
                options.AddFile(logPath, new FileLoggerConfiguration {LogAtTop = true});
            });

            return container;
        }

        public static MikriteContainer AddDefaultLogger(this MikriteContainer container)
        {
            container.Services.AddLogging(options =>
            {
                options.SetMinimumLevel(LogLevel.Debug);
            });

            container.Services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("MikriteLogger"));

            return container;
        }
    }
}
