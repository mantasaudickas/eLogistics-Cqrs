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
        private readonly Owner _owner;
        private readonly Guid _ownerId;

        public CommunicationController(ListBox listBox, Owner owner, Guid ownerId)
            : base(listBox)
        {
            _owner = owner;
            _ownerId = ownerId;
        }

        protected override CommunicationEditModel CreateModel(CommunicationDto dto = null)
        {
            if (dto == null)
                return CommunicationEditModel.CreateNewModel(_owner, _ownerId);

            if (dto.Owner != _owner)
                throw new Exception("Dto owner does not match controller expected owner.");

            if (dto.OwnerId != _ownerId)
                throw new Exception("Dto owner does not match controller expected owner id.");

            return CommunicationEditModel.CreateModel(dto);
        }

        protected override IList<CommunicationDto> GetList(string filter = null)
        {
            CommunicationFacade facade = new CommunicationFacade(ObjectFactory.Create<IReadModelStore>());
            var response = facade.GetCommunicationList(new GetCommunicationListRequest {Owner = _owner, OwnerId = _ownerId, Filter = filter});
            return response != null ? response.CommunicationList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new AddressEditWindow();
        }
    }
}
