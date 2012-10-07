using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class CityView : CityViewBase
    {
        public CityView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(CityEvents.Created message)
        {
            CityDto dto = this.Load(message.CityId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new CityDto();
            dto.CityId = message.CityId;
            this.Save(dto);
        }

        public override void Handle(CityEvents.CountryChanged message)
        {
            CityDto dto = this.Load(message.CityId);
            dto.CountryId = message.CountryId;
            this.Save(dto);
        }

        public override void Handle(CityEvents.NameChanged message)
        {
            CityDto dto = this.Load(message.CityId);
            dto.Name = message.Name;
            this.Save(dto);
        }

    }
}
