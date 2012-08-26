using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Order : AggregateRoot<OrderState>
    {
        public Order()
        {
        }

        public void Create(Guid orderId)
        {
            this.RaiseEvent(new OrderEvents.Created(orderId));
        }

        public void ChangeCustomer(Guid customerId)
        {
            this.RaiseEvent(new OrderEvents.CustomerChanged(this.State.Id, customerId));
        }
    }
}
