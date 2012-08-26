using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class ArticleGroupView : ArticleGroupViewBase
    {
        public ArticleGroupView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(ArticleGroupEvents.Created message)
        {
            ArticleGroupDto dto = this.Load(message.ArticleGroupId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new ArticleGroupDto();
            dto.ArticleGroupId = message.ArticleGroupId;
            this.Save(dto);
        }

        public override void Handle(ArticleGroupEvents.NameChanged message)
        {
            ArticleGroupDto dto = this.Load(message.ArticleGroupId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(ArticleGroupEvents.NoteChanged message)
        {
            ArticleGroupDto dto = this.Load(message.ArticleGroupId);
            dto.Note = message.Note;
            this.Save(dto);
        }

    }
}
