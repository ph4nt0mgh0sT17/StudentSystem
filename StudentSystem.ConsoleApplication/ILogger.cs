using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication
{
    internal interface ILogger
    {
        public void Debug(object message);
        public void Debug(object message, Exception cause);

        public void Info(object message);
        public void Info(object message, Exception cause);

        public void Warn(object message);
        public void Warn(object message, Exception cause);

        public void Error(object message);
        public void Error(object message, Exception cause);
    }
}
