using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class OrderItemDto : DataTransferObject
    {
        public OrderItemDto()
        {
        }

        [DataMember] public Guid OrderItemId { get; set; }
        [DataMember] public Guid OrderId { get; set; }
        [DataMember] public Guid SalesArticleId { get; set; }
        [DataMember] public int Quantity { get; set; }
        [DataMember] public decimal Price { get; set; }
        [DataMember] public byte Vat { get; set; }
        [DataMember] public DiscountType DiscountType { get; set; }
        [DataMember] public decimal DiscountValue { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public bool IsServiceItem { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = OrderItemId;
            descr.Properties["OrderItemId"] = OrderItemId;
            descr.Properties["OrderId"] = OrderId;
            descr.Properties["SalesArticleId"] = SalesArticleId;
            descr.Properties["Quantity"] = Quantity;
            descr.Properties["Price"] = Price;
            descr.Properties["Vat"] = Vat;
            descr.Properties["DiscountType"] = DiscountType;
            descr.Properties["DiscountValue"] = DiscountValue;
            descr.Properties["Name"] = Name;
            descr.Properties["IsServiceItem"] = IsServiceItem;
            return descr;
        }
    }
}
