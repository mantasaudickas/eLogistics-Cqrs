using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using eLogistics.Application.CQRS.Interfaces.Dto;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public class FileReadModelStore : MemoryReadModelStore
    {
        private static readonly object _syncRoot = new object();
        private static readonly IEnumerable<Type> _eventKnownTypes;
        private readonly DataContractSerializer _serializer = new DataContractSerializer(typeof(List<DataTransferObject>), _eventKnownTypes);
        private readonly string _eventStoreLocation;

        static FileReadModelStore()
        {
            _eventKnownTypes = GetKnownTypes();
        }

        public FileReadModelStore()
        {
            string executablePath = Path.GetDirectoryName(this.GetType().Assembly.Location);
            if (executablePath == null)
                throw new NullReferenceException("Unable to resolve executable path.");

            System.Diagnostics.Debug.WriteLine("Resolved executable path: " + executablePath);

            _eventStoreLocation = Path.Combine(executablePath, "Storage\\ReadModelStore");
        }

        protected override List<DataTransferObject> LoadList<T>()
        {
            List<DataTransferObject> loadList = null;

            string location = GetAggregateLocation<T>();
            if (Directory.Exists(location))
            {
                string fileName = Path.Combine(location, typeof (T).Name) + ".xml";
                if (File.Exists(fileName))
                {
                    using (FileStream stream = File.OpenRead(fileName))
                    {
                        loadList = (List<DataTransferObject>) _serializer.ReadObject(stream);
                        stream.Close();
                    }
                }
            }

            return loadList ?? new List<DataTransferObject>();
        }

        protected override void SaveList<T>(List<DataTransferObject> list)
        {
            string location = GetAggregateLocation<T>();
            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);

            string fileName = Path.Combine(location, typeof(T).Name) + ".xml";

            //lock (_syncRoot)
            {
                using (var xmlTextWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    _serializer.WriteObject(xmlTextWriter, list);
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                }
            }
        }

        private string GetAggregateLocation<T>()
        {
            return _eventStoreLocation;
        }

        private static IEnumerable<Type> GetKnownTypes()
        {
            List<Type> knownTypes = new List<Type>();
            Type[] types = typeof(DataTransferObject).Assembly.GetTypes();

            foreach (Type type in types)
            {
                if (!type.IsInterface && !type.IsAbstract && typeof(DataTransferObject).IsAssignableFrom(type))
                    knownTypes.Add(type);
            }

            return knownTypes.AsReadOnly();
        }

    }
}
