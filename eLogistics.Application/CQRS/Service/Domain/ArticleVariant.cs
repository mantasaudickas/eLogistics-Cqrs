using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class ArticleVariant : AggregateRoot<ArticleVariantState>
    {
        public ArticleVariant()
        {
        }

        public void Create(Guid articleVariantId, Guid articleId)
        {
            this.RaiseEvent(new ArticleVariantEvents.Created(articleVariantId, articleId));
        }

        public void ChangePrice(decimal price, byte vat)
        {
            this.RaiseEvent(new ArticleVariantEvents.PriceChanged(this.State.Id, price, vat));
        }

        public void AddBarcode(string barcode)
        {
            this.RaiseEvent(new ArticleVariantEvents.BarcodeAdded(this.State.Id, barcode));
        }

        public void RemoveBarcode(string barcode)
        {
            this.RaiseEvent(new ArticleVariantEvents.BarcodeRemoved(this.State.Id, barcode));
        }

        public void AddArticleAttribute(string attribute)
        {
            if (!this.State.AttributeList.Contains(attribute))
                this.RaiseEvent(new ArticleVariantEvents.ArticleAttributeAdded(this.State.Id, attribute));
        }

        public void RemoveArticleAttribute(string attribute)
        {
            if (this.State.AttributeList.Contains(attribute))
                this.RaiseEvent(new ArticleVariantEvents.ArticleAttributeRemoved(this.State.Id, attribute));
        }
    }
}
