using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetPaymentTypeListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetPaymentTypeListResponse : ResponseMessage
    {
        [DataMember] public List<PaymentTypeDto> PaymentTypeList { get; set; }
    }

    [DataContract]
    public partial class GetPaymentTypeRequest : RequestMessage
    {
        [DataMember] public Guid PaymentTypeId;
    }

    [DataContract]
    public partial class GetPaymentTypeResponse : ResponseMessage
    {
        [DataMember] public PaymentTypeDto PaymentType;
    }

}
