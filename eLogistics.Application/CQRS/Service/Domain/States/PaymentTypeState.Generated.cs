using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class PaymentTypeState : State
    {
        public PaymentTypeState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return PaymentTypeId; } }
        public Guid PaymentTypeId { get; private set; }
        public string Name { get; private set; }
        public bool IsCredit { get; private set; }

        public void When(PaymentTypeEvents.Created e)
        {
            this.PaymentTypeId = e.PaymentTypeId;
        }

        public void When(PaymentTypeEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(PaymentTypeEvents.IsCreditChanged e)
        {
            this.IsCredit = e.IsCredit;
        }

        public void When(PaymentTypeEvents.Deleted e)
        {
        }

    }
}
