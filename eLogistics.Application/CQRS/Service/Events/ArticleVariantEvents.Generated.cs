using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class ArticleVariantEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public Guid ArticleId { get; private set; }

            public Created(Guid articleVariantId, Guid articleId) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class PriceChanged : Event
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public decimal Price { get; private set; }
            [DataMember] public byte Vat { get; private set; }

            public PriceChanged(Guid articleVariantId, decimal price, byte vat) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Price = price;
                Vat = vat;
            }
        }

        [DataContract]
        public class BarcodeAdded : Event
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Barcode { get; private set; }

            public BarcodeAdded(Guid articleVariantId, string barcode) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Barcode = barcode;
            }
        }

        [DataContract]
        public class BarcodeRemoved : Event
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Barcode { get; private set; }

            public BarcodeRemoved(Guid articleVariantId, string barcode) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Barcode = barcode;
            }
        }

        [DataContract]
        public class ArticleAttributeAdded : Event
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Attribute { get; private set; }

            public ArticleAttributeAdded(Guid articleVariantId, string attribute) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Attribute = attribute;
            }
        }

        [DataContract]
        public class ArticleAttributeRemoved : Event
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Attribute { get; private set; }

            public ArticleAttributeRemoved(Guid articleVariantId, string attribute) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Attribute = attribute;
            }
        }

    }
}
