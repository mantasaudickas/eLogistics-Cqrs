using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class OrderState : State
    {
        public OrderState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return OrderId; } }
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }

        public void When(OrderEvents.Created e)
        {
            this.OrderId = e.OrderId;
        }

        public void When(OrderEvents.CustomerChanged e)
        {
            this.CustomerId = e.CustomerId;
        }

    }
}
