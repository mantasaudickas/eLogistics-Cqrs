using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Storage
{
    public interface IEventStore
    {
        IList<Event> LoadEvents<T>(Guid id) where T : IAggregateRoot;
        void SaveEvents<T>(Guid id, IList<Event> events) where T : IAggregateRoot;
    }
}
