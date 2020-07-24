using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime birthDate)
        {
            var today = DateTime.Today;

            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age)) age--;

            return age;
        }
    }
}
