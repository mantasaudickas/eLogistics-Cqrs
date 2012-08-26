using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IArticleVariantFacade
    {
        GetArticleVariantListResponse GetArticleVariantList(GetArticleVariantListRequest request);
        GetArticleVariantResponse GetArticleVariant(GetArticleVariantRequest request);
    }

    public partial class ArticleVariantFacade : ReadModelFacade, IArticleVariantFacade
    {
    public ArticleVariantFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetArticleVariantListResponse GetArticleVariantList(GetArticleVariantListRequest request)
        {
            ArticleVariantView view = new ArticleVariantView(ObjectFactory.Create<IReadModelStore>());
            List<ArticleVariantDto> list = view.GetList(request.Filter);
            GetArticleVariantListResponse response = new GetArticleVariantListResponse();
            response.ArticleVariantList = list;
            return response;

        }

        public GetArticleVariantResponse GetArticleVariant(GetArticleVariantRequest request)
        {
            ArticleVariantView view = new ArticleVariantView(ObjectFactory.Create<IReadModelStore>());
            ArticleVariantDto dto = view.Load(request.ArticleVariantId);
            GetArticleVariantResponse response = new GetArticleVariantResponse();
            response.ArticleVariant = dto;
            return response;

        }

    }
}
