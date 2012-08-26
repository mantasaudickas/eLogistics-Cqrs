using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class PaymentTypeViewBase : View<PaymentTypeDto>
        , IHandler<PaymentTypeEvents.Created>
        , IHandler<PaymentTypeEvents.NameChanged>
        , IHandler<PaymentTypeEvents.IsCreditChanged>
        , IHandler<PaymentTypeEvents.Deleted>

    {
        protected PaymentTypeViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(PaymentTypeEvents.Created message);
        public abstract void Handle(PaymentTypeEvents.NameChanged message);
        public abstract void Handle(PaymentTypeEvents.IsCreditChanged message);
        public abstract void Handle(PaymentTypeEvents.Deleted message);
    }
}
