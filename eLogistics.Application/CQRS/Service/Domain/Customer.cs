using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Customer : AggregateRoot<CustomerState>
    {
        public Customer()
        {
        }

        public void Create(Guid customerId)
        {
            this.RaiseEvent(new CustomerEvents.Created(customerId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new CustomerEvents.NameChanged(this.State.Id, name));
        }

        public void AddCompany(Guid companyId)
        {
            this.RaiseEvent(new CustomerEvents.CompanyAdded(this.State.Id, companyId));
        }

        public void RemoveCompany(Guid companyId)
        {
            this.RaiseEvent(new CustomerEvents.CompanyRemoved(this.State.Id, companyId));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new CustomerEvents.NoteChanged(this.State.Id, note));
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            if (!this.State.BankAccountList.Contains(bankAccount))
                this.RaiseEvent(new CustomerEvents.BankAccountAdded(this.State.Id, bankAccount));
        }

        public void RemoveBankAccount(BankAccount bankAccount)
        {
            if (this.State.BankAccountList.Contains(bankAccount))
                this.RaiseEvent(new CustomerEvents.BankAccountRemoved(this.State.Id, bankAccount));
        }

        public void AddPaymentType(Guid paymentTypeId)
        {
            if (!this.State.PaymentTypeIdList.Contains(paymentTypeId))
                this.RaiseEvent(new CustomerEvents.PaymentTypeAdded(this.State.Id, paymentTypeId));
        }

        public void RemovePaymentType(Guid paymentTypeId)
        {
            if (this.State.PaymentTypeIdList.Contains(paymentTypeId))
                this.RaiseEvent(new CustomerEvents.PaymentTypeRemoved(this.State.Id, paymentTypeId));
        }
    }
}
