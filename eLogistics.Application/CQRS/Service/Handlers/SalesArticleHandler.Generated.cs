using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class SalesArticleHandler : CommandHandler<SalesArticle>
    {
        public SalesArticleHandler(IRepository<SalesArticle> repository) : base(repository)
        {
        }

        public void Handle(SalesArticleCommands.Create message)
        {
            SalesArticle item = this.Repository.GetById(message.Id);
            item.Create(message.SalesArticleId);
            this.Repository.Save(item);
        }

        public void Handle(SalesArticleCommands.ChangeSupplierInvoice message)
        {
            SalesArticle item = this.Repository.GetById(message.Id);
            item.ChangeSupplierInvoice(message.SupplierInvoiceId);
            this.Repository.Save(item);
        }

        public void Handle(SalesArticleCommands.ChangeArticleVariant message)
        {
            SalesArticle item = this.Repository.GetById(message.Id);
            item.ChangeArticleVariant(message.ArticleVariantId);
            this.Repository.Save(item);
        }

        public void Handle(SalesArticleCommands.ChangeQuantity message)
        {
            SalesArticle item = this.Repository.GetById(message.Id);
            item.ChangeQuantity(message.Quantity);
            this.Repository.Save(item);
        }

        public void Handle(SalesArticleCommands.ChangePrice message)
        {
            SalesArticle item = this.Repository.GetById(message.Id);
            item.ChangePrice(message.Price,message.Vat);
            this.Repository.Save(item);
        }

    }
}
