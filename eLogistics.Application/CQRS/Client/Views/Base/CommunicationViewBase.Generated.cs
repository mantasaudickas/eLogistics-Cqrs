using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class CommunicationViewBase : View<CommunicationDto>
        , IHandler<CommunicationEvents.Created>
        , IHandler<CommunicationEvents.ValueChanged>
        , IHandler<CommunicationEvents.NoteChanged>

    {
        protected CommunicationViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(CommunicationEvents.Created message);
        public abstract void Handle(CommunicationEvents.ValueChanged message);
        public abstract void Handle(CommunicationEvents.NoteChanged message);
    }
}
