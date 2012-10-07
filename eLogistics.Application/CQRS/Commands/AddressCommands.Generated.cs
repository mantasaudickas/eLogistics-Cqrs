using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class AddressCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public Owner Owner { get; private set; }
            [DataMember] public Guid OwnerId { get; private set; }

            public Create(Guid addressId, Owner owner, Guid ownerId) : base(addressId)
            {
                AddressId = addressId;
                Owner = owner;
                OwnerId = ownerId;
            }
        }

        [DataContract]
        public class ChangeCountry : Command
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public Guid CountryId { get; private set; }

            public ChangeCountry(Guid addressId, Guid countryId) : base(addressId)
            {
                AddressId = addressId;
                CountryId = countryId;
            }
        }

        [DataContract]
        public class ChangeCity : Command
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public Guid CityId { get; private set; }

            public ChangeCity(Guid addressId, Guid cityId) : base(addressId)
            {
                AddressId = addressId;
                CityId = cityId;
            }
        }

        [DataContract]
        public class ChangeStreet : Command
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string Street { get; private set; }
            [DataMember] public string HouseNo { get; private set; }

            public ChangeStreet(Guid addressId, string street, string houseNo) : base(addressId)
            {
                AddressId = addressId;
                Street = street;
                HouseNo = houseNo;
            }
        }

        [DataContract]
        public class ChangePostalCode : Command
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string PostalCode { get; private set; }

            public ChangePostalCode(Guid addressId, string postalCode) : base(addressId)
            {
                AddressId = addressId;
                PostalCode = postalCode;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid addressId, string note) : base(addressId)
            {
                AddressId = addressId;
                Note = note;
            }
        }

    }
}
