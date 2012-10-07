using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetCityListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetCityListResponse : ResponseMessage
    {
        [DataMember] public List<CityDto> CityList { get; set; }
    }

    [DataContract]
    public partial class GetCityRequest : RequestMessage
    {
        [DataMember] public Guid CityId;
    }

    [DataContract]
    public partial class GetCityResponse : ResponseMessage
    {
        [DataMember] public CityDto City;
    }

}
