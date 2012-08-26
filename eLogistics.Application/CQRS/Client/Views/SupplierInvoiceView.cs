using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class SupplierInvoiceView : SupplierInvoiceViewBase
    {
        public SupplierInvoiceView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(SupplierInvoiceEvents.Created message)
        {
            SupplierInvoiceDto dto = this.Load(message.SupplierInvoiceId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new SupplierInvoiceDto();
            dto.SupplierInvoiceId = message.SupplierInvoiceId;
            dto.SupplierId = message.SupplierId;
            this.Save(dto);
        }

        public override void Handle(SupplierInvoiceEvents.InvoiceNoChanged message)
        {
            SupplierInvoiceDto dto = this.Load(message.SupplierInvoiceId);
            dto.InvoiceNo = message.InvoiceNo;
            this.Save(dto);
        }

        public override void Handle(SupplierInvoiceEvents.InvoiceDateChanged message)
        {
            SupplierInvoiceDto dto = this.Load(message.SupplierInvoiceId);
            dto.InvoiceDate = message.InvoiceDate;
            this.Save(dto);
        }

        public override void Handle(SupplierInvoiceEvents.InvoicePaymentDateChanged message)
        {
            SupplierInvoiceDto dto = this.Load(message.SupplierInvoiceId);
            dto.PaymentDate = message.PaymentDate;
            this.Save(dto);
        }

        public override void Handle(SupplierInvoiceEvents.NoteChanged message)
        {
            SupplierInvoiceDto dto = this.Load(message.SupplierInvoiceId);
            dto.Note = message.Note;
            this.Save(dto);
        }

    }
}
