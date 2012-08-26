using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public class Repository<TAggregate> : IRepository<TAggregate>
        where TAggregate : class, IAggregateRoot, new()
    {
        private readonly IEventStore _store;

        public Repository(IEventStore store)
        {
            _store = store;
        }

        public TAggregate GetById(Guid id)
        {
            if (Guid.Empty.Equals(id))
                throw new Exception("Unable to load aggregate using empty guid.");

            TAggregate aggregate = new TAggregate();
            IList<Event> events = _store.LoadEvents<TAggregate>(id);
            aggregate.LoadFromHistory(events);
            return aggregate;
        }

        public void Save(TAggregate aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException("aggregate");

            if (aggregate.CurrentState == null)
                throw new NotSupportedException(string.Format("Aggregate {0} does not have state. Please create domain first.", typeof(TAggregate)));

            if (Guid.Empty.Equals(aggregate.CurrentState.Id))
                throw new NotSupportedException(string.Format("Aggregate {0} does not have Id specified. Please create domain first.", typeof (TAggregate)));

            _store.SaveEvents<TAggregate>(aggregate.CurrentState.Id, aggregate.GetUncommittedChanges());
            aggregate.Commit();
        }
    }
}
