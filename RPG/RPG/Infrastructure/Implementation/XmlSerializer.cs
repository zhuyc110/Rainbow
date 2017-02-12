using System;
using System.IO;
using log4net;
using RPG.Infrastructure.Interfaces;

namespace RPG.Infrastructure.Implementation
{
    public class XmlSerializer : IXmlSerializer
    {
        public static IXmlSerializer Instance { get; }

        static XmlSerializer()
        {
            Instance = new XmlSerializer();
        }

        private XmlSerializer()
        {
        }

        #region IXmlSerializer Members

        public T DeSerialize<T>(string filePath) where T : class
        {
            if (!File.Exists(filePath))
            {
                Log.Error($"Can not find file: {filePath}");
                throw new FileNotFoundException();
            }

            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        var xmlS = new System.Xml.Serialization.XmlSerializer(typeof(T));
                        return xmlS.Deserialize(sr) as T;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error($"Can not de-serialize {filePath}", exception);
            }

            throw new Exception("Can not de-serialize");
        }

        public void Serialize<T>(T target, string filePath) where T : class
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var xmlS = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    xmlS.Serialize(fs, target);
                }
            }
            catch (Exception exception)
            {
                Log.Error($"Can not serialize {target}", exception);
            }
        }

        #endregion

        private static readonly ILog Log = LogManager.GetLogger(typeof(XmlSerializer));
    }
}