using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class ArticleDto : DataTransferObject
    {
        public ArticleDto()
        {
        }

        [DataMember] public Guid ArticleId { get; set; }
        [DataMember] public Guid ArticleGroupId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Manufacturer { get; set; }
        [DataMember] public string ModelName { get; set; }
        [DataMember] public string QuantityUnitName { get; set; }
        [DataMember] public string Note { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = ArticleId;
            descr.Properties["ArticleId"] = ArticleId;
            descr.Properties["ArticleGroupId"] = ArticleGroupId;
            descr.Properties["Name"] = Name;
            descr.Properties["Manufacturer"] = Manufacturer;
            descr.Properties["ModelName"] = ModelName;
            descr.Properties["QuantityUnitName"] = QuantityUnitName;
            descr.Properties["Note"] = Note;
            return descr;
        }
    }
}
