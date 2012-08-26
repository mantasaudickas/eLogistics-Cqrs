using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetSalesArticleListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetSalesArticleListResponse : ResponseMessage
    {
        [DataMember] public List<SalesArticleDto> SalesArticleList { get; set; }
    }

    [DataContract]
    public partial class GetSalesArticleRequest : RequestMessage
    {
        [DataMember] public Guid SalesArticleId;
    }

    [DataContract]
    public partial class GetSalesArticleResponse : ResponseMessage
    {
        [DataMember] public SalesArticleDto SalesArticle;
    }

}
