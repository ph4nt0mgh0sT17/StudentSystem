﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Autofac;
using Autofac.Core;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentSystem.ConsoleApplication;
using StudentSystem.ConsoleApplication.Configuration;
using StudentSystem.DataServiceLayer;
using Mikrite.Core;
using Mikrite.Core.DependencyInjection;
using Mikrite.Core.Extensions;

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
            DateTime nowDate = DateTime.Now;
            ConsoleConfiguration configuration = ConfigurationFactory.CreateConsoleConfiguration();
            string logPath = configuration.LogFilePathName;

            string directory = Path.GetDirectoryName(logPath);
            string logName = logPath.Split("/")[logPath.Split("/").Length - 1];


            MikriteProvider.Construct()
                .AddFileLogger($"{directory}/{DateTime.Now.ToString("yyyy-MM-dd")}_{logName}") // Should be implemented through XML files
                .AddStudentSystemContext()
                .Build();
        }

        /// <summary>
        /// Retrieves the <seealso cref="StudentSystemContext"/> from the Mikrite DI provider.
        /// </summary>
        public static StudentSystemContext StudentSystemContext => MikriteProvider.RetrieveService<StudentSystemContext>();

        /// <summary>
        /// Retrieves the <seealso cref="ILogger"/> from the Mikrite DI provider.
        /// </summary>
        public static ILogger Logger => MikriteProvider.RetrieveService<ILogger>();
    }
}