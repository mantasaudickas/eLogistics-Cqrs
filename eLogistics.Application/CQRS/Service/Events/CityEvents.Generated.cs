using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class CityEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid CityId { get; private set; }

            public Created(Guid cityId) : base(cityId)
            {
                CityId = cityId;
            }
        }

        [DataContract]
        public class CountryChanged : Event
        {
            [DataMember] public Guid CityId { get; private set; }
            [DataMember] public Guid CountryId { get; private set; }

            public CountryChanged(Guid cityId, Guid countryId) : base(cityId)
            {
                CityId = cityId;
                CountryId = countryId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid CityId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid cityId, string name) : base(cityId)
            {
                CityId = cityId;
                Name = name;
            }
        }

    }
}
