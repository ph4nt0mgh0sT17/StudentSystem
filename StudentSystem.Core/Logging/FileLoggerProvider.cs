using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    /// <summary>
    /// The main logger provider for the <seealso cref="FileLogger"/>.
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// The file path name of the log file.
        /// </summary>
        protected string mFilePath;

        /// <summary>
        /// The <seealso cref="FileLoggerConfiguration"/> for current <seealso cref="FileLogger"/>.
        /// </summary>
        protected readonly FileLoggerConfiguration mConfiguration;

        /// <summary>
        /// The <seealso cref="ConcurrentDictionary{TKey,TValue}"/> containing all <seealso cref="FileLogger"/>s in the application.
        /// </summary>
        protected readonly ConcurrentDictionary<string, FileLogger> mLoggers = new ConcurrentDictionary<string, FileLogger>();

        /// <summary>
        /// The basic <seealso cref="FileLoggerProvider"/> constructor that only sets the file path name and the <seealso cref="FileLoggerConfiguration"/>.
        /// </summary>
        /// <param name="path">The file path name.</param>
        /// <param name="configuration">The configuration for <seealso cref="FileLogger"/>.</param>
        public FileLoggerProvider(string path, FileLoggerConfiguration configuration)
        {
            mConfiguration = configuration;
            mFilePath = path;
        }

        /// <summary>
        /// Adds or get the logger with given categoryName. The loggers are stored in the <seealso cref="ConcurrentDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <param name="categoryName">The category name of the <seealso cref="FileLogger"/>.</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return mLoggers.GetOrAdd(categoryName, name => new FileLogger(name, mFilePath, mConfiguration));
        }

        /// <summary>
        /// Clears all loggers.
        /// </summary>
        public void Dispose()
        {
            mLoggers.Clear();
        }
    }
}
