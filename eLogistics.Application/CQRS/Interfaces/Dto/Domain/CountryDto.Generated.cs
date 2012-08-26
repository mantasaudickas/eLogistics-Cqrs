using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class CountryDto : DataTransferObject
    {
        public CountryDto()
        {
        }

        [DataMember] public Guid CountryId { get; set; }
        [DataMember] public string Name { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = CountryId;
            descr.Properties["CountryId"] = CountryId;
            descr.Properties["Name"] = Name;
            return descr;
        }
    }
}
