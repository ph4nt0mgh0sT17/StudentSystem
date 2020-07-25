using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer
{
    /// <summary>
    /// Extension class for <see cref="IQueryable"/> Include methods to include all tables needed.
    /// </summary>
    public static class IncludeExtensions
    {
        /// <summary>
        /// Includes the <see cref="StudentAddressEntity"/> table into <see cref="StudentEntity"/> table.
        /// </summary>
        /// <param name="studentEntities">The <see cref="IQueryable"/> interface from the database.</param>
        public static IQueryable<StudentEntity> IncludeStudentAddress(this IQueryable<StudentEntity> studentEntities)
        {
            return studentEntities.Include(s => s.StudentAddress);
        }

        /// <summary>
        /// Includes the <see cref="StudentEntity"/> table into <see cref="StudentAddressEntity"/> table.
        /// </summary>
        /// <param name="studentEntities">The <see cref="IQueryable"/> interface from the database.</param>
        public static IQueryable<StudentAddressEntity> IncludeStudents(this IQueryable<StudentAddressEntity> studentEntities)
        {
            return studentEntities.Include(address => address.SettledStudents);
        }
    }
}
