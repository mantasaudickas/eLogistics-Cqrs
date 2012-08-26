using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class SupplierInvoiceViewBase : View<SupplierInvoiceDto>
        , IHandler<SupplierInvoiceEvents.Created>
        , IHandler<SupplierInvoiceEvents.InvoiceNoChanged>
        , IHandler<SupplierInvoiceEvents.InvoiceDateChanged>
        , IHandler<SupplierInvoiceEvents.InvoicePaymentDateChanged>
        , IHandler<SupplierInvoiceEvents.NoteChanged>

    {
        protected SupplierInvoiceViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(SupplierInvoiceEvents.Created message);
        public abstract void Handle(SupplierInvoiceEvents.InvoiceNoChanged message);
        public abstract void Handle(SupplierInvoiceEvents.InvoiceDateChanged message);
        public abstract void Handle(SupplierInvoiceEvents.InvoicePaymentDateChanged message);
        public abstract void Handle(SupplierInvoiceEvents.NoteChanged message);
    }
}
