using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace XMLSerialize
{
    public static class PackageExtension
    {
        public static string OutputXML<T>(this T instance) where T : ISMSFXmlSerializable
        {
            MemoryStream ms = new MemoryStream();
            Type type = typeof(T);
            XmlSerializer serializer = new XmlSerializer(type);
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Encoding = new UTF8Encoding(false);
            xmlWriterSettings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(ms, xmlWriterSettings))
            {
                serializer.Serialize(xmlWriter, instance, xmlns);
            }
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
