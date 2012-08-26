using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class CustomerDto : DataTransferObject
    {
        public CustomerDto()
        {
        }

        [DataMember] public Guid CustomerId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public Guid CompanyId { get; set; }
        [DataMember] public string Note { get; set; }
        [DataMember] public List<BankAccount> BankAccountList { get; set; }
        [DataMember] public List<Guid> PaymentTypeIdList { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = CustomerId;
            descr.Properties["CustomerId"] = CustomerId;
            descr.Properties["Name"] = Name;
            descr.Properties["CompanyId"] = CompanyId;
            descr.Properties["Note"] = Note;
            descr.Properties["BankAccount"] = BankAccountList;
            descr.Properties["PaymentTypeId"] = PaymentTypeIdList;
            return descr;
        }
    }
}
