using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;

namespace Adm
{
    namespace Tools
    {
        /// <summary>
        /// Выполняет различные функции, связанные с сериализацей и десериализацией объектов, а также их сохранинию и считывания из файлов
        /// </summary>
        public class Xmlwr
        {
            /// <summary>
            /// Сериализация объекта в строку XML
            /// </summary>
            /// <param name="obj">Объект</param>
            /// <returns>Строку, содержащая в себе XML код сериализованного объекта</returns>
            public static string SerializeObject(object obj)
            {
                XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType());
                StringBuilder sb = new StringBuilder();
                StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);
                sr.Serialize(w, obj, new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) }));
                return sb.ToString();
            }

            /// <summary>
            /// Десериализация объекта
            /// </summary>
            /// <typeparam name="T">Тип объекта</typeparam>
            /// <param name="xml">Строка, содержащая в себе XML код сериализованного объекта</param>
            /// <returns>Объект</returns>
            public static T DeserializeObject<T>(string xml)
            {
                if ((xml == string.Empty) || (xml == null))
                {
                    return (T)Activator.CreateInstance(typeof(T));
                }
                StringReader reader = new StringReader(xml);
                XmlSerializer sr = SerializerCache.GetSerializer(typeof(T));
                return (T)sr.Deserialize(reader);
            }

           /// <summary>
           /// Запись объекта в файл
           /// </summary>
           /// <param name="FileName">Имя файла для записи</param>
           /// <param name="obj">Объект</param>        
            public static void WriteToFile(string FileName, object obj)
            {
                string res = SerializeObject(obj);
                File.WriteAllText(FileName, res);
            }

          /// <summary>
          /// Считывание из файла
          /// </summary>
          /// <typeparam name="T">Тип объекта</typeparam>
          /// <param name="FileName">Имя файла для считывания</param>
          /// <returns>Объект</returns>       
            public static T ReadFromFile<T>(string FileName)
            {
                if (File.Exists(FileName))
                {
                    string xml = File.ReadAllText(FileName);
                    return DeserializeObject<T>(xml);
                }
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
        
        /// <summary>
        /// Кэш объектов для сериализации(Создание сериализации - очень затратоемкая операция)
        /// </summary>
        public static class SerializerCache
        {
            private static Hashtable hash = new Hashtable();

            /// <summary>
            /// Получить объект для сериализации
            /// </summary>
            /// <param name="type">Тип сериализации</param>
            /// <returns>Объект для сериализации</returns>
            public static XmlSerializer GetSerializer(Type type)
            {
                XmlSerializer res = null;
                lock (hash)
                {
                    res = hash[type.FullName] as XmlSerializer;
                    if (res == null)
                    {
                        res = new XmlSerializer(type);
                        hash[type.FullName] = res;
                    }
                }
                return res;
            }
        }
    }
}