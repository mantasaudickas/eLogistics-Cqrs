using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class CustomerEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }

            public Created(Guid customerId) : base(customerId)
            {
                CustomerId = customerId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid customerId, string name) : base(customerId)
            {
                CustomerId = customerId;
                Name = name;
            }
        }

        [DataContract]
        public class CompanyAdded : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public CompanyAdded(Guid customerId, Guid companyId) : base(customerId)
            {
                CustomerId = customerId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class CompanyRemoved : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public CompanyRemoved(Guid customerId, Guid companyId) : base(customerId)
            {
                CustomerId = customerId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid customerId, string note) : base(customerId)
            {
                CustomerId = customerId;
                Note = note;
            }
        }

        [DataContract]
        public class BankAccountAdded : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public BankAccountAdded(Guid customerId, BankAccount bankAccount) : base(customerId)
            {
                CustomerId = customerId;
                BankAccount = bankAccount;
            }
        }

        [DataContract]
        public class BankAccountRemoved : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public BankAccountRemoved(Guid customerId, BankAccount bankAccount) : base(customerId)
            {
                CustomerId = customerId;
                BankAccount = bankAccount;
            }
        }

        [DataContract]
        public class PaymentTypeAdded : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public PaymentTypeAdded(Guid customerId, Guid paymentTypeId) : base(customerId)
            {
                CustomerId = customerId;
                PaymentTypeId = paymentTypeId;
            }
        }

        [DataContract]
        public class PaymentTypeRemoved : Event
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public PaymentTypeRemoved(Guid customerId, Guid paymentTypeId) : base(customerId)
            {
                CustomerId = customerId;
                PaymentTypeId = paymentTypeId;
            }
        }

    }
}
