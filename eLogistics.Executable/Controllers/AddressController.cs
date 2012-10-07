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
    public class AddressController : ListBoxController<AddressEditModel, AddressDto>
    {
        private readonly Owner _owner;
        private readonly Guid _ownerId;

        public AddressController(ListBox listBox, Owner owner, Guid ownerId) : base(listBox)
        {
            _owner = owner;
            _ownerId = ownerId;
        }

        protected override AddressEditModel CreateModel(AddressDto dto = null)
        {
            if (dto == null)
                return AddressEditModel.CreateNewModel(_owner, _ownerId);

            if (dto.Owner != _owner)
                throw new Exception("Dto owner does not match controller expected owner.");

            if (dto.OwnerId != _ownerId)
                throw new Exception("Dto owner does not match controller expected owner id.");

            return AddressEditModel.CreateModel(dto);
        }

        protected override IList<AddressDto> GetList(string filter = null)
        {
            AddressFacade facade = new AddressFacade(ObjectFactory.Create<IReadModelStore>());
            GetAddressListResponse response = facade.GetAddressList(new GetAddressListRequest {Owner = _owner, OwnerId = _ownerId, Filter = filter});
            return response != null ? response.AddressList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new AddressEditWindow();
        }
    }
}
