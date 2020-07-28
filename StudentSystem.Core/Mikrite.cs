using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace StudentSystem.Core
{
    /// <summary>
    /// The main Mikrite Dependency Injection entry point.
    /// Via this class all services are built.
    /// </summary>
    public static class Mikrite
    {
        /// <summary>
        /// The container that actually contains all services.
        /// </summary>
        public static MikriteContainer Container { get; private set; }

        /// <summary>
        /// The <seealso cref="IServiceProvider"/> contained in the <seealso cref="MikriteContainer"/>.
        /// </summary>
        public static IServiceProvider Provider => Container?.Provider;

        /// <summary>
        /// Builds the container to be able access the services.
        /// </summary>
        /// <param name="container">The container that is to be built.</param>
        public static void Build(this MikriteContainer container)
        {
            container.Build();
        }

        /// <summary>
        /// Builds the container with given service provider.
        /// </summary>
        /// <param name="provider">The provider that already contains the services.</param>
        public static void Build(IServiceProvider provider)
        {
            Container.Build(provider);
        }

        /// <summary>
        /// Construct / Creates a new <seealso cref="MikriteContainer"/> to be able add new services and then build.
        /// </summary>
        public static MikriteContainer Construct()
        {
            Container = new MikriteContainer();

            return Container;
        }

        /// <summary>
        /// Construct / Creates a new <seealso cref="MikriteContainer"/> with already given container, to be able add new services and then build..
        /// </summary>
        public static MikriteContainer Construct(MikriteContainer container)
        {
            Container = container;

            return Container;
        }

        /// <summary>
        /// Gets the service from the <seealso cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="T">The type of the service to be provided.</typeparam>
        public static T RetrieveService<T>()
        {
            return Provider.GetService<T>();
        }
    }
}
