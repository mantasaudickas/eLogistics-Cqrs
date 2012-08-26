using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class CommunicationState : State
    {
        public CommunicationState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return CommunicationId; } }
        public Guid CommunicationId { get; private set; }
        public Owner Owner { get; private set; }
        public Guid OwnerId { get; private set; }
        public CommunicationType CommunicationType { get; private set; }
        public string Value { get; private set; }
        public string Note { get; private set; }

        public void When(CommunicationEvents.Created e)
        {
            this.CommunicationId = e.CommunicationId;
            this.Owner = e.Owner;
            this.OwnerId = e.OwnerId;
        }

        public void When(CommunicationEvents.ValueChanged e)
        {
            this.CommunicationType = e.CommunicationType;
            this.Value = e.Value;
        }

        public void When(CommunicationEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

    }
}
