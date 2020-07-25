using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace StudentSystem.ConsoleApplication
{
    public static class AutofacExtensions
    {
        /// <summary>
        /// Register <see cref="TInterface"/> to the <see cref="TImplementation"/> as service locator. 
        /// </summary>
        /// <typeparam name="TInterface">The interface that implementation will use.</typeparam>
        /// <typeparam name="TImplementation">The implementation of the interface.</typeparam>
        /// <param name="containerBuilder">The container builder itself to register these types.</param>
        /// <param name="objectModel">The object of <see cref="TImplementation"/>.</param>
        public static void Register<TInterface, TImplementation>(this ContainerBuilder containerBuilder, TImplementation objectModel)
        {
            containerBuilder.Register(c => objectModel).As<TInterface>();
        }
    }
}
