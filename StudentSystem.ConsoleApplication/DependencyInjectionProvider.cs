using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using log4net;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// This class handles the dependency injection via Autofac. It builds the container and then exposes the container internally to all classes.
    /// </summary>
    internal static class DependencyInjectionProvider
    {
        /// <summary>
        /// The Autofac <see cref="IContainer"/> that holds all singleton classes that we need.
        /// </summary>
        private static IContainer Container
        {
            get;
            set;
        }

        /// <summary>
        /// Builds the container so then we can resolves all needed dependencies.
        /// </summary>
        public static void BuildContainer()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<Logger>();
            RegisterStudentSystemContext(containerBuilder);
            Container = containerBuilder.Build();
        }

        /// <summary>
        /// Register <see cref="StudentSystemContext"/> to the Autofac DI provider.
        /// </summary>
        /// <param name="containerBuilder">The container builder that injects this service.</param>
        private static void RegisterStudentSystemContext(ContainerBuilder containerBuilder)
        {
            IConfiguration configuration = XmlSerializationProvider<ConsoleConfiguration>.Deserialize("config.xml");

            DbContextOptionsBuilder optionsBuilder = BuildContextOptionsBuilderWithMySQL(configuration.DatabaseConnection);
            containerBuilder.Register(c => new StudentSystemContext(optionsBuilder.Options));
        }


        /// <summary>
        /// Constructs <seealso cref="DbContextOptionsBuilder"/> with MySQL connection string.
        /// </summary>
        /// <param name="connectionString">The connection to the MySQL server.</param>
        private static DbContextOptionsBuilder BuildContextOptionsBuilderWithMySQL(string connectionString)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySQL(connectionString);

            return optionsBuilder;
        }

        /// <summary>
        /// The <see cref="StudentSystemContext"/> that is needed throughout whole application. Used for database connection and for <see cref="IUnitOfWork"/>
        /// </summary>
        public static StudentSystemContext StudentSystemContext => Container.Resolve<StudentSystemContext>();

        /// <summary>
        /// The <see cref="Logger"/> used for logging different types of messages into log files.
        /// </summary>
        public static Logger Logger => Container.Resolve<Logger>();

        /// <summary>
        /// Resolves the <seealso cref="ConsoleConfiguration"/> class injected in this provider.
        /// </summary>
        public static IConfiguration ConsoleConfiguration => Container.Resolve<IConfiguration>();
    }
}
