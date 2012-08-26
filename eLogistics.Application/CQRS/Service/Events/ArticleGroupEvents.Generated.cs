using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class ArticleGroupEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid ArticleGroupId { get; private set; }

            public Created(Guid articleGroupId) : base(articleGroupId)
            {
                ArticleGroupId = articleGroupId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid ArticleGroupId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid articleGroupId, string name) : base(articleGroupId)
            {
                ArticleGroupId = articleGroupId;
                Name = name;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid ArticleGroupId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid articleGroupId, string note) : base(articleGroupId)
            {
                ArticleGroupId = articleGroupId;
                Note = note;
            }
        }

    }
}
