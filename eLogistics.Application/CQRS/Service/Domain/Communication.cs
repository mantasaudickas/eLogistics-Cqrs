using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Communication : AggregateRoot<CommunicationState>
    {
        #region Constructor

        public Communication()
        {
        }

        #endregion

        #region Change Members

        public void Create(Guid communicationId, Owner owner, Guid ownerId)
        {
            this.RaiseEvent(new CommunicationEvents.Created(communicationId, owner, ownerId));
        }

        public void ChangeValue(CommunicationType type, string value)
        {
            this.RaiseEvent(new CommunicationEvents.ValueChanged(this.State.Id, type, value));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new CommunicationEvents.NoteChanged(this.State.Id, note));
        }

        #endregion
    }
}
