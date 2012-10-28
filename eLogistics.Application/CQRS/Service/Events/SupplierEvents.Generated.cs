using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class SupplierEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid SupplierId { get; private set; }

            public Created(Guid supplierId) : base(supplierId)
            {
                SupplierId = supplierId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid supplierId, string name) : base(supplierId)
            {
                SupplierId = supplierId;
                Name = name;
            }
        }

        [DataContract]
        public class CompanyChanged : Event
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public Guid CompanyId { get; private set; }

            public CompanyChanged(Guid supplierId, Guid companyId) : base(supplierId)
            {
                SupplierId = supplierId;
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid supplierId, string note) : base(supplierId)
            {
                SupplierId = supplierId;
                Note = note;
            }
        }

        [DataContract]
        public class BankAccountAdded : Event
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public BankAccountAdded(Guid supplierId, BankAccount bankAccount) : base(supplierId)
            {
                SupplierId = supplierId;
                BankAccount = bankAccount;
            }
        }

        [DataContract]
        public class BankAccountRemoved : Event
        {
            [DataMember] public Guid SupplierId { get; private set; }
            [DataMember] public BankAccount BankAccount { get; private set; }

            public BankAccountRemoved(Guid supplierId, BankAccount bankAccount) : base(supplierId)
            {
                SupplierId = supplierId;
                BankAccount = bankAccount;
            }
        }

    }
}
