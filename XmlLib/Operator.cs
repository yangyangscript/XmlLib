using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlLib
{
    public static class Operator
    {
        /// <summary>
        /// 这样写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="mes"></param>
        public static void Write<T>(string path, List<T> mes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, mes);
            writer.Close();
        }
        public static T ReadFromPath<T>(string path) where T:class 
        {
            var xmldes = new XmlSerializer(typeof(T));
            var reader = new XmlTextReader(path);
            return Read<T>(reader);
        }
        public static T ReadFromString<T>(string xmlStr) where T : class
        {
            var bytes = Encoding.UTF8.GetBytes(xmlStr);
            var ms = new MemoryStream(bytes, 0, bytes.Length);
            ms.Position = 0;
            var reader = new XmlTextReader(ms);
            return Read<T>(reader);
        }
        /// <summary>
        /// 这样读
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static T Read<T>(XmlReader reader) where T:class 
        {
            var xmlSer = new XmlSerializer(typeof(T));
            return xmlSer.Deserialize(reader) as T;
        }
    }
}
