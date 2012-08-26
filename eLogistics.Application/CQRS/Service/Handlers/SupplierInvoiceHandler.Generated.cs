using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class SupplierInvoiceHandler : CommandHandler<SupplierInvoice>
    {
        public SupplierInvoiceHandler(IRepository<SupplierInvoice> repository) : base(repository)
        {
        }

        public void Handle(SupplierInvoiceCommands.Create message)
        {
            SupplierInvoice item = this.Repository.GetById(message.Id);
            item.Create(message.SupplierInvoiceId,message.SupplierId);
            this.Repository.Save(item);
        }

        public void Handle(SupplierInvoiceCommands.ChangeInvoiceNo message)
        {
            SupplierInvoice item = this.Repository.GetById(message.Id);
            item.ChangeInvoiceNo(message.InvoiceNo);
            this.Repository.Save(item);
        }

        public void Handle(SupplierInvoiceCommands.ChangeInvoiceDate message)
        {
            SupplierInvoice item = this.Repository.GetById(message.Id);
            item.ChangeInvoiceDate(message.InvoiceDate);
            this.Repository.Save(item);
        }

        public void Handle(SupplierInvoiceCommands.ChangeInvoicePaymentDate message)
        {
            SupplierInvoice item = this.Repository.GetById(message.Id);
            item.ChangeInvoicePaymentDate(message.PaymentDate);
            this.Repository.Save(item);
        }

        public void Handle(SupplierInvoiceCommands.ChangeNote message)
        {
            SupplierInvoice item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

    }
}
