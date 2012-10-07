using System;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class AddressEditModel : EditModel<AddressDto>
    {
        protected AddressEditModel()
        {

        }

        protected AddressEditModel(AddressDto dto) : base(dto)
        {
            if (this.CreatedNew)
            {
                Guid addressId = Guid.NewGuid();
                Dto.AddressId = addressId;
            }
        }

        public static AddressEditModel CreateNewModel(Owner owner, Guid ownerId)
        {
            AddressEditModel model = new AddressEditModel();
            model.Dto.Owner = owner;
            model.Dto.OwnerId = ownerId;
            model.Send(new AddressCommands.Create(model.Dto.AddressId, owner, ownerId));
            return model;
        }

        public static AddressEditModel CreateModel(AddressDto dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");

            return new AddressEditModel(dto);
        }

        public Guid CountryId
        {
            get { return Dto.CountryId; }
            set
            {
                if (Dto.CountryId != value)
                {
                    Dto.CountryId = value;
                    this.Send(new AddressCommands.ChangeCountry(Dto.AddressId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public Guid CityId
        {
            get { return Dto.CityId; }
            set
            {
                if (Dto.CityId != value)
                {
                    Dto.CityId = value;
                    this.Send(new AddressCommands.ChangeCity(Dto.AddressId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string Street
        {
            get { return Dto.Street; }
            set
            {
                if (Dto.Street != value)
                {
                    Dto.Street = value;
                    this.Send(new AddressCommands.ChangeStreet(Dto.AddressId, value, Dto.HouseNo));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string HouseNo
        {
            get { return Dto.HouseNo; }
            set
            {
                if (Dto.HouseNo != value)
                {
                    Dto.HouseNo = value;
                    this.Send(new AddressCommands.ChangeStreet(Dto.AddressId, Dto.Street, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string PostalCode
        {
            get { return Dto.PostalCode; }
            set
            {
                if (Dto.PostalCode != value)
                {
                    Dto.PostalCode = value;
                    this.Send(new AddressCommands.ChangePostalCode(Dto.AddressId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string Note
        {
            get { return Dto.Note; }
            set
            {
                if (Dto.Note != value)
                {
                    Dto.Note = value;
                    this.Send(new AddressCommands.ChangeNote(Dto.AddressId, value));
                    this.RaisePropertyChanged();
                }
            }
        }

    }
}
