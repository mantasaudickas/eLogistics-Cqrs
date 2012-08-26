using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class AddressEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public Owner Owner { get; private set; }
            [DataMember] public Guid OwnerId { get; private set; }

            public Created(Guid addressId, Owner owner, Guid ownerId) : base(addressId)
            {
                AddressId = addressId;
                Owner = owner;
                OwnerId = ownerId;
            }
        }

        [DataContract]
        public class CountryChanged : Event
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public Guid CountryId { get; private set; }

            public CountryChanged(Guid addressId, Guid countryId) : base(addressId)
            {
                AddressId = addressId;
                CountryId = countryId;
            }
        }

        [DataContract]
        public class CityChanged : Event
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string City { get; private set; }

            public CityChanged(Guid addressId, string city) : base(addressId)
            {
                AddressId = addressId;
                City = city;
            }
        }

        [DataContract]
        public class StreetChanged : Event
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string Street { get; private set; }
            [DataMember] public string HouseNo { get; private set; }

            public StreetChanged(Guid addressId, string street, string houseNo) : base(addressId)
            {
                AddressId = addressId;
                Street = street;
                HouseNo = houseNo;
            }
        }

        [DataContract]
        public class PostalCodeChanged : Event
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string PostalCode { get; private set; }

            public PostalCodeChanged(Guid addressId, string postalCode) : base(addressId)
            {
                AddressId = addressId;
                PostalCode = postalCode;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid AddressId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid addressId, string note) : base(addressId)
            {
                AddressId = addressId;
                Note = note;
            }
        }

    }
}
