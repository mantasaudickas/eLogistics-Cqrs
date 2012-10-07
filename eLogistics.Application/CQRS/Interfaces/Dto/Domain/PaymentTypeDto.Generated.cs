using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class PaymentTypeDto : DataTransferObject
    {
        public PaymentTypeDto()
        {
        }

        [DataMember] public Guid PaymentTypeId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public bool IsCredit { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = PaymentTypeId;
            descr.Properties["PaymentTypeId"] = PaymentTypeId;
            descr.Properties["Name"] = Name;
            descr.Properties["IsCredit"] = IsCredit;
            return descr;
        }
    }
}
