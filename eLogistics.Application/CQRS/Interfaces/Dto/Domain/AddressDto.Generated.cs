using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class AddressDto : DataTransferObject
    {
        public AddressDto()
        {
        }

        [DataMember] public Guid AddressId { get; set; }
        [DataMember] public Owner Owner { get; set; }
        [DataMember] public Guid OwnerId { get; set; }
        [DataMember] public Guid CountryId { get; set; }
        [DataMember] public Guid CityId { get; set; }
        [DataMember] public string Street { get; set; }
        [DataMember] public string HouseNo { get; set; }
        [DataMember] public string PostalCode { get; set; }
        [DataMember] public string Note { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = AddressId;
            descr.Properties["AddressId"] = AddressId;
            descr.Properties["Owner"] = Owner;
            descr.Properties["OwnerId"] = OwnerId;
            descr.Properties["CountryId"] = CountryId;
            descr.Properties["CityId"] = CityId;
            descr.Properties["Street"] = Street;
            descr.Properties["HouseNo"] = HouseNo;
            descr.Properties["PostalCode"] = PostalCode;
            descr.Properties["Note"] = Note;
            return descr;
        }
    }
}
