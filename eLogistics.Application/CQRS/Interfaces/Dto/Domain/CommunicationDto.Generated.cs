using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class CommunicationDto : DataTransferObject
    {
        public CommunicationDto()
        {
        }

        [DataMember] public Guid CommunicationId { get; set; }
        [DataMember] public Owner Owner { get; set; }
        [DataMember] public Guid OwnerId { get; set; }
        [DataMember] public CommunicationType CommunicationType { get; set; }
        [DataMember] public string Value { get; set; }
        [DataMember] public string Note { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = CommunicationId;
            descr.Properties["CommunicationId"] = CommunicationId;
            descr.Properties["Owner"] = Owner;
            descr.Properties["OwnerId"] = OwnerId;
            descr.Properties["CommunicationType"] = CommunicationType;
            descr.Properties["Value"] = Value;
            descr.Properties["Note"] = Note;
            return descr;
        }
    }
}
