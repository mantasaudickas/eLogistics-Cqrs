using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class OrderView : OrderViewBase
    {
        public OrderView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(OrderEvents.Created message)
        {
            OrderDto dto = this.Load(message.OrderId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new OrderDto();
            dto.OrderId = message.OrderId;
            this.Save(dto);
        }

        public override void Handle(OrderEvents.CustomerChanged message)
        {
            OrderDto dto = this.Load(message.OrderId);
            dto.CustomerId = message.CustomerId;
            this.Save(dto);
        }

    }
}
