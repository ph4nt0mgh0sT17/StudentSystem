using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    /// <summary>
    /// The basic extension methods for the <seealso cref="FileLogger"/>.
    /// </summary>
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Logs the information to the log file.
        /// </summary>
        /// <param name="logger">The logger that logs the message.</param>
        /// <param name="message">The message to be logged</param>
        /// <param name="eventId">The <seealso cref="EventId"/>. It's not really used in the method.</param>
        /// <param name="exception">The <seealso cref="Exception"/> that is logged with the message.</param>
        /// <param name="origin">The origin method from where the message is being logged.</param>
        /// <param name="filePath">The class from where the message is being logged.</param>
        /// <param name="lineNumber">The line number from where the message is being logged.</param>
        /// <param name="args">The arguments.</param>
        public static void LogInformationSource(
            this ILogger logger,
            string message, 
            EventId eventId = new EventId(),
            Exception exception = null,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            params object[] args)
        {
            logger?.Log(LogLevel.Information, eventId, args.Prepend(origin, filePath, lineNumber, message), exception, FileLoggerFormat.Format);
        }

        /// <summary>
        /// Add <seealso cref="FileLoggerProvider"/> with set path and the <seealso cref="FileLoggerConfiguration"/>.
        /// </summary>
        /// <param name="builder">The <seealso cref="ILoggingBuilder"/> that adds the <seealso cref="FileLoggerProvider"/>.</param>
        /// <param name="path">The path of the log file.</param>
        /// <param name="configuration">The configuration for the <seealso cref="FileLogger"/>.</param>
        /// <returns></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string path,
            FileLoggerConfiguration configuration = null)
        {
            configuration = configuration ?? new FileLoggerConfiguration();

            builder.AddProvider(new FileLoggerProvider(path, configuration));

            return builder;
        }
    }
}
