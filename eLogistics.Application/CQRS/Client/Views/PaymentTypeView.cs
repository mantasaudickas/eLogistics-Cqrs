using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class PaymentTypeView : PaymentTypeViewBase
    {
        public PaymentTypeView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(PaymentTypeEvents.Created message)
        {
            PaymentTypeDto dto = this.Load(message.PaymentTypeId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new PaymentTypeDto();
            dto.PaymentTypeId = message.PaymentTypeId;
            this.Save(dto);
        }

        public override void Handle(PaymentTypeEvents.NameChanged message)
        {
            PaymentTypeDto dto = this.Load(message.PaymentTypeId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(PaymentTypeEvents.IsCreditChanged message)
        {
            PaymentTypeDto dto = this.Load(message.PaymentTypeId);
            dto.IsCredit = message.IsCredit;
            this.Save(dto);
        }

        public override void Handle(PaymentTypeEvents.Deleted message)
        {
            this.Delete<PaymentTypeDto>(message.PaymentTypeId);
        }
    }
}
