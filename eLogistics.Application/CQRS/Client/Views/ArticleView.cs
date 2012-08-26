using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class ArticleView : ArticleViewBase
    {
        public ArticleView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(ArticleEvents.Created message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new ArticleDto();
            dto.ArticleId = message.ArticleId;
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.ArticleGroupChanged message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            dto.ArticleGroupId = message.ArticleGroupId;
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.NameChanged message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.ManufacturerChanged message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            dto.Manufacturer = message.Manufacturer;
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.ModelNameChanged message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            dto.ModelName = message.ModelName;
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.QuantityUnitNameChanged message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            dto.QuantityUnitName = message.QuantityUnitName;
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.ArticleMarkedAsInternal message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.ArticleUnmarkedAsInternal message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            this.Save(dto);
        }

        public override void Handle(ArticleEvents.NoteChanged message)
        {
            ArticleDto dto = this.Load(message.ArticleId);
            dto.Note = message.Note;
            this.Save(dto);
        }

    }
}
