using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class ArticleGroupHandler : CommandHandler<ArticleGroup>
    {
        public ArticleGroupHandler(IRepository<ArticleGroup> repository) : base(repository)
        {
        }

        public void Handle(ArticleGroupCommands.Create message)
        {
            ArticleGroup item = this.Repository.GetById(message.Id);
            item.Create(message.ArticleGroupId);
            this.Repository.Save(item);
        }

        public void Handle(ArticleGroupCommands.ChangeName message)
        {
            ArticleGroup item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(ArticleGroupCommands.ChangeNote message)
        {
            ArticleGroup item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

    }
}
