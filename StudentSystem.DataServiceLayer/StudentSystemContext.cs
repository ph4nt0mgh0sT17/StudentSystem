using System;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer
{
    public class StudentSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=student_system;user=root;password=root");
        }

        public DbSet<StudentEntity> Students
        {
            get;
            set;
        }
    }
}
