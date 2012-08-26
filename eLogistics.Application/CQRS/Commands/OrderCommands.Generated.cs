using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class OrderCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid OrderId { get; private set; }

            public Create(Guid orderId) : base(orderId)
            {
                OrderId = orderId;
            }
        }

        [DataContract]
        public class ChangeCustomer : Command
        {
            [DataMember] public Guid OrderId { get; private set; }
            [DataMember] public Guid CustomerId { get; private set; }

            public ChangeCustomer(Guid orderId, Guid customerId) : base(orderId)
            {
                OrderId = orderId;
                CustomerId = customerId;
            }
        }

    }
}
