using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class CustomerHandler : CommandHandler<Customer>
    {
        public CustomerHandler(IRepository<Customer> repository) : base(repository)
        {
        }

        public void Handle(CustomerCommands.Create message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.Create(message.CustomerId);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.ChangeName message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.AddCompany message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.AddCompany(message.CompanyId);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.RemoveCompany message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.RemoveCompany(message.CompanyId);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.ChangeNote message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.AddBankAccount message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.AddBankAccount(message.BankAccount);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.RemoveBankAccount message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.RemoveBankAccount(message.BankAccount);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.AddPaymentType message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.AddPaymentType(message.PaymentTypeId);
            this.Repository.Save(item);
        }

        public void Handle(CustomerCommands.RemovePaymentType message)
        {
            Customer item = this.Repository.GetById(message.Id);
            item.RemovePaymentType(message.PaymentTypeId);
            this.Repository.Save(item);
        }

    }
}
