using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class OrderItemCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public Guid OrderId { get; private set; }

            public Create(Guid orderItemId, Guid orderId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                OrderId = orderId;
            }
        }

        [DataContract]
        public class ChangeSalesArticle : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public Guid SalesArticleId { get; private set; }

            public ChangeSalesArticle(Guid orderItemId, Guid salesArticleId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                SalesArticleId = salesArticleId;
            }
        }

        [DataContract]
        public class ChangeQuantity : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public int Quantity { get; private set; }

            public ChangeQuantity(Guid orderItemId, int quantity) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                Quantity = quantity;
            }
        }

        [DataContract]
        public class ChangePrice : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public decimal Price { get; private set; }
            [DataMember] public byte Vat { get; private set; }

            public ChangePrice(Guid orderItemId, decimal price, byte vat) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                Price = price;
                Vat = vat;
            }
        }

        [DataContract]
        public class ChangeDiscount : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public DiscountType DiscountType { get; private set; }
            [DataMember] public decimal DiscountValue { get; private set; }

            public ChangeDiscount(Guid orderItemId, DiscountType discountType, decimal discountValue) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                DiscountType = discountType;
                DiscountValue = discountValue;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid orderItemId, string name) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                Name = name;
            }
        }

        [DataContract]
        public class MarkItemAsService : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }

            public MarkItemAsService(Guid orderItemId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
            }
        }

        [DataContract]
        public class UnmarkItemAsService : Command
        {
            [DataMember] public Guid OrderItemId { get; private set; }

            public UnmarkItemAsService(Guid orderItemId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
            }
        }

    }
}
