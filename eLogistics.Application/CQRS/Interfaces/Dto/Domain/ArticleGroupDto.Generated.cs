using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Interfaces.Dto.Domain
{
    [DataContract]
    public partial class ArticleGroupDto : DataTransferObject
    {
        public ArticleGroupDto()
        {
        }

        [DataMember] public Guid ArticleGroupId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Note { get; set; }

        public override DataTransferObjectDescriptor GetDescriptor()
        {
            DataTransferObjectDescriptor descr = new DataTransferObjectDescriptor();
            descr.Id = ArticleGroupId;
            descr.Properties["ArticleGroupId"] = ArticleGroupId;
            descr.Properties["Name"] = Name;
            descr.Properties["Note"] = Note;
            return descr;
        }
    }
}
