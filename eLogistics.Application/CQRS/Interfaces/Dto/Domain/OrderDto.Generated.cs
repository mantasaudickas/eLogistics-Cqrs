using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class OrderDto : DataTransferObject
    {
        public OrderDto()
        {
        }

        [DataMember] public Guid OrderId { get; set; }
        [DataMember] public Guid CustomerId { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = OrderId;
            descr.Properties["OrderId"] = OrderId;
            descr.Properties["CustomerId"] = CustomerId;
            return descr;
        }
    }
}
