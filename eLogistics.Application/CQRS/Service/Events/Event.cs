using System;
using System.Runtime.Serialization;

namespace eLogistics.Application.CQRS.Service.Events
{
    [DataContract]
    public class Event : IMessage
    {
        public Event(Guid aggregateId)
        {
            this.AggregateId = aggregateId;
            this.Created = DateTime.UtcNow;
        }

        [DataMember]
        public Guid AggregateId { get; private set; }

        [DataMember]
        public DateTime Created { get; private set; }
    }
}
