using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class CountryCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid CountryId { get; private set; }

            public Create(Guid countryId) : base(countryId)
            {
                CountryId = countryId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid CountryId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid countryId, string name) : base(countryId)
            {
                CountryId = countryId;
                Name = name;
            }
        }

    }
}
