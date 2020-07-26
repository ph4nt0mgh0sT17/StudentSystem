using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// A various extension methods for easier manipulation with strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is empty if so returns the null value. If it is not empty then returns the text itself.
        /// </summary>
        /// <param name="text">The input text that is being checked.</param>
        public static string IfEmptyThenNull(this string text)
        {
            return text.IsEmpty() ? null : text;
        }

        /// <summary>
        /// Checks the string is empty. Checks the length of the string is equal to 0.
        /// </summary>
        /// <param name="text">The text that is being checked.</param>
        public static bool IsEmpty(this string text)
        {
            return text.Length == 0;
        }
    }
}
