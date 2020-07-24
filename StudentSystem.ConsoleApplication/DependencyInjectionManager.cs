using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using log4net;
using StudentSystem.DataServiceLayer;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// This class handles the dependency injection via Autofac. It builds the container and then exposes the container internally to all classes.
    /// </summary>
    internal static class DependencyInjectionManager
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
            containerBuilder.RegisterType<StudentSystemContext>();
            containerBuilder.RegisterType<Logger>();
            Container = containerBuilder.Build();
        }

        /// <summary>
        /// The <see cref="StudentSystemContext"/> that is needed throughout whole application. Used for database connection and for <see cref="IUnitOfWork"/>
        /// </summary>
        public static StudentSystemContext StudentSystemContext => Container.Resolve<StudentSystemContext>();

        /// <summary>
        /// The <see cref="Logger"/> used for logging different types of messages into log files.
        /// </summary>
        public static Logger Logger => Container.Resolve<Logger>();
    }
}
