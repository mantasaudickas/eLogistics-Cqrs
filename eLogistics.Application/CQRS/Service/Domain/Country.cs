using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Country : AggregateRoot<CountryState>
    {
        #region Constructor

        public Country()
        {
        }

        #endregion

        #region Change Members

        public void Create(Guid countryId)
        {
            this.RaiseEvent(new CountryEvents.Created(countryId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new CountryEvents.NameChanged(this.State.Id, name));
        }

        #endregion
    }
}
