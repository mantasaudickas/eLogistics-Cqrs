using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class CityDto : DataTransferObject
    {
        public CityDto()
        {
        }

        [DataMember] public Guid CityId { get; set; }
        [DataMember] public Guid CountryId { get; set; }
        [DataMember] public string Name { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = CityId;
            descr.Properties["CityId"] = CityId;
            descr.Properties["CountryId"] = CountryId;
            descr.Properties["Name"] = Name;
            return descr;
        }
    }
}
