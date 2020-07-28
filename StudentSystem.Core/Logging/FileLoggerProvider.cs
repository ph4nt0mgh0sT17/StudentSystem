using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace StudentSystem.Core
{
    public class FileLoggerProvider : ILoggerProvider
    {
        protected string mFilePath;

        protected readonly FileLoggerConfiguration mConfiguration;

        protected readonly ConcurrentDictionary<string, FileLogger> mLoggers = new ConcurrentDictionary<string, FileLogger>();

        public FileLoggerProvider(string path, FileLoggerConfiguration configuration)
        {
            mConfiguration = configuration;
            mFilePath = path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return mLoggers.GetOrAdd(categoryName, name => new FileLogger(name, mFilePath, mConfiguration));
        }

        public void Dispose()
        {
            mLoggers.Clear();
        }
    }
}
