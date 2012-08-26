using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class CountryState : State
    {
        public CountryState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return CountryId; } }
        public Guid CountryId { get; private set; }
        public string Name { get; private set; }

        public void When(CountryEvents.Created e)
        {
            this.CountryId = e.CountryId;
        }

        public void When(CountryEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

    }
}
