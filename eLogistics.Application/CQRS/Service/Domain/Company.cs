using System;
using eLogistics.Application.CQRS.Service.Domain.States;
using eLogistics.Application.CQRS.Service.Events;

namespace eLogistics.Application.CQRS.Service.Domain
{
    public class Company : AggregateRoot<CompanyState>
    {
        #region Constructor

        public Company()
        {
        }

        #endregion

        #region Change Members

        public void Create(Guid companyId)
        {
            this.RaiseEvent(new CompanyEvents.Created(companyId));
        }

        public void ChangeName(string name)
        {
            this.RaiseEvent(new CompanyEvents.NameChanged(this.State.Id, name));
        }

        public void ChangeCompanyCode(string code, string vatCode)
        {
            this.RaiseEvent(new CompanyEvents.CompanyCodeChanged(this.State.Id, code, vatCode));
        }

        public void ChangeContactPerson(string contactPerson, string contactPhoneNo)
        {
            this.RaiseEvent(new CompanyEvents.ContactPersonChanged(this.State.Id, contactPerson, contactPhoneNo));
        }

        public void ChangeNote(string note)
        {
            this.RaiseEvent(new CompanyEvents.NoteChanged(this.State.Id, note));
        }

        public void AddAddress(Guid addressId)
        {
            if (!this.State.AddressIdList.Contains(addressId))
                this.RaiseEvent(new CompanyEvents.AddressAdded(this.State.Id, addressId));
        }

        public void RemoveAddress(Guid addressId)
        {
            if (this.State.AddressIdList.Contains(addressId))
                this.RaiseEvent(new CompanyEvents.AddressRemoved(this.State.Id, addressId));
        }

        public void AddCommunication(Guid communicationId)
        {
            if (!this.State.CommunicationIdList.Contains(communicationId))
                this.RaiseEvent(new CompanyEvents.CommunicationAdded(this.State.Id, communicationId));
        }

        public void RemoveCommunication(Guid communicationId)
        {
            if (this.State.CommunicationIdList.Contains(communicationId))
                this.RaiseEvent(new CompanyEvents.CommunicationRemoved(this.State.Id, communicationId));
        }

        #endregion
    }
}
