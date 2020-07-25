using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// The configuration of the application.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// The database connection to the MySQL server.
        /// </summary>
        public string DatabaseConnection { get; set; }
    }
}
