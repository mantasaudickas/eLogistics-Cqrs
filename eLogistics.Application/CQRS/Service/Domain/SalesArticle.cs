using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class SalesArticle : AggregateRoot<SalesArticleState>
    {
        public SalesArticle()
        {
        }

        public void Create(Guid salesArticleId)
        {
            this.RaiseEvent(new SalesArticleEvents.Created(salesArticleId));
        }

        public void ChangeSupplierInvoice(Guid supplierInvoiceId)
        {
            this.RaiseEvent(new SalesArticleEvents.SupplierInvoiceChanged(this.State.Id, supplierInvoiceId));
        }

        public void ChangeArticleVariant(Guid articleVariantId)
        {
            this.RaiseEvent(new SalesArticleEvents.ArticleVariantChanged(this.State.Id, articleVariantId));
        }

        public void ChangeQuantity(int quantity)
        {
            this.RaiseEvent(new SalesArticleEvents.QuantityChanged(this.State.Id, quantity));
        }

        public void ChangePrice(decimal price, byte vat)
        {
            this.RaiseEvent(new SalesArticleEvents.PriceChanged(this.State.Id, price, vat));
        }
    }
}
