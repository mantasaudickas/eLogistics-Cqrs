using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class SupplierHandler : CommandHandler<Supplier>
    {
        public SupplierHandler(IRepository<Supplier> repository) : base(repository)
        {
        }

        public void Handle(SupplierCommands.Create message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.Create(message.SupplierId);
            this.Repository.Save(item);
        }

        public void Handle(SupplierCommands.ChangeName message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(SupplierCommands.AddCompany message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.AddCompany(message.CompanyId);
            this.Repository.Save(item);
        }

        public void Handle(SupplierCommands.RemoveCompany message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.RemoveCompany(message.CompanyId);
            this.Repository.Save(item);
        }

        public void Handle(SupplierCommands.ChangeNote message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

        public void Handle(SupplierCommands.AddBankAccount message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.AddBankAccount(message.BankAccount);
            this.Repository.Save(item);
        }

        public void Handle(SupplierCommands.RemoveBankAccount message)
        {
            Supplier item = this.Repository.GetById(message.Id);
            item.RemoveBankAccount(message.BankAccount);
            this.Repository.Save(item);
        }

    }
}
