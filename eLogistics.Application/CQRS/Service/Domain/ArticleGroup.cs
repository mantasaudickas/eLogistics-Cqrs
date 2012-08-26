using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class ArticleGroup : AggregateRoot<ArticleGroupState>
    {
        public ArticleGroup()
        {
        }

        public void Create(Guid articleGroupId)
        {
            this.RaiseEvent(new ArticleGroupEvents.Created(articleGroupId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new ArticleGroupEvents.NameChanged(this.State.Id, name));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new ArticleGroupEvents.NoteChanged(this.State.Id, note));
        }
    }
}
