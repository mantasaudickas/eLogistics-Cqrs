using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetCountryListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetCountryListResponse : ResponseMessage
    {
        [DataMember] public List<CountryDto> CountryList { get; set; }
    }

    [DataContract]
    public partial class GetCountryRequest : RequestMessage
    {
        [DataMember] public Guid CountryId;
    }

    [DataContract]
    public partial class GetCountryResponse : ResponseMessage
    {
        [DataMember] public CountryDto Country;
    }

}
