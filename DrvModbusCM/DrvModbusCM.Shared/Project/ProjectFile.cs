using System;
using System.IO;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public static class ProjectFile
    {
        public static bool SaveXml(object obj, string filename)
        {
            bool flag = false;
            using StreamWriter streamWriter = new StreamWriter(filename);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
            new XmlSerializer(obj.GetType()).Serialize(streamWriter, obj, xmlSerializerNamespaces);
            flag = true;
            streamWriter.Close();
            return flag;
        }

        public static object LoadXml(Type type, string filename)
        {
            object obj = null;
            using StreamReader streamReader = new StreamReader(filename);
            obj = new XmlSerializer(type).Deserialize(streamReader);
            streamReader.Close();
            return obj;
        }
    }
}
