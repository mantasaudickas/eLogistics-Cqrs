using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class AddressView : AddressViewBase
    {
        public AddressView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(AddressEvents.Created message)
        {
            AddressDto dto = this.Load(message.AddressId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new AddressDto();
            dto.AddressId = message.AddressId;
            dto.Owner = message.Owner;
            dto.OwnerId = message.OwnerId;
            this.Save(dto);
        }

        public override void Handle(AddressEvents.CountryChanged message)
        {
            AddressDto dto = this.Load(message.AddressId);
            dto.CountryId = message.CountryId;
            this.Save(dto);
        }

        public override void Handle(AddressEvents.CityChanged message)
        {
            AddressDto dto = this.Load(message.AddressId);
            dto.City = message.City;
            this.Save(dto);
        }

        public override void Handle(AddressEvents.StreetChanged message)
        {
            AddressDto dto = this.Load(message.AddressId);
            dto.Street = message.Street;
            dto.HouseNo = message.HouseNo;
            this.Save(dto);
        }

        public override void Handle(AddressEvents.PostalCodeChanged message)
        {
            AddressDto dto = this.Load(message.AddressId);
            dto.PostalCode = message.PostalCode;
            this.Save(dto);
        }

        public override void Handle(AddressEvents.NoteChanged message)
        {
            AddressDto dto = this.Load(message.AddressId);
            dto.Note = message.Note;
            this.Save(dto);
        }

    }
}
