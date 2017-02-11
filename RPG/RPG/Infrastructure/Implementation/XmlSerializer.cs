using System;
using System.IO;
using RPG.Infrastructure.Interfaces;

namespace RPG.Infrastructure.Implementation
{
    public class XmlSerializer : IXmlSerializer
    {
        #region IXmlSerializer Members

        public T DeSerialize<T>(string filePath) where T : class
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            T result;
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    var xmlS = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    result = xmlS.Deserialize(sr) as T;
                }
            }
            if (result != null)
                return result;

            throw new Exception($"Can not DeSerialize file: {filePath}");
        }

        public void Serialize<T>(T target)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}