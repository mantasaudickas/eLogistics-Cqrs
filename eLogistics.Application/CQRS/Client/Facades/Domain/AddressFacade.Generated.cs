using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IAddressFacade
    {
        GetAddressListResponse GetAddressList(GetAddressListRequest request);
        GetAddressResponse GetAddress(GetAddressRequest request);
    }

    public partial class AddressFacade : ReadModelFacade, IAddressFacade
    {
        public AddressFacade(IReadModelStore readModelStore) : base(readModelStore) {}        
        
        public GetAddressListResponse GetAddressList(GetAddressListRequest request)
        {
            AddressView view = new AddressView(ObjectFactory.Create<IReadModelStore>());
            List<AddressDto> list = view.GetList(request.Filter);

            if (list != null)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].Owner != request.Owner || list[i].OwnerId != request.OwnerId)
                        list.RemoveAt(i);
                }
            }

            GetAddressListResponse response = new GetAddressListResponse();
            response.AddressList = list;
            return response;

        }

        public GetAddressResponse GetAddress(GetAddressRequest request)
        {
            AddressView view = new AddressView(ObjectFactory.Create<IReadModelStore>());
            AddressDto dto = view.Load(request.AddressId);
            GetAddressResponse response = new GetAddressResponse();
            response.Address = dto;
            return response;

        }

    }
}
