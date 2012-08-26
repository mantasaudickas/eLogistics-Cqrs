using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Service.Events
{
    public partial class CompanyEvents
    {
        [DataContract]
        public class Created : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }

            public Created(Guid companyId) : base(companyId)
            {
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class NameChanged : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public NameChanged(Guid companyId, string name) : base(companyId)
            {
                CompanyId = companyId;
                Name = name;
            }
        }

        [DataContract]
        public class CompanyCodeChanged : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string CompanyCode { get; private set; }
            [DataMember] public string CompanyVatCode { get; private set; }

            public CompanyCodeChanged(Guid companyId, string companyCode, string companyVatCode) : base(companyId)
            {
                CompanyId = companyId;
                CompanyCode = companyCode;
                CompanyVatCode = companyVatCode;
            }
        }

        [DataContract]
        public class ContactPersonChanged : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string ContactPersonName { get; private set; }
            [DataMember] public string ContactPhoneNo { get; private set; }

            public ContactPersonChanged(Guid companyId, string contactPersonName, string contactPhoneNo) : base(companyId)
            {
                CompanyId = companyId;
                ContactPersonName = contactPersonName;
                ContactPhoneNo = contactPhoneNo;
            }
        }

        [DataContract]
        public class NoteChanged : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public NoteChanged(Guid companyId, string note) : base(companyId)
            {
                CompanyId = companyId;
                Note = note;
            }
        }

        [DataContract]
        public class AddressAdded : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid AddressId { get; private set; }

            public AddressAdded(Guid companyId, Guid addressId) : base(companyId)
            {
                CompanyId = companyId;
                AddressId = addressId;
            }
        }

        [DataContract]
        public class AddressRemoved : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid AddressId { get; private set; }

            public AddressRemoved(Guid companyId, Guid addressId) : base(companyId)
            {
                CompanyId = companyId;
                AddressId = addressId;
            }
        }

        [DataContract]
        public class CommunicationAdded : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid CommunicationId { get; private set; }

            public CommunicationAdded(Guid companyId, Guid communicationId) : base(companyId)
            {
                CompanyId = companyId;
                CommunicationId = communicationId;
            }
        }

        [DataContract]
        public class CommunicationRemoved : Event
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid CommunicationId { get; private set; }

            public CommunicationRemoved(Guid companyId, Guid communicationId) : base(companyId)
            {
                CompanyId = companyId;
                CommunicationId = communicationId;
            }
        }

    }
}
