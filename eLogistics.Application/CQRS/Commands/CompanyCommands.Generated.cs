using System;
using System.Runtime.Serialization;
using eLogistics.Application.CQRS.Interfaces;
namespace eLogistics.Application.CQRS.Commands
{
    public partial class CompanyCommands
    {
        [DataContract]
        public class Create : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }

            public Create(Guid companyId) : base(companyId)
            {
                CompanyId = companyId;
            }
        }

        [DataContract]
        public class ChangeName : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string Name { get; private set; }

            public ChangeName(Guid companyId, string name) : base(companyId)
            {
                CompanyId = companyId;
                Name = name;
            }
        }

        [DataContract]
        public class ChangeCompanyCode : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string CompanyCode { get; private set; }
            [DataMember] public string CompanyVatCode { get; private set; }

            public ChangeCompanyCode(Guid companyId, string companyCode, string companyVatCode) : base(companyId)
            {
                CompanyId = companyId;
                CompanyCode = companyCode;
                CompanyVatCode = companyVatCode;
            }
        }

        [DataContract]
        public class ChangeContactPerson : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string ContactPersonName { get; private set; }
            [DataMember] public string ContactPhoneNo { get; private set; }

            public ChangeContactPerson(Guid companyId, string contactPersonName, string contactPhoneNo) : base(companyId)
            {
                CompanyId = companyId;
                ContactPersonName = contactPersonName;
                ContactPhoneNo = contactPhoneNo;
            }
        }

        [DataContract]
        public class ChangeNote : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public string Note { get; private set; }

            public ChangeNote(Guid companyId, string note) : base(companyId)
            {
                CompanyId = companyId;
                Note = note;
            }
        }

        [DataContract]
        public class AddAddress : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid AddressId { get; private set; }

            public AddAddress(Guid companyId, Guid addressId) : base(companyId)
            {
                CompanyId = companyId;
                AddressId = addressId;
            }
        }

        [DataContract]
        public class RemoveAddress : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid AddressId { get; private set; }

            public RemoveAddress(Guid companyId, Guid addressId) : base(companyId)
            {
                CompanyId = companyId;
                AddressId = addressId;
            }
        }

        [DataContract]
        public class AddCommunication : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid CommunicationId { get; private set; }

            public AddCommunication(Guid companyId, Guid communicationId) : base(companyId)
            {
                CompanyId = companyId;
                CommunicationId = communicationId;
            }
        }

        [DataContract]
        public class RemoveCommunication : Command
        {
            [DataMember] public Guid CompanyId { get; private set; }
            [DataMember] public Guid CommunicationId { get; private set; }

            public RemoveCommunication(Guid companyId, Guid communicationId) : base(companyId)
            {
                CompanyId = companyId;
                CommunicationId = communicationId;
            }
        }

    }
}
