using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetBankListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetBankListResponse : ResponseMessage
    {
        [DataMember] public List<BankDto> BankList { get; set; }
    }

    [DataContract]
    public partial class GetBankRequest : RequestMessage
    {
        [DataMember] public Guid BankId;
    }

    [DataContract]
    public partial class GetBankResponse : ResponseMessage
    {
        [DataMember] public BankDto Bank;
    }

}
