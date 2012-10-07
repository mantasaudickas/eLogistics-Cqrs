using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetAddressListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
        [DataMember] public Owner Owner { get; set; }
        [DataMember] public Guid OwnerId { get; set; }
    }

    [DataContract]
    public partial class GetAddressListResponse : ResponseMessage
    {
        [DataMember] public List<AddressDto> AddressList { get; set; }
    }

    [DataContract]
    public partial class GetAddressRequest : RequestMessage
    {
        [DataMember] public Guid AddressId;
    }

    [DataContract]
    public partial class GetAddressResponse : ResponseMessage
    {
        [DataMember] public AddressDto Address;
    }

}
