using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    /// <summary>
    /// The main logger used for logging to the files.
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// <seealso cref="ConcurrentDictionary{TKey,TValue}"/> for all files to lock current writing to the file. Thread-safe.
        /// </summary>
        protected static ConcurrentDictionary<string, object> FileLocks = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// The object lock that is used for obtaining the file lock object from the FileLocks.
        /// </summary>
        protected static object FileLockEnsure = new object();

        /// <summary>
        /// The name of the category provided by <seealso cref="ILoggerFactory"/>.
        /// </summary>
        protected readonly string mCategoryName;

        /// <summary>
        /// The path name of the log file.
        /// </summary>
        protected readonly string mFilePath;

        /// <summary>
        /// The directories where the log file is to be located.
        /// </summary>
        protected readonly string mDirectory;

        /// <summary>
        /// The configuration for <seealso cref="FileLogger"/>. Can be changed in the future.
        /// </summary>
        protected FileLoggerConfiguration mFileLoggerConfiguration;

        /// <summary>
        /// The main constructor that sets all needed properties...
        /// </summary>
        /// <param name="categoryName">The category name of the Logger.</param>
        /// <param name="filePath">The file path name where the logger is located.</param>
        /// <param name="configuration">The <seealso cref="FileLoggerConfiguration"/>. </param>
        public FileLogger(string categoryName, string filePath, FileLoggerConfiguration configuration)
        {
            mCategoryName = categoryName;
            mFilePath = Path.GetFullPath(filePath);
            mDirectory = Path.GetDirectoryName(filePath);
            mFileLoggerConfiguration = configuration;
        }

        /// <summary>
        /// This is only for sake of the <seealso cref="ILogger"/> implementation. The logger has no scope.
        /// </summary>>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// Checks if the logger can log the message that is checked if the log level is good.
        /// </summary>
        /// <param name="logLevel">The <seealso cref="LogLevel"/>.</param>
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= mFileLoggerConfiguration.LogLevel;
        }

        /// <summary>
        /// The main method that actually logs the message to the file log.
        /// </summary>
        /// <typeparam name="TState">This type parameter is not really used in the application. It's only for sake of the interface.</typeparam>
        /// <param name="logLevel">The log level of the message.</param>
        /// <param name="state">This is actually object array that contains 4 elements: message, origin, filePath and lineNumber...</param>
        /// <param name="exception">The exception to be logged after the message.</param>
        /// <param name="formatter">The formatter <seealso cref="Func{TState, Exception, string}"/>.</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // We do not want to log if the log level is not enough
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            string logLevelString = mFileLoggerConfiguration.OutputLogLevel ? $"{logLevel.ToString().ToUpper()}: " : "";

            string timeLogString = mFileLoggerConfiguration.LogTime ? $"[{currentTime}] " : "";

            // Gets the whole message string
            string message = formatter(state, exception);

            string output = $"{logLevelString}{timeLogString}{message}{Environment.NewLine}";

            string normalizedPath = mFilePath.ToUpper();

            object fileLock = default(object);

            lock (FileLockEnsure)
            {
                fileLock = FileLocks.GetOrAdd(normalizedPath, objectLock => new object());
            }

            lock (fileLock)
            {
                EnsureDirectory(mDirectory);
                WriteLogToFile(output);
            }
        }

        /// <summary>
        /// Ensures the directory does really exist. If not the directory is created.
        /// </summary>
        /// <param name="directoryName">The name of the directory.</param>
        private void EnsureDirectory(string directoryName)
        {
            if (!Directory.Exists(mDirectory))
            {
                Directory.CreateDirectory(mDirectory);
            }
        }

        /// <summary>
        /// Writes the Log message to the file.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        private void WriteLogToFile(string message)
        {
            using (StreamWriter fileWriter = new StreamWriter(File.Open(mFilePath, FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                fileWriter.BaseStream.Seek(0, SeekOrigin.End);
                fileWriter.Write(message);
            }
        }
    }
}
