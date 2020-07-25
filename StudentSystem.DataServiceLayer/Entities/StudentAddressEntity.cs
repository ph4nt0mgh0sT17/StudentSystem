using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentSystem.DataServiceLayer.Entities
{
    /// <summary>
    /// Entity that represents the StudentAddress table from the database.
    /// </summary>
    [Table(Constants.TableNames.StudentAddressTable)]
    public class StudentAddressEntity
    {
        [Column(Constants.ColumnNames.StudentAddressTable.Id)]
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentAddressTable.Address1)]
        public string Address1
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentAddressTable.Address2)]
        public string Address2
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentAddressTable.City)]
        public string City
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentAddressTable.Region)]
        public string Region
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentAddressTable.Country)]
        public string Country
        {
            get;
            set;
        }

        [Column(Constants.ColumnNames.StudentAddressTable.PostalCode)]
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
