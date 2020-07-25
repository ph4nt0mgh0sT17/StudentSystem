using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Config;

namespace StudentSystem.ConsoleApplication
{
    internal class Logger
    {
        /// <summary>
        /// The log4.net logger that is used in this class as main object.
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// Constructs simple Logger for console application.
        /// </summary>
        public Logger()
        {
            LoadLog4NetConfig();
            this.logger = LogManager.GetLogger(typeof(Logger));
        }


        /// <summary>
        /// Loads the config file log4net.config into assembled application.
        /// </summary>
        private void LoadLog4NetConfig()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// Writes the debug message.
        /// </summary>
        /// <param name="message">The string message to be debugged by the logger.</param>
        public void Debug(object message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Writes the debug message with given <seealso cref="Exception"/> cause.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        /// <param name="cause">The <see cref="Exception"/> that is somewhere caught and is written into log file.</param>
        public void Debug(object message, Exception cause)
        {
            logger.Debug(message, cause);
        }

        /// <summary>
        /// Writes the INFO message.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        public void Info(object message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Writes the INFO message with <seealso cref="Exception"/> cause.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        /// <param name="cause">The <see cref="Exception"/> that is somewhere caught and is written into log file.</param>
        public void Info(object message, Exception cause)
        {
            logger.Info(message, cause);
        }


        /// <summary>
        /// Writes the WARN message.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        public void Warn(object message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// Writes the WARN message with <seealso cref="Exception"/> cause.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        /// <param name="cause">The <see cref="Exception"/> that is somewhere caught and is written into log file.</param>
        public void Warn(object message, Exception cause)
        {
            logger.Warn(message, cause);
        }

        /// <summary>
        /// Writes the ERROR message.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        public void Error(object message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Writes the ERROR message with <seealso cref="Exception"/> cause.
        /// </summary>
        /// <param name="message">The object to be written by the logger.</param>
        /// <param name="cause">The <see cref="Exception"/> that is somewhere caught and is written into log file.</param>
        public void Error(object message, Exception cause)
        {
            logger.Error(message, cause);
        }
    }
}
