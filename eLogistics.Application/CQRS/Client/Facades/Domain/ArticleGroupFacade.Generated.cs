using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IArticleGroupFacade
    {
        GetArticleGroupListResponse GetArticleGroupList(GetArticleGroupListRequest request);
        GetArticleGroupResponse GetArticleGroup(GetArticleGroupRequest request);
    }

    public partial class ArticleGroupFacade : ReadModelFacade, IArticleGroupFacade
    {
    public ArticleGroupFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetArticleGroupListResponse GetArticleGroupList(GetArticleGroupListRequest request)
        {
            ArticleGroupView view = new ArticleGroupView(ObjectFactory.Create<IReadModelStore>());
            List<ArticleGroupDto> list = view.GetList(request.Filter);
            GetArticleGroupListResponse response = new GetArticleGroupListResponse();
            response.ArticleGroupList = list;
            return response;

        }

        public GetArticleGroupResponse GetArticleGroup(GetArticleGroupRequest request)
        {
            ArticleGroupView view = new ArticleGroupView(ObjectFactory.Create<IReadModelStore>());
            ArticleGroupDto dto = view.Load(request.ArticleGroupId);
            GetArticleGroupResponse response = new GetArticleGroupResponse();
            response.ArticleGroup = dto;
            return response;

        }

    }
}
