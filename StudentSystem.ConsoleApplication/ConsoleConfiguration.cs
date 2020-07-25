using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// This class object is just representation of the XML configuration 'config.xml' to be able deserialize or serialize if needed.
    /// </summary>
    [XmlRoot("Config")]
    public class ConsoleConfiguration : IConfiguration
    {
        /// <summary>
        /// The database connection string from the XML configuration.
        /// <para>
        /// Later used as connection for EF Core framework.
        /// </para>
        /// </summary>
        [XmlElement("DatabaseConnection")]
        public string DatabaseConnection
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"Console configuration:\n\tDatabaseConnection: {DatabaseConnection}";
        }
    }
}
