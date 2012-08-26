using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IArticleFacade
    {
        GetArticleListResponse GetArticleList(GetArticleListRequest request);
        GetArticleResponse GetArticle(GetArticleRequest request);
    }

    public partial class ArticleFacade : ReadModelFacade, IArticleFacade
    {
    public ArticleFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetArticleListResponse GetArticleList(GetArticleListRequest request)
        {
            ArticleView view = new ArticleView(ObjectFactory.Create<IReadModelStore>());
            List<ArticleDto> list = view.GetList(request.Filter);
            GetArticleListResponse response = new GetArticleListResponse();
            response.ArticleList = list;
            return response;

        }

        public GetArticleResponse GetArticle(GetArticleRequest request)
        {
            ArticleView view = new ArticleView(ObjectFactory.Create<IReadModelStore>());
            ArticleDto dto = view.Load(request.ArticleId);
            GetArticleResponse response = new GetArticleResponse();
            response.Article = dto;
            return response;

        }

    }
}
