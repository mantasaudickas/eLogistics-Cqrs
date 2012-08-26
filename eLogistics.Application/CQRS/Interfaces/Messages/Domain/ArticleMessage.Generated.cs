using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetArticleListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetArticleListResponse : ResponseMessage
    {
        [DataMember] public List<ArticleDto> ArticleList { get; set; }
    }

    [DataContract]
    public partial class GetArticleRequest : RequestMessage
    {
        [DataMember] public Guid ArticleId;
    }

    [DataContract]
    public partial class GetArticleResponse : ResponseMessage
    {
        [DataMember] public ArticleDto Article;
    }

}
