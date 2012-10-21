using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class CompanyEditModel : EditModel<CompanyDto>
    {
        public CompanyEditModel() : this(null)
        {
        }

        public CompanyEditModel(CompanyDto dto) : base(dto)
        {
            if (this.CreatedNew)
            {
                Guid companyId = Guid.NewGuid();
                Dto.CompanyId = companyId;
                this.Send(new CompanyCommands.Create(companyId));
            }
        }

        public Guid CompanyId { get { return Dto.CompanyId; } set {} }

        public string Name
        {
            get { return Dto.Name; }
            set
            {
                if (value != Dto.Name)
                {
                    Dto.Name = value;
                    this.Send(new CompanyCommands.ChangeName(Dto.CompanyId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string CompanyCode
        {
            get { return Dto.CompanyCode; }
            set
            {
                if (value != Dto.CompanyCode)
                {
                    Dto.CompanyCode = value;
                    this.Send(new CompanyCommands.ChangeCompanyCode(Dto.CompanyId, value, Dto.CompanyVatCode));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string CompanyVatCode
        {
            get { return Dto.CompanyVatCode; }
            set
            {
                if (value != Dto.CompanyVatCode)
                {
                    Dto.CompanyVatCode = value;
                    this.Send(new CompanyCommands.ChangeCompanyCode(Dto.CompanyId, Dto.CompanyCode, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string ContactPersonName
        {
            get { return Dto.ContactPersonName; }
            set
            {
                if (value != Dto.ContactPersonName)
                {
                    Dto.ContactPersonName = value;
                    this.Send(new CompanyCommands.ChangeContactPerson(Dto.CompanyId, value, Dto.ContactPhoneNo));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string ContactPhoneNo
        {
            get { return Dto.ContactPhoneNo; }
            set
            {
                if (value != Dto.ContactPhoneNo)
                {
                    Dto.ContactPhoneNo = value;
                    this.Send(new CompanyCommands.ChangeContactPerson(Dto.CompanyId, Dto.ContactPersonName, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string Note
        {
            get { return Dto.Note; }
            set
            {
                if (value != Dto.Note)
                {
                    Dto.Note = value;
                    this.Send(new CompanyCommands.ChangeNote(Dto.CompanyId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public List<AddressEditModel> AddressList { get; set; }
        public List<CommunicationEditModel> CommunicationList { get; set; }
    }
}
