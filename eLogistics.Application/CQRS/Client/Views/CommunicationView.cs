using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class CommunicationView : CommunicationViewBase
    {
        public CommunicationView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(CommunicationEvents.Created message)
        {
            CommunicationDto dto = this.Load(message.CommunicationId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new CommunicationDto();
            dto.CommunicationId = message.CommunicationId;
            dto.Owner = message.Owner;
            dto.OwnerId = message.OwnerId;
            this.Save(dto);
        }

        public override void Handle(CommunicationEvents.ValueChanged message)
        {
            CommunicationDto dto = this.Load(message.CommunicationId);
            dto.CommunicationType = message.CommunicationType;
            dto.Value = message.Value;
            this.Save(dto);
        }

        public override void Handle(CommunicationEvents.NoteChanged message)
        {
            CommunicationDto dto = this.Load(message.CommunicationId);
            dto.Note = message.Note;
            this.Save(dto);
        }

    }
}
