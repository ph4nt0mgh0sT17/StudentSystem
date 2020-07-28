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
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        public bool LogTime { get; set; } = true;

        public bool LogAtTop { get; set; } = false;

        public bool OuptutLogLevel { get; set; } = true;
    }
}
