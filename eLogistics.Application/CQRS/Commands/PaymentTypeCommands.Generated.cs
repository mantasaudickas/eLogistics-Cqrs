using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class PaymentTypeCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public Create(Guid paymentTypeId) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid paymentTypeId, string name) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
                Name = name;
            }
        }

        [DataContract]
        public class ChangeIsCredit : Command
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }
            [DataMember] public bool IsCredit { get; private set; }

            public ChangeIsCredit(Guid paymentTypeId, bool isCredit) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
                IsCredit = isCredit;
            }
        }

        [DataContract]
        public class Delete : Command
        {
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public Delete(Guid paymentTypeId) : base(paymentTypeId)
            {
                PaymentTypeId = paymentTypeId;
            }
        }

    }
}
