using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Supplier : AggregateRoot<SupplierState>
    {
        public Supplier()
        {
        }

        public void Create(Guid supplierId)
        {
            this.RaiseEvent(new SupplierEvents.Created(supplierId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new SupplierEvents.NameChanged(this.State.Id, name));
        }

        public void AddCompany(Guid companyId)
        {
            this.RaiseEvent(new SupplierEvents.CompanyAdded(this.State.Id, companyId));
        }

        public void RemoveCompany(Guid companyId)
        {
            this.RaiseEvent(new SupplierEvents.CompanyRemoved(this.State.Id, companyId));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new SupplierEvents.NoteChanged(this.State.Id, note));
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
    }
}
