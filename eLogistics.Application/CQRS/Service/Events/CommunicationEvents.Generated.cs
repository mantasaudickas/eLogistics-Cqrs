using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class CommunicationEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid CommunicationId { get; private set; }
            [DataMember] public Owner Owner { get; private set; }
            [DataMember] public Guid OwnerId { get; private set; }

            public Created(Guid communicationId, Owner owner, Guid ownerId) : base(communicationId)
            {
                CommunicationId = communicationId;
                Owner = owner;
                OwnerId = ownerId;
            }
        }

        [DataContract]
        public class ValueChanged : Event
        {
            [DataMember] public Guid CommunicationId { get; private set; }
            [DataMember] public CommunicationType CommunicationType { get; private set; }
            [DataMember] public string Value { get; private set; }

            public ValueChanged(Guid communicationId, CommunicationType communicationType, string value) : base(communicationId)
            {
                CommunicationId = communicationId;
                CommunicationType = communicationType;
                Value = value;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid CommunicationId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid communicationId, string note) : base(communicationId)
            {
                CommunicationId = communicationId;
                Note = note;
            }
        }

    }
}
