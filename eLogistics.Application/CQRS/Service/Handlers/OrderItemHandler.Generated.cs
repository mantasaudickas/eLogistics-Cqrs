using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class OrderItemHandler : CommandHandler<OrderItem>
    {
        public OrderItemHandler(IRepository<OrderItem> repository) : base(repository)
        {
        }

        public void Handle(OrderItemCommands.Create message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.Create(message.OrderItemId,message.OrderId);
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.ChangeSalesArticle message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.ChangeSalesArticle(message.SalesArticleId);
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.ChangeQuantity message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.ChangeQuantity(message.Quantity);
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.ChangePrice message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.ChangePrice(message.Price,message.Vat);
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.ChangeDiscount message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.ChangeDiscount(message.DiscountType,message.DiscountValue);
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.ChangeName message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.MarkItemAsService message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.MarkItemAsService();
            this.Repository.Save(item);
        }

        public void Handle(OrderItemCommands.UnmarkItemAsService message)
        {
            OrderItem item = this.Repository.GetById(message.Id);
            item.UnmarkItemAsService();
            this.Repository.Save(item);
        }

    }
}
