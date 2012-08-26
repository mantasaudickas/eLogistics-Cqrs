using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class SalesArticleCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid SalesArticleId { get; private set; }

            public Create(Guid salesArticleId) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
            }
        }

        [DataContract]
        public class ChangeSupplierInvoice : Command
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public Guid SupplierInvoiceId { get; private set; }

            public ChangeSupplierInvoice(Guid salesArticleId, Guid supplierInvoiceId) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                SupplierInvoiceId = supplierInvoiceId;
            }
        }

        [DataContract]
        public class ChangeArticleVariant : Command
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public Guid ArticleVariantId { get; private set; }

            public ChangeArticleVariant(Guid salesArticleId, Guid articleVariantId) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                ArticleVariantId = articleVariantId;
            }
        }

        [DataContract]
        public class ChangeQuantity : Command
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public int Quantity { get; private set; }

            public ChangeQuantity(Guid salesArticleId, int quantity) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                Quantity = quantity;
            }
        }

        [DataContract]
        public class ChangePrice : Command
        {
            [DataMember] public Guid SalesArticleId { get; private set; }
            [DataMember] public decimal Price { get; private set; }
            [DataMember] public byte Vat { get; private set; }

            public ChangePrice(Guid salesArticleId, decimal price, byte vat) : base(salesArticleId)
            {
                SalesArticleId = salesArticleId;
                Price = price;
                Vat = vat;
            }
        }

    }
}
