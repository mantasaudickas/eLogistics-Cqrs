using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class AddressHandler : CommandHandler<Address>
    {
        public AddressHandler(IRepository<Address> repository) : base(repository)
        {
        }

        public void Handle(AddressCommands.Create message)
        {
            Address item = this.Repository.GetById(message.Id);
            item.Create(message.AddressId,message.Owner,message.OwnerId);
            this.Repository.Save(item);
        }

        public void Handle(AddressCommands.ChangeCountry message)
        {
            Address item = this.Repository.GetById(message.Id);
            item.ChangeCountry(message.CountryId);
            this.Repository.Save(item);
        }

        public void Handle(AddressCommands.ChangeCity message)
        {
            Address item = this.Repository.GetById(message.Id);
            item.ChangeCity(message.City);
            this.Repository.Save(item);
        }

        public void Handle(AddressCommands.ChangeStreet message)
        {
            Address item = this.Repository.GetById(message.Id);
            item.ChangeStreet(message.Street,message.HouseNo);
            this.Repository.Save(item);
        }

        public void Handle(AddressCommands.ChangePostalCode message)
        {
            Address item = this.Repository.GetById(message.Id);
            item.ChangePostalCode(message.PostalCode);
            this.Repository.Save(item);
        }

        public void Handle(AddressCommands.ChangeNote message)
        {
            Address item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

    }
}
