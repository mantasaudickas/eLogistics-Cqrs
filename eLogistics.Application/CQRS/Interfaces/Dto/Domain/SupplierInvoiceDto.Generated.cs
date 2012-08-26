using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class SupplierInvoiceDto : DataTransferObject
    {
        public SupplierInvoiceDto()
        {
        }

        [DataMember] public Guid SupplierInvoiceId { get; set; }
        [DataMember] public Guid SupplierId { get; set; }
        [DataMember] public string InvoiceNo { get; set; }
        [DataMember] public DateTime InvoiceDate { get; set; }
        [DataMember] public DateTime PaymentDate { get; set; }
        [DataMember] public string Note { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = SupplierInvoiceId;
            descr.Properties["SupplierInvoiceId"] = SupplierInvoiceId;
            descr.Properties["SupplierId"] = SupplierId;
            descr.Properties["InvoiceNo"] = InvoiceNo;
            descr.Properties["InvoiceDate"] = InvoiceDate;
            descr.Properties["PaymentDate"] = PaymentDate;
            descr.Properties["Note"] = Note;
            return descr;
        }
    }
}
