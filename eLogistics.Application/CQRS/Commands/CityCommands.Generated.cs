using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class CityCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid CityId { get; private set; }

            public Create(Guid cityId) : base(cityId)
            {
                CityId = cityId;
            }
        }

        [DataContract]
        public class ChangeCountry : Command
        {
            [DataMember] public Guid CityId { get; private set; }
            [DataMember] public Guid CountryId { get; private set; }

            public ChangeCountry(Guid cityId, Guid countryId) : base(cityId)
            {
                CityId = cityId;
                CountryId = countryId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid CityId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid cityId, string name) : base(cityId)
            {
                CityId = cityId;
                Name = name;
            }
        }

    }
}
