using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.DataServiceLayer.Entities
{
    [Table("STUDENT_ADDRESS")]
    public class StudentAddressEntity
    {
        [Column("PK_STUDENT_ADDRESS_ID")]
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Column("ADDRESS_1")]
        public string Address1
        {
            get;
            set;
        }

        [Column("ADDRESS_2")]
        public string Address2
        {
            get;
            set;
        }

        [Column("CITY")]
        public string City
        {
            get;
            set;
        }

        [Column("REGION")]
        public string Region
        {
            get;
            set;
        }

        [Column("COUNTRY")]
        public string Country
        {
            get;
            set;
        }

        [Column("POSTAL_CODE")]
        public string PostalCode
        {
            get;
            set;
        }

        public ICollection<StudentEntity> SettledStudents
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"Address: {Address1}, {Address2}, {City}, {Region}, {Country}, {PostalCode}";
        }
    }
}
