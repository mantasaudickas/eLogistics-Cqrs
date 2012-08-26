using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class OrderViewBase : View<OrderDto>
        , IHandler<OrderEvents.Created>
        , IHandler<OrderEvents.CustomerChanged>

    {
        protected OrderViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(OrderEvents.Created message);
        public abstract void Handle(OrderEvents.CustomerChanged message);
    }
}
