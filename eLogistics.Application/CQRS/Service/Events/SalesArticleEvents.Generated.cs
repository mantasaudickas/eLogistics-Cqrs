using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class SalesArticleEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid SalesArticleId { get; private set; }

            public Created(Guid salesArticleId) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
            }
        }

        [DataContract]
        public class SupplierInvoiceChanged : Event
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public Guid SupplierInvoiceId { get; private set; }

            public SupplierInvoiceChanged(Guid salesArticleId, Guid supplierInvoiceId) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                SupplierInvoiceId = supplierInvoiceId;
            }
        }

        [DataContract]
        public class ArticleVariantChanged : Event
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public Guid ArticleVariantId { get; private set; }

            public ArticleVariantChanged(Guid salesArticleId, Guid articleVariantId) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                ArticleVariantId = articleVariantId;
            }
        }

        [DataContract]
        public class QuantityChanged : Event
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public int Quantity { get; private set; }

            public QuantityChanged(Guid salesArticleId, int quantity) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                Quantity = quantity;
            }
        }

        [DataContract]
        public class PriceChanged : Event
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public decimal Price { get; private set; }
            [DataMember] public byte Vat { get; private set; }

            public PriceChanged(Guid salesArticleId, decimal price, byte vat) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                Price = price;
                Vat = vat;
            }
        }

    }
}
