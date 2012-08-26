using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class SupplierState : State
    {
        public SupplierState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return SupplierId; } }
        public Guid SupplierId { get; private set; }
        public string Name { get; private set; }
        public Guid CompanyId { get; private set; }
        public string Note { get; private set; }
        public List<BankAccount> BankAccountList { get; private set; }

        public void When(SupplierEvents.Created e)
        {
            this.SupplierId = e.SupplierId;
        }

        public void When(SupplierEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(SupplierEvents.CompanyAdded e)
        {
            this.CompanyId = e.CompanyId;
        }

        public void When(SupplierEvents.CompanyRemoved e)
        {
            this.CompanyId = e.CompanyId;
        }

        public void When(SupplierEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

        public void When(SupplierEvents.BankAccountAdded e)
        {
            this.BankAccountList.Add(e.BankAccount);
        }

        public void When(SupplierEvents.BankAccountRemoved e)
        {
            this.BankAccountList.Remove(e.BankAccount);
        }

    }
}
