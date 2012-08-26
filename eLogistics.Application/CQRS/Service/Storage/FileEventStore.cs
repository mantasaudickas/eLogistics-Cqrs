using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public class FileEventStore : MemoryEventStore
    {
        private static readonly IEnumerable<Type> _eventKnownTypes;
        private readonly DataContractSerializer _serializer = new DataContractSerializer(typeof(Event), _eventKnownTypes);
        private readonly string _eventStoreLocation;

        static FileEventStore()
        {
            _eventKnownTypes = GetKnownTypes();
        }

        public FileEventStore()
        {
            string executablePath = Path.GetDirectoryName(this.GetType().Assembly.Location);
            if (executablePath == null)
                throw new NullReferenceException("Unable to resolve executable path.");

            System.Diagnostics.Debug.WriteLine("Resolved executable path: " + executablePath);

            _eventStoreLocation = Path.Combine(executablePath, "Storage\\EventStore");
        }

        protected override List<Event> LoadEventStream<T>(Guid id)
        {
            List<Event> events = base.LoadEventStream<T>(id);

            var folder = GetAggregateLocation<T>(id);
            if (Directory.Exists(folder))
            {
                List<string> files = new List<string>(Directory.GetFiles(folder, "*.xml"));
                files.Sort();

                foreach (string file in files)
                {
                    using (FileStream fileStream = File.OpenRead(file))
                    {
                        Event loadedEvent = (Event)_serializer.ReadObject(fileStream);
                        events.Add(loadedEvent);
                        fileStream.Close();
                    }
                }
            }

            return events;
        }

        protected override void SaveEventStream<T>(List<Event> eventList, Guid id, Event eventToSave)
        {
            var folder = GetAggregateLocation<T>(id);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fileName = DateTime.UtcNow.ToString("yyyyMMddHHmmssfffff") + ".xml";
            string fullPath = Path.Combine(folder, fileName);

            using (var xmlTextWriter = new XmlTextWriter(fullPath, System.Text.Encoding.UTF8))
            {
                xmlTextWriter.Formatting = Formatting.Indented;
                _serializer.WriteObject(xmlTextWriter, eventToSave);
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
            }

            base.SaveEventStream<T>(eventList, id, eventToSave);
        }

        private string GetAggregateLocation<T>(Guid id)
        {
            Type aggregateType = typeof(T);
            string folder = Path.Combine(_eventStoreLocation, aggregateType.Name, id.ToString("N"));
            return folder;
        }

        private static IEnumerable<Type> GetKnownTypes()
        {
            List<Type> knownTypes = new List<Type>();
            Type[] types = typeof(Event).Assembly.GetTypes();

            foreach (Type type in types)
            {
                if (!type.IsInterface && !type.IsAbstract && typeof(Event).IsAssignableFrom(type))
                    knownTypes.Add(type);
            }

            return knownTypes.AsReadOnly();
        }
    }
}
