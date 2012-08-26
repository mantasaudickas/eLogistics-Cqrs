using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class ArticleCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }

            public Create(Guid articleId) : base(articleId)
            {
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class ChangeArticleGroup : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public Guid ArticleGroupId { get; private set; }

            public ChangeArticleGroup(Guid articleId, Guid articleGroupId) : base(articleId)
            {
                ArticleId = articleId;
                ArticleGroupId = articleGroupId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid articleId, string name) : base(articleId)
            {
                ArticleId = articleId;
                Name = name;
            }
        }

        [DataContract]
        public class ChangeManufacturer : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string Manufacturer { get; private set; }

            public ChangeManufacturer(Guid articleId, string manufacturer) : base(articleId)
            {
                ArticleId = articleId;
                Manufacturer = manufacturer;
            }
        }

        [DataContract]
        public class ChangeModelName : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string ModelName { get; private set; }

            public ChangeModelName(Guid articleId, string modelName) : base(articleId)
            {
                ArticleId = articleId;
                ModelName = modelName;
            }
        }

        [DataContract]
        public class ChangeQuantityUnitName : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string QuantityUnitName { get; private set; }

            public ChangeQuantityUnitName(Guid articleId, string quantityUnitName) : base(articleId)
            {
                ArticleId = articleId;
                QuantityUnitName = quantityUnitName;
            }
        }

        [DataContract]
        public class MarkArticleAsInternal : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }

            public MarkArticleAsInternal(Guid articleId) : base(articleId)
            {
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class UnmarkArticleAsInternal : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }

            public UnmarkArticleAsInternal(Guid articleId) : base(articleId)
            {
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid articleId, string note) : base(articleId)
            {
                ArticleId = articleId;
                Note = note;
            }
        }

    }
}
