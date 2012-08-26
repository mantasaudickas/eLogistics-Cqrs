using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class ArticleVariantCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public Guid ArticleId { get; private set; }

            public Create(Guid articleVariantId, Guid articleId) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class ChangePrice : Command
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public decimal Price { get; private set; }
            [DataMember] public byte Vat { get; private set; }

            public ChangePrice(Guid articleVariantId, decimal price, byte vat) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Price = price;
                Vat = vat;
            }
        }

        [DataContract]
        public class AddBarcode : Command
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Barcode { get; private set; }

            public AddBarcode(Guid articleVariantId, string barcode) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Barcode = barcode;
            }
        }

        [DataContract]
        public class RemoveBarcode : Command
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Barcode { get; private set; }

            public RemoveBarcode(Guid articleVariantId, string barcode) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Barcode = barcode;
            }
        }

        [DataContract]
        public class AddArticleAttribute : Command
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Attribute { get; private set; }

            public AddArticleAttribute(Guid articleVariantId, string attribute) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Attribute = attribute;
            }
        }

        [DataContract]
        public class RemoveArticleAttribute : Command
        {
            [DataMember] public Guid ArticleVariantId { get; private set; }
            [DataMember] public string Attribute { get; private set; }

            public RemoveArticleAttribute(Guid articleVariantId, string attribute) : base(articleVariantId)
            {
                ArticleVariantId = articleVariantId;
                Attribute = attribute;
            }
        }

    }
}
