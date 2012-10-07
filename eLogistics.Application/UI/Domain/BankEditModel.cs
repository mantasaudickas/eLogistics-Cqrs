using System;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class BankEditModel : EditModel<BankDto>
    {
        public BankEditModel()
        {
        }

        public BankEditModel(BankDto dto) : base(dto)
        {
            if (this.CreatedNew)
            {
                Guid bankId = Guid.NewGuid();
                Dto.BankId = bankId;
                this.Send(new BankCommands.Create(bankId));
            }
        }

        public string Name
        {
            get { return Dto.Name; }
            set
            {
                if (value != Dto.Name)
                {
                    Dto.Name = value;
                    this.Send(new BankCommands.ChangeName(Dto.BankId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string Code
        {
            get { return Dto.Code; }
            set
            {
                if (value != Dto.Code)
                {
                    Dto.Code = value;
                    this.Send(new BankCommands.ChangeBankCode(Dto.BankId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string SwiftCode
        {
            get { return Dto.SwiftCode; }
            set
            {
                if (value != Dto.SwiftCode)
                {
                    Dto.SwiftCode = value;
                    this.Send(new BankCommands.ChangeBankSwiftCode(Dto.BankId, value));
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
                    this.Send(new BankCommands.ChangeNote(Dto.BankId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

    }
}
