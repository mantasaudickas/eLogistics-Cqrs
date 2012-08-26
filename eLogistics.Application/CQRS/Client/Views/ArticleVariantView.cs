using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class ArticleVariantView : ArticleVariantViewBase
    {
        public ArticleVariantView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(ArticleVariantEvents.Created message)
        {
            ArticleVariantDto dto = this.Load(message.ArticleVariantId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new ArticleVariantDto();
            dto.ArticleVariantId = message.ArticleVariantId;
            dto.ArticleId = message.ArticleId;
            this.Save(dto);
        }

        public override void Handle(ArticleVariantEvents.PriceChanged message)
        {
            ArticleVariantDto dto = this.Load(message.ArticleVariantId);
            dto.Price = message.Price;
            dto.Vat = message.Vat;
            this.Save(dto);
        }

        public override void Handle(ArticleVariantEvents.BarcodeAdded message)
        {
            ArticleVariantDto dto = this.Load(message.ArticleVariantId);
            dto.Barcode = message.Barcode;
            this.Save(dto);
        }

        public override void Handle(ArticleVariantEvents.BarcodeRemoved message)
        {
            ArticleVariantDto dto = this.Load(message.ArticleVariantId);
            dto.Barcode = message.Barcode;
            this.Save(dto);
        }

        public override void Handle(ArticleVariantEvents.ArticleAttributeAdded message)
        {
            ArticleVariantDto dto = this.Load(message.ArticleVariantId);
            dto.AttributeList.Add(message.Attribute);
            this.Save(dto);
        }

        public override void Handle(ArticleVariantEvents.ArticleAttributeRemoved message)
        {
            ArticleVariantDto dto = this.Load(message.ArticleVariantId);
            dto.AttributeList.Remove(message.Attribute);
            this.Save(dto);
        }

    }
}
