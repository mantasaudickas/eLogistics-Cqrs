using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class SupplierCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }

            public Create(Guid supplierId) : base(supplierId)
            {
                SupplierId = supplierId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid supplierId, string name) : base(supplierId)
            {
                SupplierId = supplierId;
                Name = name;
            }
        }

        [DataContract]
        public class AddCompany : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public AddCompany(Guid supplierId, Guid companyId) : base(supplierId)
            {
                SupplierId = supplierId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class RemoveCompany : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public RemoveCompany(Guid supplierId, Guid companyId) : base(supplierId)
            {
                SupplierId = supplierId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid supplierId, string note) : base(supplierId)
            {
                SupplierId = supplierId;
                Note = note;
            }
        }

        [DataContract]
        public class AddBankAccount : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public AddBankAccount(Guid supplierId, BankAccount bankAccount) : base(supplierId)
            {
                SupplierId = supplierId;
                BankAccount = bankAccount;
            }
        }

        [DataContract]
        public class RemoveBankAccount : Command
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public RemoveBankAccount(Guid supplierId, BankAccount bankAccount) : base(supplierId)
            {
                SupplierId = supplierId;
                BankAccount = bankAccount;
            }
        }

    }
}
