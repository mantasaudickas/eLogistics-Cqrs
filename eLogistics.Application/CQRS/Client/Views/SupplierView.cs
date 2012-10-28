using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class SupplierView : SupplierViewBase
    {
        public SupplierView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(SupplierEvents.Created message)
        {
            SupplierDto dto = this.Load(message.SupplierId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new SupplierDto();
            dto.SupplierId = message.SupplierId;
            this.Save(dto);
        }

        public override void Handle(SupplierEvents.NameChanged message)
        {
            SupplierDto dto = this.Load(message.SupplierId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(SupplierEvents.CompanyChanged message)
        {
            SupplierDto dto = this.Load(message.SupplierId);
            dto.CompanyId = message.CompanyId;
            this.Save(dto);
        }

        public override void Handle(SupplierEvents.NoteChanged message)
        {
            SupplierDto dto = this.Load(message.SupplierId);
            dto.Note = message.Note;
            this.Save(dto);
        }

        public override void Handle(SupplierEvents.BankAccountAdded message)
        {
            SupplierDto dto = this.Load(message.SupplierId);
            dto.BankAccountList.Add(message.BankAccount);
            this.Save(dto);
        }

        public override void Handle(SupplierEvents.BankAccountRemoved message)
        {
            SupplierDto dto = this.Load(message.SupplierId);
            dto.BankAccountList.Remove(message.BankAccount);
            this.Save(dto);
        }

    }
}
