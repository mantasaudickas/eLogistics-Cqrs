using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class CompanyHandler : CommandHandler<Company>
    {
        public CompanyHandler(IRepository<Company> repository) : base(repository)
        {
        }

        public void Handle(CompanyCommands.Create message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.Create(message.CompanyId);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.ChangeName message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.ChangeCompanyCode message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.ChangeCompanyCode(message.CompanyCode,message.CompanyVatCode);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.ChangeContactPerson message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.ChangeContactPerson(message.ContactPersonName,message.ContactPhoneNo);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.ChangeNote message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.AddAddress message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.AddAddress(message.AddressId);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.RemoveAddress message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.RemoveAddress(message.AddressId);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.AddCommunication message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.AddCommunication(message.CommunicationId);
            this.Repository.Save(item);
        }

        public void Handle(CompanyCommands.RemoveCommunication message)
        {
            Company item = this.Repository.GetById(message.Id);
            item.RemoveCommunication(message.CommunicationId);
            this.Repository.Save(item);
        }

    }
}
