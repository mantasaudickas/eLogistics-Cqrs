using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class CountryView : CountryViewBase
    {
        public CountryView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(CountryEvents.Created message)
        {
            CountryDto dto = this.Load(message.CountryId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new CountryDto();
            dto.CountryId = message.CountryId;
            this.Save(dto);
        }

        public override void Handle(CountryEvents.NameChanged message)
        {
            CountryDto dto = this.Load(message.CountryId);
            dto.Name = message.Name;
            this.Save(dto);
        }

    }
}
