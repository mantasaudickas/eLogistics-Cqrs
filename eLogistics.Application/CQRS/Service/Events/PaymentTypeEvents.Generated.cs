using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class PaymentTypeEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public Created(Guid paymentTypeId) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid paymentTypeId, string name) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
                Name = name;
            }
        }

        [DataContract]
        public class IsCreditChanged : Event
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }
            [DataMember] public bool IsCredit { get; private set; }

            public IsCreditChanged(Guid paymentTypeId, bool isCredit) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
                IsCredit = isCredit;
            }
        }

        [DataContract]
        public class Deleted : Event
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public Deleted(Guid paymentTypeId) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
            }
        }

    }
}
