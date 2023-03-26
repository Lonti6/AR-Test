using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils
    {
        public static void WriteToXmlFile<T>(List<T> objects, string? fileName)
        {
            if (fileName == null)
            {
                fileName = DateTime.Now.ToString();
            }
            
            var path = Application.persistentDataPath + "/" + fileName;
            
            using(StreamWriter streamWriter = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(objects.GetType());

                serializer.Serialize(streamWriter, objects);


                Debug.Log("File save to: " + path);
            }

        }

        public static List<T> ReadXmlFile<T>(string fileName)
        {
            var path = Application.persistentDataPath + "/" + fileName;

            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                return (List<T>)serializer.Deserialize(reader);
            }
        }
    }
}
