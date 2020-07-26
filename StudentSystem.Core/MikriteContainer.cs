using System;
using Microsoft.Extensions.DependencyInjection;

namespace StudentSystem.Core
{
    /// <summary>
    /// The container 
    /// </summary>
    public class MikriteContainer
    {
        /// <summary>
        /// The provider that stores all built services and can be later retrieved throughout the application.
        /// </summary>
        public IServiceProvider Provider 
        {
            get;
            protected set;
        }

        /// <summary>
        /// The collection of all stored services to be later built into <seealso cref="IServiceProvider"/>.
        /// </summary>
        public IServiceCollection Services
        {
            get;
            set;
        }

        /// <summary>
        /// The basic constructor for DI container. By default it instances new <seealso cref="ServiceCollection"/> to store all services in the application.
        /// </summary>
        /// <param name="createServiceCollection">The default true bool value to create service collection. Can be changed if intend is to not create it.</param>
        public MikriteContainer(bool createServiceCollection = true)
        {
            if (createServiceCollection)
            {
                Services = new ServiceCollection();
            }
        }

        /// <summary>
        /// Builds the container and the <seealso cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The provider is initially set to null but can be changed to some provider to use another provider of services.</param>
        public void Build(IServiceProvider provider = null)
        {
            Provider = provider ?? Services.BuildServiceProvider();
        }
    }
}
