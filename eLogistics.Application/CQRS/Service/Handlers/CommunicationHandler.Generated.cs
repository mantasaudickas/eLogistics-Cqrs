using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Service.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Service.Handlers
{
    public partial class CommunicationHandler : CommandHandler<Communication>
    {
        public CommunicationHandler(IRepository<Communication> repository) : base(repository)
        {
        }

        public void Handle(CommunicationCommands.Create message)
        {
            Communication item = this.Repository.GetById(message.Id);
            item.Create(message.CommunicationId,message.Owner,message.OwnerId);
            this.Repository.Save(item);
        }

        public void Handle(CommunicationCommands.ChangeValue message)
        {
            Communication item = this.Repository.GetById(message.Id);
            item.ChangeValue(message.CommunicationType,message.Value);
            this.Repository.Save(item);
        }

        public void Handle(CommunicationCommands.ChangeNote message)
        {
            Communication item = this.Repository.GetById(message.Id);
            item.ChangeNote(message.Note);
            this.Repository.Save(item);
        }

    }
}
