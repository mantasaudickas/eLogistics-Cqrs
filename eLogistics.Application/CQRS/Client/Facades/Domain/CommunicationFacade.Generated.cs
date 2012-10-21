using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ICommunicationFacade
    {
        GetCommunicationListResponse GetCommunicationList(GetCommunicationListRequest request);
        GetCommunicationResponse GetCommunication(GetCommunicationRequest request);
    }

    public partial class CommunicationFacade : ReadModelFacade, ICommunicationFacade
    {
        public CommunicationFacade(IReadModelStore readModelStore) : base(readModelStore) {}        
        
        public GetCommunicationListResponse GetCommunicationList(GetCommunicationListRequest request)
        {
            CommunicationView view = new CommunicationView(ObjectFactory.Create<IReadModelStore>());
            List<CommunicationDto> list = view.GetList(request.Filter);

            if (list != null)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].Owner != request.Owner || list[i].OwnerId != request.OwnerId)
                        list.RemoveAt(i);
                }
            }

            GetCommunicationListResponse response = new GetCommunicationListResponse();
            response.CommunicationList = list;
            return response;
        }

        public GetCommunicationResponse GetCommunication(GetCommunicationRequest request)
        {
            CommunicationView view = new CommunicationView(ObjectFactory.Create<IReadModelStore>());
            CommunicationDto dto = view.Load(request.CommunicationId);
            GetCommunicationResponse response = new GetCommunicationResponse();
            response.Communication = dto;
            return response;
        }

    }
}
