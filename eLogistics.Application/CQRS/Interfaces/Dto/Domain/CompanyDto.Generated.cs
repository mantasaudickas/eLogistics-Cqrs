using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class CompanyDto : DataTransferObject
    {
        public CompanyDto()
        {
        }

        [DataMember] public Guid CompanyId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string CompanyCode { get; set; }
        [DataMember] public string CompanyVatCode { get; set; }
        [DataMember] public string ContactPersonName { get; set; }
        [DataMember] public string ContactPhoneNo { get; set; }
        [DataMember] public string Note { get; set; }
        [DataMember] public List<Guid> AddressIdList { get; set; }
        [DataMember] public List<Guid> CommunicationIdList { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = CompanyId;
            descr.Properties["CompanyId"] = CompanyId;
            descr.Properties["Name"] = Name;
            descr.Properties["CompanyCode"] = CompanyCode;
            descr.Properties["CompanyVatCode"] = CompanyVatCode;
            descr.Properties["ContactPersonName"] = ContactPersonName;
            descr.Properties["ContactPhoneNo"] = ContactPhoneNo;
            descr.Properties["Note"] = Note;
            descr.Properties["AddressId"] = AddressIdList;
            descr.Properties["CommunicationId"] = CommunicationIdList;
            return descr;
        }
    }
}
