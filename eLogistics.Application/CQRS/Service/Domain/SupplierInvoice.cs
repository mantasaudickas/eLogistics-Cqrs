using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class SupplierInvoice : AggregateRoot<SupplierInvoiceState>
    {
        public SupplierInvoice()
        {
        }

        public void Create(Guid supplierInvoiceId, Guid supplierId)
        {
            this.RaiseEvent(new SupplierInvoiceEvents.Created(supplierInvoiceId, supplierId));
        }

        public void ChangeInvoiceNo(string invoiceNo)
        {
            this.RaiseEvent(new SupplierInvoiceEvents.InvoiceNoChanged(this.State.Id, invoiceNo));
        }

        public void ChangeInvoiceDate(DateTime invoiceDate)
        {
            this.RaiseEvent(new SupplierInvoiceEvents.InvoiceDateChanged(this.State.Id, invoiceDate));
        }

        public void ChangeInvoicePaymentDate(DateTime paymentDate)
        {
            this.RaiseEvent(new SupplierInvoiceEvents.InvoicePaymentDateChanged(this.State.Id, paymentDate));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new SupplierInvoiceEvents.NoteChanged(this.State.Id, note));
        }
    }
}
