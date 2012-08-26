using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class CustomerView : CustomerViewBase
    {
        public CustomerView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(CustomerEvents.Created message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new CustomerDto();
            dto.CustomerId = message.CustomerId;
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.NameChanged message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.CompanyAdded message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.CompanyId = message.CompanyId;
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.CompanyRemoved message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.CompanyId = message.CompanyId;
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.NoteChanged message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.Note = message.Note;
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.BankAccountAdded message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.BankAccountList.Add(message.BankAccount);
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.BankAccountRemoved message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.BankAccountList.Remove(message.BankAccount);
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.PaymentTypeAdded message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.PaymentTypeIdList.Add(message.PaymentTypeId);
            this.Save(dto);
        }

        public override void Handle(CustomerEvents.PaymentTypeRemoved message)
        {
            CustomerDto dto = this.Load(message.CustomerId);
            dto.PaymentTypeIdList.Remove(message.PaymentTypeId);
            this.Save(dto);
        }

    }
}
