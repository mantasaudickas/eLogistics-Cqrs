using System;
using System.Runtime.Serialization;

namespace eLogistics.Application.CQRS.Commands
{
    [DataContract]
    public abstract class Command : IMessage
    {
        [DataMember] public Guid Id { get; private set; }

        protected Command(Guid id)
        {
            Id = id;
        }
    }
}
