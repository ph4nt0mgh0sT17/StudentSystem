using System;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer
{
    public class StudentSystemContext : DbContext
    {
        /// <summary>
        /// Basic constructor that constructs the <seealso cref="StudentSystemContext"/> without the connection.
        /// </summary>
        public StudentSystemContext() : base()
        {
        }

        /// <summary>
        /// Constructs the <seealso cref="StudentSystemContext"/> with options.
        /// </summary>
        /// <param name="options">The options of the database.</param>
        public StudentSystemContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// The <seealso cref="DbSet{TEntity}"/> of Students table in the database.
        /// </summary>
        public DbSet<StudentEntity> Students
        {
            get;
            set;
        }

        /// <summary>
        /// The <seealso cref="DbSet{}"/> of Student Addresses table in the database.
        /// </summary>
        public DbSet<StudentAddressEntity> StudentAddresses
        {
            get;
            set;
        }
    }
}
