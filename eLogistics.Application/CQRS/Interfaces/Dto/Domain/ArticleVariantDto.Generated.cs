using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class ArticleVariantDto : DataTransferObject
    {
        public ArticleVariantDto()
        {
        }

        [DataMember] public Guid ArticleVariantId { get; set; }
        [DataMember] public Guid ArticleId { get; set; }
        [DataMember] public decimal Price { get; set; }
        [DataMember] public byte Vat { get; set; }
        [DataMember] public string Barcode { get; set; }
        [DataMember] public List<string> AttributeList { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = ArticleVariantId;
            descr.Properties["ArticleVariantId"] = ArticleVariantId;
            descr.Properties["ArticleId"] = ArticleId;
            descr.Properties["Price"] = Price;
            descr.Properties["Vat"] = Vat;
            descr.Properties["Barcode"] = Barcode;
            descr.Properties["Attribute"] = AttributeList;
            return descr;
        }
    }
}
