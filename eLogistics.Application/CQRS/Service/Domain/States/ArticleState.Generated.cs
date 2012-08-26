using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class ArticleState : State
    {
        public ArticleState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return ArticleId; } }
        public Guid ArticleId { get; private set; }
        public Guid ArticleGroupId { get; private set; }
        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public string ModelName { get; private set; }
        public string QuantityUnitName { get; private set; }
        public string Note { get; private set; }

        public void When(ArticleEvents.Created e)
        {
            this.ArticleId = e.ArticleId;
        }

        public void When(ArticleEvents.ArticleGroupChanged e)
        {
            this.ArticleGroupId = e.ArticleGroupId;
        }

        public void When(ArticleEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(ArticleEvents.ManufacturerChanged e)
        {
            this.Manufacturer = e.Manufacturer;
        }

        public void When(ArticleEvents.ModelNameChanged e)
        {
            this.ModelName = e.ModelName;
        }

        public void When(ArticleEvents.QuantityUnitNameChanged e)
        {
            this.QuantityUnitName = e.QuantityUnitName;
        }

        public void When(ArticleEvents.ArticleMarkedAsInternal e)
        {
        }

        public void When(ArticleEvents.ArticleUnmarkedAsInternal e)
        {
        }

        public void When(ArticleEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

    }
}
