using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class ArticleVariantHandler : CommandHandler<ArticleVariant>
    {
        public ArticleVariantHandler(IRepository<ArticleVariant> repository) : base(repository)
        {
        }

        public void Handle(ArticleVariantCommands.Create message)
        {
            ArticleVariant item = this.Repository.GetById(message.Id);
            item.Create(message.ArticleVariantId,message.ArticleId);
            this.Repository.Save(item);
        }

        public void Handle(ArticleVariantCommands.ChangePrice message)
        {
            ArticleVariant item = this.Repository.GetById(message.Id);
            item.ChangePrice(message.Price,message.Vat);
            this.Repository.Save(item);
        }

        public void Handle(ArticleVariantCommands.AddBarcode message)
        {
            ArticleVariant item = this.Repository.GetById(message.Id);
            item.AddBarcode(message.Barcode);
            this.Repository.Save(item);
        }

        public void Handle(ArticleVariantCommands.RemoveBarcode message)
        {
            ArticleVariant item = this.Repository.GetById(message.Id);
            item.RemoveBarcode(message.Barcode);
            this.Repository.Save(item);
        }

        public void Handle(ArticleVariantCommands.AddArticleAttribute message)
        {
            ArticleVariant item = this.Repository.GetById(message.Id);
            item.AddArticleAttribute(message.Attribute);
            this.Repository.Save(item);
        }

        public void Handle(ArticleVariantCommands.RemoveArticleAttribute message)
        {
            ArticleVariant item = this.Repository.GetById(message.Id);
            item.RemoveArticleAttribute(message.Attribute);
            this.Repository.Save(item);
        }

    }
}
