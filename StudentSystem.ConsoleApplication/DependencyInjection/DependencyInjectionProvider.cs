using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using log4net;
using Microsoft.EntityFrameworkCore;
using StudentSystem.ConsoleApplication;
using StudentSystem.DataServiceLayer;
using StudentSystem.Core;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// The basic dependency injection provider using the Mikrite DI provider. Builds the whole <seealso cref="MikriteContainer"/> and offers all variables to be used in the application.
    /// <para>
    /// This feature does not make much sense in the console application since all things is going on in the Main class but can be used in WPF application.
    /// </para>
    /// </summary>
    internal static class DependencyInjectionProvider
    {
        /// <summary>
        /// Builds the provider used in the console.
        /// </summary>
        public static void BuildProvider()
        {
            Mikrite.Construct()
                .AddStudentSystemContext()
                .AddLogger()
                .Build();
        }

        /// <summary>
        /// Retrieves the <seealso cref="StudentSystemContext"/> from the Mikrite DI provider.
        /// </summary>
        public static StudentSystemContext StudentSystemContext => Mikrite.Service<StudentSystemContext>();

        /// <summary>
        /// Retrieves the <seealso cref="ILogger"/> from the Mikrite DI provider.
        /// </summary>
        public static ILogger Logger => Mikrite.Service<ILogger>();
    }
}
