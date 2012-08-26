using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetSupplierInvoiceListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetSupplierInvoiceListResponse : ResponseMessage
    {
        [DataMember] public List<SupplierInvoiceDto> SupplierInvoiceList { get; set; }
    }

    [DataContract]
    public partial class GetSupplierInvoiceRequest : RequestMessage
    {
        [DataMember] public Guid SupplierInvoiceId;
    }

    [DataContract]
    public partial class GetSupplierInvoiceResponse : ResponseMessage
    {
        [DataMember] public SupplierInvoiceDto SupplierInvoice;
    }

}
