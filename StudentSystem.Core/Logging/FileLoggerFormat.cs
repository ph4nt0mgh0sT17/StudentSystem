using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentSystem.Core
{
    public static class FileLoggerFormat
    {
        public static string Format(object[] state, Exception cause)
        {
            string origin = (string) state[0];
            string filePath = (string) state[1];
            int lineNumber = (int) state[2];
            string message = (string) state[3];

            string exceptionMessage = cause?.ToString();

            if (cause != null)
            {
                exceptionMessage = Environment.NewLine + cause;
            }

            return $"{message} [{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]{exceptionMessage}";
        }
    }
}
