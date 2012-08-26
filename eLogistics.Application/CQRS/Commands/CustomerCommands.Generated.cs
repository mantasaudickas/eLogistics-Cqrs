using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class CustomerCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }

            public Create(Guid customerId) : base(customerId)
            {
                CustomerId = customerId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid customerId, string name) : base(customerId)
            {
                CustomerId = customerId;
                Name = name;
            }
        }

        [DataContract]
        public class AddCompany : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public AddCompany(Guid customerId, Guid companyId) : base(customerId)
            {
                CustomerId = customerId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class RemoveCompany : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public RemoveCompany(Guid customerId, Guid companyId) : base(customerId)
            {
                CustomerId = customerId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid customerId, string note) : base(customerId)
            {
                CustomerId = customerId;
                Note = note;
            }
        }

        [DataContract]
        public class AddBankAccount : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public AddBankAccount(Guid customerId, BankAccount bankAccount) : base(customerId)
            {
                CustomerId = customerId;
                BankAccount = bankAccount;
            }
        }

        [DataContract]
        public class RemoveBankAccount : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public RemoveBankAccount(Guid customerId, BankAccount bankAccount) : base(customerId)
            {
                CustomerId = customerId;
                BankAccount = bankAccount;
            }
        }

        [DataContract]
        public class AddPaymentType : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public AddPaymentType(Guid customerId, Guid paymentTypeId) : base(customerId)
            {
                CustomerId = customerId;
                PaymentTypeId = paymentTypeId;
            }
        }

        [DataContract]
        public class RemovePaymentType : Command
        {
            [DataMember] public Guid CustomerId { get; private set; }
            [DataMember] public Guid PaymentTypeId { get; private set; }

            public RemovePaymentType(Guid customerId, Guid paymentTypeId) : base(customerId)
            {
                CustomerId = customerId;
                PaymentTypeId = paymentTypeId;
            }
        }

    }
}
