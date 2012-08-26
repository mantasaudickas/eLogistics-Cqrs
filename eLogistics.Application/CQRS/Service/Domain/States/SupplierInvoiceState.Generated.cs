using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class SupplierInvoiceState : State
    {
        public SupplierInvoiceState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return SupplierInvoiceId; } }
        public Guid SupplierInvoiceId { get; private set; }
        public Guid SupplierId { get; private set; }
        public string InvoiceNo { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string Note { get; private set; }

        public void When(SupplierInvoiceEvents.Created e)
        {
            this.SupplierInvoiceId = e.SupplierInvoiceId;
            this.SupplierId = e.SupplierId;
        }

        public void When(SupplierInvoiceEvents.InvoiceNoChanged e)
        {
            this.InvoiceNo = e.InvoiceNo;
        }

        public void When(SupplierInvoiceEvents.InvoiceDateChanged e)
        {
            this.InvoiceDate = e.InvoiceDate;
        }

        public void When(SupplierInvoiceEvents.InvoicePaymentDateChanged e)
        {
            this.PaymentDate = e.PaymentDate;
        }

        public void When(SupplierInvoiceEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

    }
}
