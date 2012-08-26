using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class ArticleGroupState : State
    {
        public ArticleGroupState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return ArticleGroupId; } }
        public Guid ArticleGroupId { get; private set; }
        public string Name { get; private set; }
        public string Note { get; private set; }

        public void When(ArticleGroupEvents.Created e)
        {
            this.ArticleGroupId = e.ArticleGroupId;
        }

        public void When(ArticleGroupEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(ArticleGroupEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

    }
}
