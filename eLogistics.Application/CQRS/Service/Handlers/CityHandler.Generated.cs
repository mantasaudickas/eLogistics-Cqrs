using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class CityHandler : CommandHandler<City>
    {
        public CityHandler(IRepository<City> repository) : base(repository)
        {
        }

        public void Handle(CityCommands.Create message)
        {
            City item = this.Repository.GetById(message.Id);
            item.Create(message.CityId);
            this.Repository.Save(item);
        }

        public void Handle(CityCommands.ChangeCountry message)
        {
            City item = this.Repository.GetById(message.Id);
            item.ChangeCountry(message.CountryId);
            this.Repository.Save(item);
        }

        public void Handle(CityCommands.ChangeName message)
        {
            City item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

    }
}
