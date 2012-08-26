using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class OrderItem : AggregateRoot<OrderItemState>
    {
        public OrderItem()
        {
        }

        public void Create(Guid orderItemId, Guid orderId)
        {
            this.RaiseEvent(new OrderItemEvents.Created(orderItemId, orderId));
        }

        public void ChangeSalesArticle(Guid salesArticleId)
        {
            if (this.State.IsServiceItem)
                throw new NotSupportedException("Item is marked as a service. It cannot have sales article assigned!");

            this.RaiseEvent(new OrderItemEvents.SalesArticleChanged(this.State.Id, salesArticleId));
        }

        public void ChangeQuantity(int quantity)
        {
            this.RaiseEvent(new OrderItemEvents.QuantityChanged(this.State.Id, quantity));
        }

        public void ChangePrice(decimal price, byte vat)
        {
            this.RaiseEvent(new OrderItemEvents.PriceChanged(this.State.Id, price, vat));
        }

        public void ChangeDiscount(DiscountType discountType, decimal discountValue)
        {
            this.RaiseEvent(new OrderItemEvents.DiscountChanged(this.State.Id, discountType, discountValue));
        }

        public void ChangeName(string name)
        {
            if (!this.State.IsServiceItem)
                throw new NotSupportedException("Item is not marked as a service. Only service items can have custom name.");

            this.RaiseEvent(new OrderItemEvents.NameChanged(this.State.Id, name));
        }

        public void MarkItemAsService()
        {
            if (!Guid.Empty.Equals(this.State.SalesArticleId))
                throw new NotSupportedException("Item cannot be marked as a service when it has sales article assigned!");

            if (!this.State.IsServiceItem)
                this.RaiseEvent(new OrderItemEvents.ItemMarkedAsService(this.State.Id));
        }

        public void UnmarkItemAsService()
        {
            if (this.State.IsServiceItem)
                this.RaiseEvent(new OrderItemEvents.ItemMarkedAsService(this.State.Id));
        }
    }
}
