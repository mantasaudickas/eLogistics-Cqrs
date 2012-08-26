using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class SupplierDto : DataTransferObject
    {
        public SupplierDto()
        {
        }

        [DataMember] public Guid SupplierId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public Guid CompanyId { get; set; }
        [DataMember] public string Note { get; set; }
        [DataMember] public List<BankAccount> BankAccountList { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = SupplierId;
            descr.Properties["SupplierId"] = SupplierId;
            descr.Properties["Name"] = Name;
            descr.Properties["CompanyId"] = CompanyId;
            descr.Properties["Note"] = Note;
            descr.Properties["BankAccount"] = BankAccountList;
            return descr;
        }
    }
}
