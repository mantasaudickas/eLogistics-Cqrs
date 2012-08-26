using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetSupplierListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetSupplierListResponse : ResponseMessage
    {
        [DataMember] public List<SupplierDto> SupplierList { get; set; }
    }

    [DataContract]
    public partial class GetSupplierRequest : RequestMessage
    {
        [DataMember] public Guid SupplierId;
    }

    [DataContract]
    public partial class GetSupplierResponse : ResponseMessage
    {
        [DataMember] public SupplierDto Supplier;
    }

}
