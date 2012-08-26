using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class SupplierInvoiceCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public Guid SupplierId { get; private set; }

            public Create(Guid supplierInvoiceId, Guid supplierId) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                SupplierId = supplierId;
            }
        }

        [DataContract]
        public class ChangeInvoiceNo : Command
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public string InvoiceNo { get; private set; }

            public ChangeInvoiceNo(Guid supplierInvoiceId, string invoiceNo) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                InvoiceNo = invoiceNo;
            }
        }

        [DataContract]
        public class ChangeInvoiceDate : Command
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public DateTime InvoiceDate { get; private set; }

            public ChangeInvoiceDate(Guid supplierInvoiceId, DateTime invoiceDate) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                InvoiceDate = invoiceDate;
            }
        }

        [DataContract]
        public class ChangeInvoicePaymentDate : Command
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public DateTime PaymentDate { get; private set; }

            public ChangeInvoicePaymentDate(Guid supplierInvoiceId, DateTime paymentDate) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                PaymentDate = paymentDate;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid SupplierInvoiceId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid supplierInvoiceId, string note) : base(supplierInvoiceId)
            {
                SupplierInvoiceId = supplierInvoiceId;
                Note = note;
            }
        }

    }
}
