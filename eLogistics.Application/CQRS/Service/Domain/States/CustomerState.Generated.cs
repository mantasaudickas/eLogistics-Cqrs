using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class CustomerState : State
    {
        public CustomerState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return CustomerId; } }
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public Guid CompanyId { get; private set; }
        public string Note { get; private set; }
        public List<BankAccount> BankAccountList { get; private set; }
        public List<Guid> PaymentTypeIdList { get; private set; }

        public void When(CustomerEvents.Created e)
        {
            this.CustomerId = e.CustomerId;
        }

        public void When(CustomerEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(CustomerEvents.CompanyAdded e)
        {
            this.CompanyId = e.CompanyId;
        }

        public void When(CustomerEvents.CompanyRemoved e)
        {
            this.CompanyId = e.CompanyId;
        }

        public void When(CustomerEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

        public void When(CustomerEvents.BankAccountAdded e)
        {
            this.BankAccountList.Add(e.BankAccount);
        }

        public void When(CustomerEvents.BankAccountRemoved e)
        {
            this.BankAccountList.Remove(e.BankAccount);
        }

        public void When(CustomerEvents.PaymentTypeAdded e)
        {
            this.PaymentTypeIdList.Add(e.PaymentTypeId);
        }

        public void When(CustomerEvents.PaymentTypeRemoved e)
        {
            this.PaymentTypeIdList.Remove(e.PaymentTypeId);
        }

    }
}
