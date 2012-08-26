using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class ArticleVariantViewBase : View<ArticleVariantDto>
        , IHandler<ArticleVariantEvents.Created>
        , IHandler<ArticleVariantEvents.PriceChanged>
        , IHandler<ArticleVariantEvents.BarcodeAdded>
        , IHandler<ArticleVariantEvents.BarcodeRemoved>
        , IHandler<ArticleVariantEvents.ArticleAttributeAdded>
        , IHandler<ArticleVariantEvents.ArticleAttributeRemoved>

    {
        protected ArticleVariantViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(ArticleVariantEvents.Created message);
        public abstract void Handle(ArticleVariantEvents.PriceChanged message);
        public abstract void Handle(ArticleVariantEvents.BarcodeAdded message);
        public abstract void Handle(ArticleVariantEvents.BarcodeRemoved message);
        public abstract void Handle(ArticleVariantEvents.ArticleAttributeAdded message);
        public abstract void Handle(ArticleVariantEvents.ArticleAttributeRemoved message);
    }
}
