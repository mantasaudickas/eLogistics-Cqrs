using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetOrderItemListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetOrderItemListResponse : ResponseMessage
    {
        [DataMember] public List<OrderItemDto> OrderItemList { get; set; }
    }

    [DataContract]
    public partial class GetOrderItemRequest : RequestMessage
    {
        [DataMember] public Guid OrderItemId;
    }

    [DataContract]
    public partial class GetOrderItemResponse : ResponseMessage
    {
        [DataMember] public OrderItemDto OrderItem;
    }

}
