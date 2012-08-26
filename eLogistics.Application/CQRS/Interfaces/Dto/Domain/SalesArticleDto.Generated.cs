using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class SalesArticleDto : DataTransferObject
    {
        public SalesArticleDto()
        {
        }

        [DataMember] public Guid SalesArticleId { get; set; }
        [DataMember] public Guid SupplierInvoiceId { get; set; }
        [DataMember] public Guid ArticleVariantId { get; set; }
        [DataMember] public int Quantity { get; set; }
        [DataMember] public decimal Price { get; set; }
        [DataMember] public byte Vat { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = SalesArticleId;
            descr.Properties["SalesArticleId"] = SalesArticleId;
            descr.Properties["SupplierInvoiceId"] = SupplierInvoiceId;
            descr.Properties["ArticleVariantId"] = ArticleVariantId;
            descr.Properties["Quantity"] = Quantity;
            descr.Properties["Price"] = Price;
            descr.Properties["Vat"] = Vat;
            return descr;
        }
    }
}
