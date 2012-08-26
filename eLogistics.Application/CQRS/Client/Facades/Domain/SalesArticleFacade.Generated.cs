using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ISalesArticleFacade
    {
        GetSalesArticleListResponse GetSalesArticleList(GetSalesArticleListRequest request);
        GetSalesArticleResponse GetSalesArticle(GetSalesArticleRequest request);
    }

    public partial class SalesArticleFacade : ReadModelFacade, ISalesArticleFacade
    {
    public SalesArticleFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetSalesArticleListResponse GetSalesArticleList(GetSalesArticleListRequest request)
        {
            SalesArticleView view = new SalesArticleView(ObjectFactory.Create<IReadModelStore>());
            List<SalesArticleDto> list = view.GetList(request.Filter);
            GetSalesArticleListResponse response = new GetSalesArticleListResponse();
            response.SalesArticleList = list;
            return response;

        }

        public GetSalesArticleResponse GetSalesArticle(GetSalesArticleRequest request)
        {
            SalesArticleView view = new SalesArticleView(ObjectFactory.Create<IReadModelStore>());
            SalesArticleDto dto = view.Load(request.SalesArticleId);
            GetSalesArticleResponse response = new GetSalesArticleResponse();
            response.SalesArticle = dto;
            return response;

        }

    }
}
