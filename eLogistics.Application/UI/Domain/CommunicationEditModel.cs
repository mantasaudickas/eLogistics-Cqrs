using System;
using eLogistics.Application.CQRS.Commands;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;

namespace eLogistics.Application.UI.Domain
{
    public class CommunicationEditModel : EditModel<CommunicationDto>
    {
        public CommunicationEditModel() : this(null)
        {
        }

        protected CommunicationEditModel(CommunicationDto dto)
            : base(dto)
        {
            if (this.CreatedNew)
            {
                Guid communicationId = Guid.NewGuid();
                Dto.CommunicationId = communicationId;
            }
        }

        public static CommunicationEditModel CreateNewModel(Owner owner, Guid ownerId)
        {
            CommunicationEditModel model = new CommunicationEditModel();
            model.Dto.Owner = owner;
            model.Dto.OwnerId = ownerId;
            model.Send(new CommunicationCommands.Create(model.Dto.CommunicationId, owner, ownerId));
            return model;
        }

        public static CommunicationEditModel CreateModel(CommunicationDto dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");

            return new CommunicationEditModel(dto);
        }

        public CommunicationType CommunicationType
        {
            get { return Dto.CommunicationType; }
            set
            {
                if (Dto.CommunicationType != value)
                {
                    Dto.CommunicationType = value;
                    this.Send(new CommunicationCommands.ChangeValue(Dto.CommunicationId, value, Dto.Value));
                    this.RaisePropertyChanged();
                }
            }
        }

        public string Value
        {
            get { return Dto.Value; }
            set
            {
                if (Dto.Value != value)
                {
                    Dto.Value = value;
                    this.Send(new CommunicationCommands.ChangeValue(Dto.CommunicationId, Dto.CommunicationType, value));
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
                    this.Send(new CommunicationCommands.ChangeNote(Dto.CommunicationId, value));
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
