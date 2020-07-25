using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the age from the birth date. There is computed value between today's day and the birth date. 
        /// </summary>
        /// <param name="birthDate">The date of the birth.</param>
        public static int GetAge(this DateTime birthDate)
        {
            var today = DateTime.Today;

            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age)) age--;

            return age;
        }
    }
}
