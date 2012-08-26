using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetArticleVariantListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetArticleVariantListResponse : ResponseMessage
    {
        [DataMember] public List<ArticleVariantDto> ArticleVariantList { get; set; }
    }

    [DataContract]
    public partial class GetArticleVariantRequest : RequestMessage
    {
        [DataMember] public Guid ArticleVariantId;
    }

    [DataContract]
    public partial class GetArticleVariantResponse : ResponseMessage
    {
        [DataMember] public ArticleVariantDto ArticleVariant;
    }

}
