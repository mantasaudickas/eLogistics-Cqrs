using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Windows;

namespace eLogistics.Executable.Controllers
{
    public class CommunicationController : ListBoxController<CommunicationEditModel, CommunicationDto>
    {
        private Owner _owner;
        private Guid _ownerId;

        public CommunicationController(ListBox listBox, List<CommunicationEditModel> parentList)
            : base(listBox, parentList)
        {
        }

        public Owner Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public Guid OwnerId
        {
            get { return _ownerId; }
            set { _ownerId = value; }
        }

        protected override CommunicationEditModel CreateModel(CommunicationDto dto = null)
        {
            if (dto == null)
                return CommunicationEditModel.CreateNewModel(this.Owner, this.OwnerId);

            if (dto.Owner != this.Owner)
                throw new Exception("Dto owner does not match controller expected owner.");

            if (dto.OwnerId != this.OwnerId)
                throw new Exception("Dto owner does not match controller expected owner id.");

            return CommunicationEditModel.CreateModel(dto);
        }

        protected override IList<CommunicationDto> GetList(string filter = null)
        {
            CommunicationFacade facade = new CommunicationFacade(ObjectFactory.Create<IReadModelStore>());
            var response = facade.GetCommunicationList(new GetCommunicationListRequest {Owner = this.Owner, OwnerId = this.OwnerId, Filter = filter});
            return response != null ? response.CommunicationList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new CommunicationEditWindow();
        }
    }
}
