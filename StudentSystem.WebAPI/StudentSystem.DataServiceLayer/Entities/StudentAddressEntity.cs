using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using StudentSystem.DataServiceLayer.DatabaseConstants;

namespace StudentSystem.DataServiceLayer.Entities
{
    /// <summary>
    /// Entity that represents the StudentAddress table from the database.
    /// </summary>
    [Table(TableNames.StudentAddressTable)]
    public class StudentAddressEntity
    {
        [Column(ColumnNames.StudentAddressTable.Id)]
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Column(ColumnNames.StudentAddressTable.Address1)]
        public string Address1
        {
            get;
            set;
        }

        [Column(ColumnNames.StudentAddressTable.Address2)]
        public string Address2
        {
            get;
            set;
        }

        [Column(ColumnNames.StudentAddressTable.City)]
        public string City
        {
            get;
            set;
        }

        [Column(ColumnNames.StudentAddressTable.Region)]
        public string Region
        {
            get;
            set;
        }

        [Column(ColumnNames.StudentAddressTable.Country)]
        public string Country
        {
            get;
            set;
        }

        [Column(ColumnNames.StudentAddressTable.PostalCode)]
        public string PostalCode
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
