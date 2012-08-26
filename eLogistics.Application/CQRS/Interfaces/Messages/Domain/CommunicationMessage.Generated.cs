using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetCommunicationListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetCommunicationListResponse : ResponseMessage
    {
        [DataMember] public List<CommunicationDto> CommunicationList { get; set; }
    }

    [DataContract]
    public partial class GetCommunicationRequest : RequestMessage
    {
        [DataMember] public Guid CommunicationId;
    }

    [DataContract]
    public partial class GetCommunicationResponse : ResponseMessage
    {
        [DataMember] public CommunicationDto Communication;
    }

}
