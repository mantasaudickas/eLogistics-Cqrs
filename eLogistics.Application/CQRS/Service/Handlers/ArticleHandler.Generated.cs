using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class ArticleHandler : CommandHandler<Article>
    {
        public ArticleHandler(IRepository<Article> repository) : base(repository)
        {
        }

        public void Handle(ArticleCommands.Create message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.Create(message.ArticleId);
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.ChangeArticleGroup message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.ChangeArticleGroup(message.ArticleGroupId);
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.ChangeName message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.ChangeManufacturer message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.ChangeManufacturer(message.Manufacturer);
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.ChangeModelName message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.ChangeModelName(message.ModelName);
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.ChangeQuantityUnitName message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.ChangeQuantityUnitName(message.QuantityUnitName);
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.MarkArticleAsInternal message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.MarkArticleAsInternal();
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.UnmarkArticleAsInternal message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.UnmarkArticleAsInternal();
            this.Repository.Save(item);
        }

        public void Handle(ArticleCommands.ChangeNote message)
        {
            Article item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

    }
}
