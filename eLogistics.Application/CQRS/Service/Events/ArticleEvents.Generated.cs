using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class ArticleEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }

            public Created(Guid articleId) : base(articleId)
            {
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class ArticleGroupChanged : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public Guid ArticleGroupId { get; private set; }

            public ArticleGroupChanged(Guid articleId, Guid articleGroupId) : base(articleId)
            {
                ArticleId = articleId;
                ArticleGroupId = articleGroupId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid articleId, string name) : base(articleId)
            {
                ArticleId = articleId;
                Name = name;
            }
        }

        [DataContract]
        public class ManufacturerChanged : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string Manufacturer { get; private set; }

            public ManufacturerChanged(Guid articleId, string manufacturer) : base(articleId)
            {
                ArticleId = articleId;
                Manufacturer = manufacturer;
            }
        }

        [DataContract]
        public class ModelNameChanged : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string ModelName { get; private set; }

            public ModelNameChanged(Guid articleId, string modelName) : base(articleId)
            {
                ArticleId = articleId;
                ModelName = modelName;
            }
        }

        [DataContract]
        public class QuantityUnitNameChanged : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string QuantityUnitName { get; private set; }

            public QuantityUnitNameChanged(Guid articleId, string quantityUnitName) : base(articleId)
            {
                ArticleId = articleId;
                QuantityUnitName = quantityUnitName;
            }
        }

        [DataContract]
        public class ArticleMarkedAsInternal : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }

            public ArticleMarkedAsInternal(Guid articleId) : base(articleId)
            {
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class ArticleUnmarkedAsInternal : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }

            public ArticleUnmarkedAsInternal(Guid articleId) : base(articleId)
            {
                ArticleId = articleId;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid ArticleId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid articleId, string note) : base(articleId)
            {
                ArticleId = articleId;
                Note = note;
            }
        }

    }
}
