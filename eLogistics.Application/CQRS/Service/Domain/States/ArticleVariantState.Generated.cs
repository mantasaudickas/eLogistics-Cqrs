using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class ArticleVariantState : State
    {
        public ArticleVariantState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return ArticleVariantId; } }
        public Guid ArticleVariantId { get; private set; }
        public Guid ArticleId { get; private set; }
        public decimal Price { get; private set; }
        public byte Vat { get; private set; }
        public string Barcode { get; private set; }
        public List<string> AttributeList { get; private set; }

        public void When(ArticleVariantEvents.Created e)
        {
            this.ArticleVariantId = e.ArticleVariantId;
            this.ArticleId = e.ArticleId;
        }

        public void When(ArticleVariantEvents.PriceChanged e)
        {
            this.Price = e.Price;
            this.Vat = e.Vat;
        }

        public void When(ArticleVariantEvents.BarcodeAdded e)
        {
            this.Barcode = e.Barcode;
        }

        public void When(ArticleVariantEvents.BarcodeRemoved e)
        {
            this.Barcode = e.Barcode;
        }

        public void When(ArticleVariantEvents.ArticleAttributeAdded e)
        {
            this.AttributeList.Add(e.Attribute);
        }

        public void When(ArticleVariantEvents.ArticleAttributeRemoved e)
        {
            this.AttributeList.Remove(e.Attribute);
        }

    }
}
