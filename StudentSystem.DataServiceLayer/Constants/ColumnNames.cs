using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.DataServiceLayer
{
    public static partial class Constants
    {
        public static class ColumnNames
        {
            public static class StudentTable
            {
                public const string Id = "PK_STUDENT_ID";
                public const string Username = "USER_NAME";
                public const string FirstName = "FIRST_NAME";
                public const string LastName = "LAST_NAME";
                public const string BirthDate = "BIRTH_DATE";
                public const string StudentAddressId = "FK_STUDENT_ADDRESS_ID";
            }

            public static class StudentAddressTable
            {
                public const string Id = "PK_STUDENT_ADDRESS_ID";
                public const string Address1 = "ADDRESS_1";
                public const string Address2 = "ADDRESS_2";
                public const string City = "CITY";
                public const string Region = "REGION";
                public const string Country = "COUNTRY";
                public const string PostalCode = "POSTAL_CODE";
            }
        }
    }
}
