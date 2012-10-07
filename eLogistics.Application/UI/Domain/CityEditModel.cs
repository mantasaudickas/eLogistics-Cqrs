using System;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class CityEditModel : EditModel<CityDto>
    {
        public CityEditModel()
        {
        }

        public CityEditModel(CityDto dto) : base(dto)
        {
            if (this.CreatedNew)
            {
                Guid cityId = Guid.NewGuid();
                Dto.CityId = cityId;
                this.Send(new CityCommands.Create(cityId));
            }
        }

        public Guid CountryId
        {
            get { return Dto.CountryId; }
            set
            {
                if (value != Dto.CountryId)
                {
                    Dto.CountryId = value;
                    this.Send(new CityCommands.ChangeCountry(Dto.CityId, value));
                    this.RaisePropertyChanged();
                }
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
                    this.Send(new CityCommands.ChangeName(Dto.CityId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

    }
}
