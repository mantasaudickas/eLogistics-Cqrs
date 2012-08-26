using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class BankHandler : CommandHandler<Bank>
    {
        public BankHandler(IRepository<Bank> repository) : base(repository)
        {
        }

        public void Handle(BankCommands.Create message)
        {
            Bank item = this.Repository.GetById(message.Id);
            item.Create(message.BankId);
            this.Repository.Save(item);
        }

        public void Handle(BankCommands.ChangeName message)
        {
            Bank item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(BankCommands.ChangeBankCode message)
        {
            Bank item = this.Repository.GetById(message.Id);
            item.ChangeBankCode(message.Code);
            this.Repository.Save(item);
        }

        public void Handle(BankCommands.ChangeBankSwiftCode message)
        {
            Bank item = this.Repository.GetById(message.Id);
            item.ChangeBankSwiftCode(message.SwiftCode);
            this.Repository.Save(item);
        }

        public void Handle(BankCommands.ChangeNote message)
        {
            Bank item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

    }
}
