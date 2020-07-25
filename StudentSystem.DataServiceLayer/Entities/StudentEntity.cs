using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer
{
    /// <summary>
    /// The entity that represents the student table in the database.
    /// </summary>
    [Table(Constants.TableNames.StudentTable)]
    public class StudentEntity
    {
        [Column(Constants.ColumnNames.StudentTable.Id)]
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentTable.Username)]
        public string Username
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentTable.FirstName)]
        public string FirstName
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentTable.LastName)]
        public string LastName
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentTable.BirthDate)]
        public DateTime BirthDate
        {
            get;
            set;
        }

        [ForeignKey("StudentAddress")]
        [Column(Constants.ColumnNames.StudentTable.StudentAddressId)]
        public int StudentAddressId
        {
            get;
            set;
        }

        public StudentAddressEntity StudentAddress
        {
            get;
            set;
        }

        public override string ToString()
        {
            return
                $"Student ID: {Id}; Username: {Username}; Full name: {FirstName} {LastName}; Birth date: {BirthDate:d};\n\tAddress: {StudentAddress}\n";
        }
    }
}
