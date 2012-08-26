using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Service.Events;
namespace eLogistics.Application.CQRS.Service.Domain.States
{
    public partial class CompanyState : State
    {
        public CompanyState(IEnumerable<Event> events) : base(events)
        {
        }

        public override Guid Id { get { return CompanyId; } }
        public Guid CompanyId { get; private set; }
        public string Name { get; private set; }
        public string CompanyCode { get; private set; }
        public string CompanyVatCode { get; private set; }
        public string ContactPersonName { get; private set; }
        public string ContactPhoneNo { get; private set; }
        public string Note { get; private set; }
        public List<Guid> AddressIdList { get; private set; }
        public List<Guid> CommunicationIdList { get; private set; }

        public void When(CompanyEvents.Created e)
        {
            this.CompanyId = e.CompanyId;
        }

        public void When(CompanyEvents.NameChanged e)
        {
            this.Name = e.Name;
        }

        public void When(CompanyEvents.CompanyCodeChanged e)
        {
            this.CompanyCode = e.CompanyCode;
            this.CompanyVatCode = e.CompanyVatCode;
        }

        public void When(CompanyEvents.ContactPersonChanged e)
        {
            this.ContactPersonName = e.ContactPersonName;
            this.ContactPhoneNo = e.ContactPhoneNo;
        }

        public void When(CompanyEvents.NoteChanged e)
        {
            this.Note = e.Note;
        }

        public void When(CompanyEvents.AddressAdded e)
        {
            this.AddressIdList.Add(e.AddressId);
        }

        public void When(CompanyEvents.AddressRemoved e)
        {
            this.AddressIdList.Remove(e.AddressId);
        }

        public void When(CompanyEvents.CommunicationAdded e)
        {
            this.CommunicationIdList.Add(e.CommunicationId);
        }

        public void When(CompanyEvents.CommunicationRemoved e)
        {
            this.CommunicationIdList.Remove(e.CommunicationId);
        }

    }
}
