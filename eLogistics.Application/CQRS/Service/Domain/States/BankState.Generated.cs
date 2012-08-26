using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class BankState : State
    {
        public BankState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return BankId; } }
        public Guid BankId { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string SwiftCode { get; private set; }
        public string Note { get; private set; }

        public void When(BankEvents.Created e)
        {
            this.BankId = e.BankId;
        }

        public void When(BankEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(BankEvents.BankCodeChanged e)
        {
            this.Code = e.Code;
        }

        public void When(BankEvents.BankSwiftCodeChanged e)
        {
            this.SwiftCode = e.SwiftCode;
        }

        public void When(BankEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

    }
}
