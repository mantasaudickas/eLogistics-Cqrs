using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class SalesArticleViewBase : View<SalesArticleDto>
        , IHandler<SalesArticleEvents.Created>
        , IHandler<SalesArticleEvents.SupplierInvoiceChanged>
        , IHandler<SalesArticleEvents.ArticleVariantChanged>
        , IHandler<SalesArticleEvents.QuantityChanged>
        , IHandler<SalesArticleEvents.PriceChanged>

    {
        protected SalesArticleViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(SalesArticleEvents.Created message);
        public abstract void Handle(SalesArticleEvents.SupplierInvoiceChanged message);
        public abstract void Handle(SalesArticleEvents.ArticleVariantChanged message);
        public abstract void Handle(SalesArticleEvents.QuantityChanged message);
        public abstract void Handle(SalesArticleEvents.PriceChanged message);
    }
}
