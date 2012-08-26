using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class SupplierInvoiceEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public Guid SupplierId { get; private set; }

            public Created(Guid supplierInvoiceId, Guid supplierId) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                SupplierId = supplierId;
            }
        }

        [DataContract]
        public class InvoiceNoChanged : Event
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public string InvoiceNo { get; private set; }

            public InvoiceNoChanged(Guid supplierInvoiceId, string invoiceNo) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                InvoiceNo = invoiceNo;
            }
        }

        [DataContract]
        public class InvoiceDateChanged : Event
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public DateTime InvoiceDate { get; private set; }

            public InvoiceDateChanged(Guid supplierInvoiceId, DateTime invoiceDate) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                InvoiceDate = invoiceDate;
            }
        }

        [DataContract]
        public class InvoicePaymentDateChanged : Event
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public DateTime PaymentDate { get; private set; }

            public InvoicePaymentDateChanged(Guid supplierInvoiceId, DateTime paymentDate) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                PaymentDate = paymentDate;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid supplierInvoiceId, string note) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                Note = note;
            }
        }

    }
}
