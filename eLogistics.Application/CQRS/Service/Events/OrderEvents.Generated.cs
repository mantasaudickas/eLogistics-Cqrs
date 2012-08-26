using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class OrderEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid OrderId { get; private set; }

            public Created(Guid orderId) : base(orderId)
            {
                OrderId = orderId;
            }
        }

        [DataContract]
        public class CustomerChanged : Event
        {
            [DataMember] public Guid OrderId { get; private set; }
            [DataMember] public Guid CustomerId { get; private set; }

            public CustomerChanged(Guid orderId, Guid customerId) : base(orderId)
            {
                OrderId = orderId;
                CustomerId = customerId;
            }
        }

    }
}
