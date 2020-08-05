﻿using System;
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

            // Calculate age by extracting today's year from birthdate's year
            var age = today.Year - birthDate.Year;

            return (birthDate > today.AddYears(-age)) ? --age : age;
        }
    }
}