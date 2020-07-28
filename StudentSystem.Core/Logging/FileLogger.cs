using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    public class FileLogger : ILogger
    {
        protected static ConcurrentDictionary<string, object> FileLocks = new ConcurrentDictionary<string, object>();
        protected static object FileLockEnsure = new object();

        protected readonly string mCategoryName;
        protected readonly string mFilePath;
        protected readonly string mDirectory;

        protected FileLoggerConfiguration mFileLoggerConfiguration;

        public FileLogger(string categoryName, string filePath, FileLoggerConfiguration configuration)
        {
            // Set members
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

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= mFileLoggerConfiguration.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // We do not want to log if the log level is not enough
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            string logLevelString = mFileLoggerConfiguration.OuptutLogLevel ? $"{logLevel.ToString().ToUpper()}: " : "";

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

                using (StreamWriter fileWriter = new StreamWriter(File.Open(mFilePath, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.ReadWrite)))
                {
                    fileWriter.BaseStream.Seek(0, SeekOrigin.End);
                    fileWriter.Write(output);
                }
            }


        }

        private void EnsureDirectory(string directoryName)
        {
            if (!Directory.Exists(mDirectory))
            {
                Directory.CreateDirectory(mDirectory);
            }
        }
    }
}
