using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentSystem.Core
{
    /// <summary>
    /// The basic helper class that offers the Format method for logging from <seealso cref="FileLogger"/>.
    /// </summary>
    public static class FileLoggerFormat
    {
        /// <summary>
        /// Formats the object array and the <seealso cref="Exception"/> into Log Output string.
        /// </summary>
        /// <param name="state">The object array containing the needed elements.</param>
        /// <param name="cause">The <seealso cref="Exception"/>.</param>
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

            return $"[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}] {message} {exceptionMessage}";
        }
    }
}
