using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
namespace eLogistics.Application.CQRS.Interfaces.Messages.Domain
{
    [DataContract]
    public partial class GetArticleGroupListRequest : RequestMessage
    {
        [DataMember] public string Filter { get; set; }
    }

    [DataContract]
    public partial class GetArticleGroupListResponse : ResponseMessage
    {
        [DataMember] public List<ArticleGroupDto> ArticleGroupList { get; set; }
    }

    [DataContract]
    public partial class GetArticleGroupRequest : RequestMessage
    {
        [DataMember] public Guid ArticleGroupId;
    }

    [DataContract]
    public partial class GetArticleGroupResponse : ResponseMessage
    {
        [DataMember] public ArticleGroupDto ArticleGroup;
    }

}
