using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class AddressState : State
    {
        public AddressState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return AddressId; } }
        public Guid AddressId { get; private set; }
        public Owner Owner { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid CountryId { get; private set; }
        public Guid CityId { get; private set; }
        public string Street { get; private set; }
        public string HouseNo { get; private set; }
        public string PostalCode { get; private set; }
        public string Note { get; private set; }

        public void When(AddressEvents.Created e)
        {
            this.AddressId = e.AddressId;
            this.Owner = e.Owner;
            this.OwnerId = e.OwnerId;
        }

        public void When(AddressEvents.CountryChanged e)
        {
            this.CountryId = e.CountryId;
        }

        public void When(AddressEvents.CityChanged e)
        {
            this.CityId = e.CityId;
        }

        public void When(AddressEvents.StreetChanged e)
        {
            this.Street = e.Street;
            this.HouseNo = e.HouseNo;
        }

        public void When(AddressEvents.PostalCodeChanged e)
        {
            this.PostalCode = e.PostalCode;
        }

        public void When(AddressEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

    }
}
