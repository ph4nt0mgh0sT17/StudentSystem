using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentSystem.Core
{
    /// <summary>
    /// The extensions for loggers.
    /// </summary>
    public static class LogExtensions
    {
        /// <summary>
        /// Gets the logger name for StudentSystem application by the current date.
        /// </summary>
        /// <param name="currentDay">The current day.</param>
        /// <param name="logPath">The name of path.</param>
        public static string GetStudentSystemLoggerPathName(this DateTimeOffset currentDay, string logPath)
        {
            string directory = Path.GetDirectoryName(logPath);
            string logName = logPath.Split("/")[logPath.Split("/").Length - 1];

            return $"{directory}/{currentDay:yyyy-MM-dd}_{logName}";
        }
    }
}
