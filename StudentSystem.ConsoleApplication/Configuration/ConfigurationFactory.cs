using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication.Configuration
{
    /// <summary>
    /// The factory for creating the configuration from xml files.
    /// </summary>
    internal static class ConfigurationFactory
    {
        /// <summary>
        /// Returns the deserialized <seealso cref="ConsoleConfiguration"/> from the XML file.
        /// <para>
        /// There may be some better way how to do this but this has to do.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public static ConsoleConfiguration CreateConsoleConfiguration()
        {
            return XmlSerializationProvider<ConsoleConfiguration>.Deserialize("config.xml");
        }
    }
}
