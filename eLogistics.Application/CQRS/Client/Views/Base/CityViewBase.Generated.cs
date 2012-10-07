using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class CityViewBase : View<CityDto>
        , IHandler<CityEvents.Created>
        , IHandler<CityEvents.CountryChanged>
        , IHandler<CityEvents.NameChanged>

    {
        protected CityViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(CityEvents.Created message);
        public abstract void Handle(CityEvents.CountryChanged message);
        public abstract void Handle(CityEvents.NameChanged message);
    }
}
