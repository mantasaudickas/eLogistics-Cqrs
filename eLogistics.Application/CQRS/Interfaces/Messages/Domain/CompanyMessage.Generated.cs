using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetCompanyListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetCompanyListResponse : ResponseMessage
    {
        [DataMember] public List<CompanyDto> CompanyList { get; set; }
    }

    [DataContract]
    public partial class GetCompanyRequest : RequestMessage
    {
        [DataMember] public Guid CompanyId;
    }

    [DataContract]
    public partial class GetCompanyResponse : ResponseMessage
    {
        [DataMember] public CompanyDto Company;
    }

}
