using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class BankDto : DataTransferObject
    {
        public BankDto()
        {
        }

        [DataMember] public Guid BankId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Code { get; set; }
        [DataMember] public string SwiftCode { get; set; }
        [DataMember] public string Note { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = BankId;
            descr.Properties["BankId"] = BankId;
            descr.Properties["Name"] = Name;
            descr.Properties["Code"] = Code;
            descr.Properties["SwiftCode"] = SwiftCode;
            descr.Properties["Note"] = Note;
            return descr;
        }
    }
}
