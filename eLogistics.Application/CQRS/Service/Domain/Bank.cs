using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Bank : AggregateRoot<BankState>
    {
        public Bank()
        {
        }

        public void Create(Guid bankId)
        {
            this.RaiseEvent(new BankEvents.Created(bankId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new BankEvents.NameChanged(this.State.Id, name));
        }

        public void ChangeBankCode(string code)
        {
            this.RaiseEvent(new BankEvents.BankCodeChanged(this.State.Id, code));
        }

        public void ChangeBankSwiftCode(string swiftCode)
        {
            this.RaiseEvent(new BankEvents.BankSwiftCodeChanged(this.State.Id, swiftCode));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new BankEvents.NoteChanged(this.State.Id, note));
        }
    }
}
