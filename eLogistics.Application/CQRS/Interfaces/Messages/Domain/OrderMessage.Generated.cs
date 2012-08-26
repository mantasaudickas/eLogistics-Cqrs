using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetOrderListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetOrderListResponse : ResponseMessage
    {
        [DataMember] public List<OrderDto> OrderList { get; set; }
    }

    [DataContract]
    public partial class GetOrderRequest : RequestMessage
    {
        [DataMember] public Guid OrderId;
    }

    [DataContract]
    public partial class GetOrderResponse : ResponseMessage
    {
        [DataMember] public OrderDto Order;
    }

}
