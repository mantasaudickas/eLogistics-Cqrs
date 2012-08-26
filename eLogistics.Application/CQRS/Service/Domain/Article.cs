using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Article : AggregateRoot<ArticleState>
    {
        public Article()
        {
        }

        public void Create(Guid articleId)
        {
            this.RaiseEvent(new ArticleEvents.Created(articleId));
        }

        public void ChangeArticleGroup(Guid articleGroupId)
        {
            this.RaiseEvent(new ArticleEvents.ArticleGroupChanged(this.State.Id, articleGroupId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new ArticleEvents.NameChanged(this.State.Id, name));
        }

        public void ChangeManufacturer(string manufacturer)
        {
            this.RaiseEvent(new ArticleEvents.ManufacturerChanged(this.State.Id, manufacturer));
        }

        public void ChangeModelName(string modelName)
        {
            this.RaiseEvent(new ArticleEvents.ModelNameChanged(this.State.Id, modelName));
        }

        public void ChangeQuantityUnitName(string quantityUnitName)
        {
            this.RaiseEvent(new ArticleEvents.QuantityUnitNameChanged(this.State.Id, quantityUnitName));
        }

        public void MarkArticleAsInternal()
        {
            this.RaiseEvent(new ArticleEvents.ArticleMarkedAsInternal(this.State.Id));
        }

        public void UnmarkArticleAsInternal()
        {
            this.RaiseEvent(new ArticleEvents.ArticleUnmarkedAsInternal(this.State.Id));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new ArticleEvents.NoteChanged(this.State.Id, note));
        }
    }
}
