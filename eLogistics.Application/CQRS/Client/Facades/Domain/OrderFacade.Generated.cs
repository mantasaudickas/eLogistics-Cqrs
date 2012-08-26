using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IOrderFacade
    {
        GetOrderListResponse GetOrderList(GetOrderListRequest request);
        GetOrderResponse GetOrder(GetOrderRequest request);
    }

    public partial class OrderFacade : ReadModelFacade, IOrderFacade
    {
    public OrderFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetOrderListResponse GetOrderList(GetOrderListRequest request)
        {
            OrderView view = new OrderView(ObjectFactory.Create<IReadModelStore>());
            List<OrderDto> list = view.GetList(request.Filter);
            GetOrderListResponse response = new GetOrderListResponse();
            response.OrderList = list;
            return response;

        }

        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            OrderView view = new OrderView(ObjectFactory.Create<IReadModelStore>());
            OrderDto dto = view.Load(request.OrderId);
            GetOrderResponse response = new GetOrderResponse();
            response.Order = dto;
            return response;

        }

    }
}
