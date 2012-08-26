using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class ArticleViewBase : View<ArticleDto>
        , IHandler<ArticleEvents.Created>
        , IHandler<ArticleEvents.ArticleGroupChanged>
        , IHandler<ArticleEvents.NameChanged>
        , IHandler<ArticleEvents.ManufacturerChanged>
        , IHandler<ArticleEvents.ModelNameChanged>
        , IHandler<ArticleEvents.QuantityUnitNameChanged>
        , IHandler<ArticleEvents.ArticleMarkedAsInternal>
        , IHandler<ArticleEvents.ArticleUnmarkedAsInternal>
        , IHandler<ArticleEvents.NoteChanged>

    {
        protected ArticleViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(ArticleEvents.Created message);
        public abstract void Handle(ArticleEvents.ArticleGroupChanged message);
        public abstract void Handle(ArticleEvents.NameChanged message);
        public abstract void Handle(ArticleEvents.ManufacturerChanged message);
        public abstract void Handle(ArticleEvents.ModelNameChanged message);
        public abstract void Handle(ArticleEvents.QuantityUnitNameChanged message);
        public abstract void Handle(ArticleEvents.ArticleMarkedAsInternal message);
        public abstract void Handle(ArticleEvents.ArticleUnmarkedAsInternal message);
        public abstract void Handle(ArticleEvents.NoteChanged message);
    }
}
