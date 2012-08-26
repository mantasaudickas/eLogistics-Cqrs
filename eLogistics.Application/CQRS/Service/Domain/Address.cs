using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Address : AggregateRoot<AddressState>
    {
        #region Constructor

        public Address() 
        {
        }

        #endregion

        #region Change Members

        public void Create(Guid addressId, Owner owner, Guid ownerId)
        {
            this.RaiseEvent(new AddressEvents.Created(addressId, owner, ownerId));
        }

        public void ChangeCountry(Guid countryId)
        {
            this.RaiseEvent(new AddressEvents.CountryChanged(this.State.Id, countryId));
        }

        public void ChangeCity(string city)
        {
            this.RaiseEvent(new AddressEvents.CityChanged(this.State.Id, city));
        }

        public void ChangeStreet(string street, string houseNo)
        {
            this.RaiseEvent(new AddressEvents.StreetChanged(this.State.Id, street, houseNo));
        }

        public void ChangePostalCode(string postalCode)
        {
            this.RaiseEvent(new AddressEvents.PostalCodeChanged(this.State.Id, postalCode));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new AddressEvents.NoteChanged(this.State.Id, note));
        }

        #endregion
    }
}
