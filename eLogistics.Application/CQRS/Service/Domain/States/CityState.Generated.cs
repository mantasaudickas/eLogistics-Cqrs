using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class CityState : State
    {
        public CityState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return CityId; } }
        public Guid CityId { get; private set; }
        public Guid CountryId { get; private set; }
        public string Name { get; private set; }

        public void When(CityEvents.Created e)
        {
            this.CityId = e.CityId;
        }

        public void When(CityEvents.CountryChanged e)
        {
            this.CountryId = e.CountryId;
        }

        public void When(CityEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

    }
}
