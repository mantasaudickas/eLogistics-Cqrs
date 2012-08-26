using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class CountryEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid CountryId { get; private set; }

            public Created(Guid countryId) : base(countryId)
            {
                CountryId = countryId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid CountryId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid countryId, string name) : base(countryId)
            {
                CountryId = countryId;
                Name = name;
            }
        }

    }
}
