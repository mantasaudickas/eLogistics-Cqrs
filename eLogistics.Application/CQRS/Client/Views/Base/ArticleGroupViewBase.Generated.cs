using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class ArticleGroupViewBase : View<ArticleGroupDto>
        , IHandler<ArticleGroupEvents.Created>
        , IHandler<ArticleGroupEvents.NameChanged>
        , IHandler<ArticleGroupEvents.NoteChanged>

    {
        protected ArticleGroupViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(ArticleGroupEvents.Created message);
        public abstract void Handle(ArticleGroupEvents.NameChanged message);
        public abstract void Handle(ArticleGroupEvents.NoteChanged message);
    }
}
