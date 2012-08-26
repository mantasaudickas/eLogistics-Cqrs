using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views.Base
{
    public abstract class CompanyViewBase : View<CompanyDto>
        , IHandler<CompanyEvents.Created>
        , IHandler<CompanyEvents.NameChanged>
        , IHandler<CompanyEvents.CompanyCodeChanged>
        , IHandler<CompanyEvents.ContactPersonChanged>
        , IHandler<CompanyEvents.NoteChanged>
        , IHandler<CompanyEvents.AddressAdded>
        , IHandler<CompanyEvents.AddressRemoved>
        , IHandler<CompanyEvents.CommunicationAdded>
        , IHandler<CompanyEvents.CommunicationRemoved>

    {
        protected CompanyViewBase(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public abstract void Handle(CompanyEvents.Created message);
        public abstract void Handle(CompanyEvents.NameChanged message);
        public abstract void Handle(CompanyEvents.CompanyCodeChanged message);
        public abstract void Handle(CompanyEvents.ContactPersonChanged message);
        public abstract void Handle(CompanyEvents.NoteChanged message);
        public abstract void Handle(CompanyEvents.AddressAdded message);
        public abstract void Handle(CompanyEvents.AddressRemoved message);
        public abstract void Handle(CompanyEvents.CommunicationAdded message);
        public abstract void Handle(CompanyEvents.CommunicationRemoved message);
    }
}
