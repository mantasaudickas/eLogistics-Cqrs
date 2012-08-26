using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public class MemoryEventStore : IEventStore
    {
        private readonly IDictionary<Type, IDictionary<Guid, List<Event>>> _storedEvents = new Dictionary<Type, IDictionary<Guid, List<Event>>>();
        private readonly IMessageBus _publisher = ObjectFactory.Create<IMessageBus>();

        public MemoryEventStore()
        {
        }

        public IList<Event> LoadEvents<T>(Guid id) where T : IAggregateRoot
        {
            Type aggregateType = typeof(T);

            IDictionary<Guid, List<Event>> eventGroup;
            if (!_storedEvents.TryGetValue(aggregateType, out eventGroup))
            {
                eventGroup = new Dictionary<Guid, List<Event>>();
                _storedEvents.Add(aggregateType, eventGroup);
            }

            List<Event> eventList;
            if (!eventGroup.TryGetValue(id, out eventList))
            {
                eventList = LoadEventStream<T>(id);
                eventGroup.Add(id, eventList);
            }

            return eventList;
        }

        public void SaveEvents<T>(Guid id, IList<Event> events) where T : IAggregateRoot
        {
            Type aggregateType = typeof(T);

            IDictionary<Guid, List<Event>> eventGroup;
            if (!_storedEvents.TryGetValue(aggregateType, out eventGroup))
            {
                eventGroup = new Dictionary<Guid, List<Event>>();
                _storedEvents.Add(aggregateType, eventGroup);
            }

            List<Event> eventList;
            if (!eventGroup.TryGetValue(id, out eventList))
            {
                eventList = LoadEventStream<T>(id);
                eventGroup.Add(id, eventList);
            }

            foreach (Event eventToSave in events)
            {
                this.SaveEventStream<T>(eventList, id, eventToSave);
            }

            foreach (var eventToPublish in events)
            {
                _publisher.Publish(eventToPublish);
            }
/*
            Task.Factory.StartNew(() =>
                                      {
                                          foreach (var eventToPublish in events)
                                          {
                                              _publisher.Publish(eventToPublish);
                                          }
                                      });
*/
        }

        protected virtual List<Event> LoadEventStream<T>(Guid id) 
            where T : IAggregateRoot
        {
            return new List<Event>();
        }

        protected virtual void SaveEventStream<T>(List<Event> eventList, Guid id, Event eventToSave)
        {
            eventList.Add(eventToSave);
        }
    }
}
