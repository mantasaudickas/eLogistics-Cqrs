using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class City : AggregateRoot<CityState>
    {
        public void Create(Guid cityId)
        {
            this.RaiseEvent(new CityEvents.Created(cityId));
        }

        public void ChangeCountry(Guid countryId)
        {
            this.RaiseEvent(new CityEvents.CountryChanged(this.State.Id, countryId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new CityEvents.NameChanged(this.State.Id, name));
        }

    }
}
