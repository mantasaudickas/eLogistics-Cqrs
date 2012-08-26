using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class CommunicationCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid CommunicationId { get; private set; }
            [DataMember] public Owner Owner { get; private set; }
            [DataMember] public Guid OwnerId { get; private set; }

            public Create(Guid communicationId, Owner owner, Guid ownerId) : base(communicationId)
            {
                CommunicationId = communicationId;
                Owner = owner;
                OwnerId = ownerId;
            }
        }

        [DataContract]
        public class ChangeValue : Command
        {
            [DataMember] public Guid CommunicationId { get; private set; }
            [DataMember] public CommunicationType CommunicationType { get; private set; }
            [DataMember] public string Value { get; private set; }

            public ChangeValue(Guid communicationId, CommunicationType communicationType, string value) : base(communicationId)
            {
                CommunicationId = communicationId;
                CommunicationType = communicationType;
                Value = value;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid CommunicationId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid communicationId, string note) : base(communicationId)
            {
                CommunicationId = communicationId;
                Note = note;
            }
        }

    }
}
