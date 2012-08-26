using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class CountryViewBase : View<CountryDto>
        , IHandler<CountryEvents.Created>
        , IHandler<CountryEvents.NameChanged>

    {
        protected CountryViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(CountryEvents.Created message);
        public abstract void Handle(CountryEvents.NameChanged message);
    }
}
