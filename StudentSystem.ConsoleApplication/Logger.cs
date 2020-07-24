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
        private readonly ILog logger;

        public Logger()
        {
            LoadLog4NetConfig();
            this.logger = LogManager.GetLogger(typeof(Logger));
        }

        public static Logger GetInjectedInstance()
        {
            return DependencyInjectionManager.Logger;
        }

        /// <summary>
        /// Loads the config file log4net.config into assembled application.
        /// </summary>
        private void LoadLog4NetConfig()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public void Debug(object message)
        {
            logger.Debug(message);
        }

        public void Debug(object message, Exception cause)
        {
            logger.Debug(message, cause);
        }

        public void Info(object message)
        {
            logger.Info(message);
        }

        public void Info(object message, Exception cause)
        {
            logger.Info(message, cause);
        }

        public void Warn(object message)
        {
            logger.Warn(message);
        }

        public void Warn(object message, Exception cause)
        {
            logger.Warn(message, cause);
        }

        public void Error(object message)
        {
            logger.Error(message);
        }

        public void Error(object message, Exception cause)
        {
            logger.Error(message, cause);
        }
    }
}
