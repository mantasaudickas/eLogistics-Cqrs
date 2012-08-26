using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class SalesArticleState : State
    {
        public SalesArticleState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return SalesArticleId; } }
        public Guid SalesArticleId { get; private set; }
        public Guid SupplierInvoiceId { get; private set; }
        public Guid ArticleVariantId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public byte Vat { get; private set; }

        public void When(SalesArticleEvents.Created e)
        {
            this.SalesArticleId = e.SalesArticleId;
        }

        public void When(SalesArticleEvents.SupplierInvoiceChanged e)
        {
            this.SupplierInvoiceId = e.SupplierInvoiceId;
        }

        public void When(SalesArticleEvents.ArticleVariantChanged e)
        {
            this.ArticleVariantId = e.ArticleVariantId;
        }

        public void When(SalesArticleEvents.QuantityChanged e)
        {
            this.Quantity = e.Quantity;
        }

        public void When(SalesArticleEvents.PriceChanged e)
        {
            this.Price = e.Price;
            this.Vat = e.Vat;
        }

    }
}
