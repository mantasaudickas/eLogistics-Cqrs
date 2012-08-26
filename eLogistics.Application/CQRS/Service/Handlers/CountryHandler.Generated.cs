using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class CountryHandler : CommandHandler<Country>
    {
        public CountryHandler(IRepository<Country> repository) : base(repository)
        {
        }

        public void Handle(CountryCommands.Create message)
        {
            Country item = this.Repository.GetById(message.Id);
            item.Create(message.CountryId);
            this.Repository.Save(item);
        }

        public void Handle(CountryCommands.ChangeName message)
        {
            Country item = this.Repository.GetById(message.Id);
            item.ChangeName(message.Name);
            this.Repository.Save(item);
        }

    }
}
