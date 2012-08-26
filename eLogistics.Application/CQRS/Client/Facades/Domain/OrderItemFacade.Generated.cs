using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IOrderItemFacade
    {
        GetOrderItemListResponse GetOrderItemList(GetOrderItemListRequest request);
        GetOrderItemResponse GetOrderItem(GetOrderItemRequest request);
    }

    public partial class OrderItemFacade : ReadModelFacade, IOrderItemFacade
    {
    public OrderItemFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetOrderItemListResponse GetOrderItemList(GetOrderItemListRequest request)
        {
            OrderItemView view = new OrderItemView(ObjectFactory.Create<IReadModelStore>());
            List<OrderItemDto> list = view.GetList(request.Filter);
            GetOrderItemListResponse response = new GetOrderItemListResponse();
            response.OrderItemList = list;
            return response;

        }

        public GetOrderItemResponse GetOrderItem(GetOrderItemRequest request)
        {
            OrderItemView view = new OrderItemView(ObjectFactory.Create<IReadModelStore>());
            OrderItemDto dto = view.Load(request.OrderItemId);
            GetOrderItemResponse response = new GetOrderItemResponse();
            response.OrderItem = dto;
            return response;

        }

    }
}
