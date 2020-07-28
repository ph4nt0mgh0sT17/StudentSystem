using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    /// <summary>
    /// The main configuration for the <seealso cref="FileLogger"/>.
    /// </summary>
    public class FileLoggerConfiguration
    {
        /// <summary>
        /// The minimal log level of the <seealso cref="FileLogger"/>.
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        /// <summary>
        /// The boolean state if the time of the log should be logged.
        /// </summary>
        public bool LogTime { get; set; } = true;

        /// <summary>
        /// The boolean state if the log level should be logged.
        /// </summary>
        public bool OutputLogLevel { get; set; } = true;
    }
}
