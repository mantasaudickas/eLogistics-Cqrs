using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class OrderItemView : OrderItemViewBase
    {
        public OrderItemView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(OrderItemEvents.Created message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new OrderItemDto();
            dto.OrderItemId = message.OrderItemId;
            dto.OrderId = message.OrderId;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.SalesArticleChanged message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.SalesArticleId = message.SalesArticleId;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.QuantityChanged message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.Quantity = message.Quantity;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.PriceChanged message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.Price = message.Price;
            dto.Vat = message.Vat;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.DiscountChanged message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.DiscountType = message.DiscountType;
            dto.DiscountValue = message.DiscountValue;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.NameChanged message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.ItemMarkedAsService message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.IsServiceItem = true;
            this.Save(dto);
        }

        public override void Handle(OrderItemEvents.ItemUnmarkedAsService message)
        {
            OrderItemDto dto = this.Load(message.OrderItemId);
            dto.IsServiceItem = false;
            this.Save(dto);
        }

    }
}
