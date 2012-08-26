using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class OrderItemState : State
    {
        public OrderItemState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return OrderItemId; } }
        public Guid OrderItemId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid SalesArticleId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public byte Vat { get; private set; }
        public DiscountType DiscountType { get; private set; }
        public decimal DiscountValue { get; private set; }
        public string Name { get; private set; }
        public bool IsServiceItem { get; private set; }

        public void When(OrderItemEvents.Created e)
        {
            this.OrderItemId = e.OrderItemId;
            this.OrderId = e.OrderId;
        }

        public void When(OrderItemEvents.SalesArticleChanged e)
        {
            this.SalesArticleId = e.SalesArticleId;
        }

        public void When(OrderItemEvents.QuantityChanged e)
        {
            this.Quantity = e.Quantity;
        }

        public void When(OrderItemEvents.PriceChanged e)
        {
            this.Price = e.Price;
            this.Vat = e.Vat;
        }

        public void When(OrderItemEvents.DiscountChanged e)
        {
            this.DiscountType = e.DiscountType;
            this.DiscountValue = e.DiscountValue;
        }

        public void When(OrderItemEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(OrderItemEvents.ItemMarkedAsService e)
        {
            this.IsServiceItem = true;
        }

        public void When(OrderItemEvents.ItemUnmarkedAsService e)
        {
            this.IsServiceItem = false;
        }

    }
}
