using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class OrderHandler : CommandHandler<Order>
    {
        public OrderHandler(IRepository<Order> repository) : base(repository)
        {
        }

        public void Handle(OrderCommands.Create message)
        {
            Order item = this.Repository.GetById(message.Id);
            item.Create(message.OrderId);
            this.Repository.Save(item);
        }

        public void Handle(OrderCommands.ChangeCustomer message)
        {
            Order item = this.Repository.GetById(message.Id);
            item.ChangeCustomer(message.CustomerId);
            this.Repository.Save(item);
        }

    }
}
