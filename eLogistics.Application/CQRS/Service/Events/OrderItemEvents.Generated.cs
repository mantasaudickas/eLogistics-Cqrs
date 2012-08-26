using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class OrderItemEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public Guid OrderId { get; private set; }

            public Created(Guid orderItemId, Guid orderId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                OrderId = orderId;
            }
        }

        [DataContract]
        public class SalesArticleChanged : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public Guid SalesArticleId { get; private set; }

            public SalesArticleChanged(Guid orderItemId, Guid salesArticleId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                SalesArticleId = salesArticleId;
            }
        }

        [DataContract]
        public class QuantityChanged : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public int Quantity { get; private set; }

            public QuantityChanged(Guid orderItemId, int quantity) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                Quantity = quantity;
            }
        }

        [DataContract]
        public class PriceChanged : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public decimal Price { get; private set; }
            [DataMember] public byte Vat { get; private set; }

            public PriceChanged(Guid orderItemId, decimal price, byte vat) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                Price = price;
                Vat = vat;
            }
        }

        [DataContract]
        public class DiscountChanged : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public DiscountType DiscountType { get; private set; }
            [DataMember] public decimal DiscountValue { get; private set; }

            public DiscountChanged(Guid orderItemId, DiscountType discountType, decimal discountValue) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                DiscountType = discountType;
                DiscountValue = discountValue;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid orderItemId, string name) : base(orderItemId)
            {
                OrderItemId = orderItemId;
                Name = name;
            }
        }

        [DataContract]
        public class ItemMarkedAsService : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }

            public ItemMarkedAsService(Guid orderItemId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
            }
        }

        [DataContract]
        public class ItemUnmarkedAsService : Event
        {
            [DataMember] public Guid OrderItemId { get; private set; }

            public ItemUnmarkedAsService(Guid orderItemId) : base(orderItemId)
            {
                OrderItemId = orderItemId;
            }
        }

    }
}
