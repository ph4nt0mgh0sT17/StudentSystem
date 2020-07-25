using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;

namespace StudentSystem.ConsoleApplication
{
    /// <summary>
    /// This class just offers some functions used for serializing or deserializing the XML files into C# objects.
    /// </summary>
    public static class XmlSerializationProvider<T>
    {
        /// <summary>
        /// Deserializes the xml file by given <paramref name="xmlFileName"/>.
        /// </summary>
        /// <param name="xmlFileName">The name of the XML file to be read and deserialized.</param>
        public static T Deserialize(string xmlFileName)
        {
            // Creates the XML serializer of the type we want to retrieve
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // Opens the stream to the XML file
            using Stream stream = new FileStream(xmlFileName, FileMode.Open);

            // Pass the stream to serializer to deserialize the XML file
            return (T)serializer.Deserialize(stream);
        }
    }
}
