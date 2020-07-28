using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    public static class FileLoggerExtensions
    {
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

        public static T[] Prepend<T>(this T[] source, params T[] toAdd)
        {
            return toAdd.Append(source);
        }

        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            return source.Concat(toAdd).ToArray();
        }

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string path,
            FileLoggerConfiguration configuration = null)
        {
            if (configuration == null)
            {
                configuration = new FileLoggerConfiguration();
            }

            builder.AddProvider(new FileLoggerProvider(path, configuration));

            return builder;
        }
    }
}
