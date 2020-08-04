using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mikrite.Core.DependencyInjection;
using Mikrite.Core.Extensions;
using StudentSystem.ConsoleApplication.Configuration;
using StudentSystem.DataServiceLayer;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// The extensions used in the console application for injecting dependencies using the <seealso cref="Mikrite"/>.
    /// </summary>
    internal static class DependencyInjectionProviderExtensions
    {
        /// <summary>
        /// Adds the <seealso cref="StudentSystemContext"/> into the <seealso cref="Mikrite"/> provider.
        /// </summary>
        /// <param name="container">The container that contains the <seealso cref="IServiceCollection"/>.</param>
        public static MikriteContainer AddStudentSystemContext(this MikriteContainer container)
        {
            container.AddDbContext<StudentSystemContext>(options =>
                options.UseMySQL(ConfigurationFactory.CreateConsoleConfiguration().DatabaseConnection));

            return container;
        }
    }
}
