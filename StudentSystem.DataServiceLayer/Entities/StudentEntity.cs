using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.DataServiceLayer.Entities
{
    /// <summary>
    /// The entity that represents the student table in the database.
    /// </summary>
    [Table("STUDENT")]
    public class StudentEntity
    {
        [Column("PK_STUDENT_ID")]
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Column("USER_NAME")]
        public string Username
        {
            get;
            set;
        }

        [Column("FIRST_NAME")]
        public string FirstName
        {
            get;
            set;
        }

        [Column("LAST_NAME")]
        public string LastName
        {
            get;
            set;
        }

        [Column("BIRTH_DATE")]
        public DateTime? BirthDate
        {
            get;
            set;
        }
    }
}
