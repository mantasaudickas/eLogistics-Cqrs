using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Client.Views.Base;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Service.Events;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Views
{
    public class CompanyView : CompanyViewBase
    {
        public CompanyView(IReadModelStore readModelStore) : base(readModelStore)
        {
        }

        public override void Handle(CompanyEvents.Created message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            if (dto != null) throw new Exception("Item with the same Id already created!");
            dto = new CompanyDto();
            dto.CompanyId = message.CompanyId;
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.NameChanged message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.Name = message.Name;
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.CompanyCodeChanged message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.CompanyCode = message.CompanyCode;
            dto.CompanyVatCode = message.CompanyVatCode;
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.ContactPersonChanged message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.ContactPersonName = message.ContactPersonName;
            dto.ContactPhoneNo = message.ContactPhoneNo;
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.NoteChanged message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.Note = message.Note;
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.AddressAdded message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.AddressIdList.Add(message.AddressId);
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.AddressRemoved message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.AddressIdList.Remove(message.AddressId);
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.CommunicationAdded message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.CommunicationIdList.Add(message.CommunicationId);
            this.Save(dto);
        }

        public override void Handle(CompanyEvents.CommunicationRemoved message)
        {
            CompanyDto dto = this.Load(message.CompanyId);
            dto.CommunicationIdList.Remove(message.CommunicationId);
            this.Save(dto);
        }

    }
}
