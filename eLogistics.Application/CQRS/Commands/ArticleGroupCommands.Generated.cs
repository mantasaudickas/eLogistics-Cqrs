using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class ArticleGroupCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid ArticleGroupId { get; private set; }

            public Create(Guid articleGroupId) : base(articleGroupId)
            {
                ArticleGroupId = articleGroupId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid ArticleGroupId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid articleGroupId, string name) : base(articleGroupId)
            {
                ArticleGroupId = articleGroupId;
                Name = name;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid ArticleGroupId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid articleGroupId, string note) : base(articleGroupId)
            {
                ArticleGroupId = articleGroupId;
                Note = note;
            }
        }

    }
}
