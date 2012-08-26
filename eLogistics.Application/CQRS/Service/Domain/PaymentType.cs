using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class PaymentType : AggregateRoot<PaymentTypeState>
    {
        #region Constructor

        public PaymentType()
        {
        }

        #endregion

        #region Change Members

        public void Create(Guid paymentTypeId)
        {
            this.RaiseEvent(new PaymentTypeEvents.Created(paymentTypeId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new PaymentTypeEvents.NameChanged(this.State.Id, name));
        }

        public void ChangeIsCredit(bool isCredit)
        {
            this.RaiseEvent(new PaymentTypeEvents.IsCreditChanged(this.State.Id, isCredit));
        }

        public void Delete()
        {
            this.RaiseEvent(new PaymentTypeEvents.Deleted(this.State.Id));
        }

        #endregion
    }
}
