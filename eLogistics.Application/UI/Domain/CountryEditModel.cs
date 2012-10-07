using System;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class CountryEditModel : EditModel<CountryDto>
    {
        public CountryEditModel()
        {
        }

        public CountryEditModel(CountryDto dto) : base(dto)
        {
            if (this.CreatedNew)
            {
                Dto.CountryId = Guid.NewGuid();
                this.Send(new CountryCommands.Create(Dto.CountryId));
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
                    this.Send(new CountryCommands.ChangeName(Dto.CountryId, value));
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
