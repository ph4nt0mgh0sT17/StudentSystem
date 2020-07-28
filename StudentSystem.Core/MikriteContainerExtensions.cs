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
        /// <summary>
        /// Adds the transient service to the <seealso cref="MikriteContainer"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to be added.</typeparam>
        /// <param name="container">The <seealso cref="MikriteContainer"/>.</param>
        public static MikriteContainer AddTransientService<TService>(this MikriteContainer container) 
            where TService : class
        {
            container.Services.AddTransient<TService>();
            return container;
        }

        /// <summary>
        /// Adds the singleton service to the <seealso cref="MikriteContainer"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to be added.</typeparam>
        /// <param name="container">The <seealso cref="MikriteContainer"/>.</param>
        public static MikriteContainer AddSingletonService<TService>(this MikriteContainer container)
            where TService : class
        {
            container.Services.AddSingleton<TService>();
            return container;
        }

        /// <summary>
        /// Adds the <seealso cref="DbContext"/> to the <seealso cref="MikriteContainer"/>.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the <seealso cref="DbContext"/> to be added as a service.</typeparam>
        /// <param name="container">The container that will add the <seealso cref="DbContext"/> service.</param>
        /// <param name="builder">The <see cref="DbContextOptionsBuilder"/> that builds some options to the <seealso cref="DbContext"/>.</param>
        /// <returns></returns>
        public static MikriteContainer AddDbContext<TDbContext>(this MikriteContainer container, Action<DbContextOptionsBuilder> builder)
            where TDbContext : DbContext
        {
            container.Services.AddDbContext<TDbContext>(builder);
            return container;
        }

        /// <summary>
        /// Adds the <seealso cref="FileLogger"/> as as service.
        /// </summary>
        /// <param name="container">The <seealso cref="MikriteContainer"/> that will add the <seealso cref="FileLogger"/> as a service.</param>
        /// <param name="logPath">The log path name of the log file.</param>
        public static MikriteContainer AddFileLogger(this MikriteContainer container, string logPath = "log.txt")
        {
            container.Services.AddLogging(options =>
            {
                options.AddFile(logPath, new FileLoggerConfiguration());
            });

            return container;
        }

        /// <summary>
        /// Adds the default logger to the <seealso cref="MikriteContainer"/> via <seealso cref="ILoggerFactory"/> to be able later use the <seealso cref="ILogger"/>.
        /// </summary>
        /// <param name="container">The <seealso cref="MikriteContainer"/> that will add the <seealso cref="ILogger"/> as a service.</param>
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
