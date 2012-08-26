using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class SalesArticleView : SalesArticleViewBase
    {
        public SalesArticleView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(SalesArticleEvents.Created message)
        {
            SalesArticleDto dto = this.Load(message.SalesArticleId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new SalesArticleDto();
            dto.SalesArticleId = message.SalesArticleId;
            this.Save(dto);
        }

        public override void Handle(SalesArticleEvents.SupplierInvoiceChanged message)
        {
            SalesArticleDto dto = this.Load(message.SalesArticleId);
            dto.SupplierInvoiceId = message.SupplierInvoiceId;
            this.Save(dto);
        }

        public override void Handle(SalesArticleEvents.ArticleVariantChanged message)
        {
            SalesArticleDto dto = this.Load(message.SalesArticleId);
            dto.ArticleVariantId = message.ArticleVariantId;
            this.Save(dto);
        }

        public override void Handle(SalesArticleEvents.QuantityChanged message)
        {
            SalesArticleDto dto = this.Load(message.SalesArticleId);
            dto.Quantity = message.Quantity;
            this.Save(dto);
        }

        public override void Handle(SalesArticleEvents.PriceChanged message)
        {
            SalesArticleDto dto = this.Load(message.SalesArticleId);
            dto.Price = message.Price;
            dto.Vat = message.Vat;
            this.Save(dto);
        }

    }
}
