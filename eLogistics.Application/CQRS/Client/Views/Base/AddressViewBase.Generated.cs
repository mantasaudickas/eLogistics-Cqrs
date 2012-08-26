using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class AddressViewBase : View<AddressDto>
        , IHandler<AddressEvents.Created>
        , IHandler<AddressEvents.CountryChanged>
        , IHandler<AddressEvents.CityChanged>
        , IHandler<AddressEvents.StreetChanged>
        , IHandler<AddressEvents.PostalCodeChanged>
        , IHandler<AddressEvents.NoteChanged>

    {
        protected AddressViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(AddressEvents.Created message);
        public abstract void Handle(AddressEvents.CountryChanged message);
        public abstract void Handle(AddressEvents.CityChanged message);
        public abstract void Handle(AddressEvents.StreetChanged message);
        public abstract void Handle(AddressEvents.PostalCodeChanged message);
        public abstract void Handle(AddressEvents.NoteChanged message);
    }
}
