using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class OrderItemViewBase : View<OrderItemDto>
        , IHandler<OrderItemEvents.Created>
        , IHandler<OrderItemEvents.SalesArticleChanged>
        , IHandler<OrderItemEvents.QuantityChanged>
        , IHandler<OrderItemEvents.PriceChanged>
        , IHandler<OrderItemEvents.DiscountChanged>
        , IHandler<OrderItemEvents.NameChanged>
        , IHandler<OrderItemEvents.ItemMarkedAsService>
        , IHandler<OrderItemEvents.ItemUnmarkedAsService>

    {
        protected OrderItemViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(OrderItemEvents.Created message);
        public abstract void Handle(OrderItemEvents.SalesArticleChanged message);
        public abstract void Handle(OrderItemEvents.QuantityChanged message);
        public abstract void Handle(OrderItemEvents.PriceChanged message);
        public abstract void Handle(OrderItemEvents.DiscountChanged message);
        public abstract void Handle(OrderItemEvents.NameChanged message);
        public abstract void Handle(OrderItemEvents.ItemMarkedAsService message);
        public abstract void Handle(OrderItemEvents.ItemUnmarkedAsService message);
    }
}
