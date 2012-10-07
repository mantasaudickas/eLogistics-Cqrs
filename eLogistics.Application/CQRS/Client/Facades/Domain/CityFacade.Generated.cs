using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ICityFacade
    {
        GetCityListResponse GetCityList(GetCityListRequest request);
        GetCityResponse GetCity(GetCityRequest request);
    }

    public partial class CityFacade : ReadModelFacade, ICityFacade
    {
    public CityFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetCityListResponse GetCityList(GetCityListRequest request)
        {
            CityView view = new CityView(ObjectFactory.Create<IReadModelStore>());
            List<CityDto> list = view.GetList(request.Filter);
            GetCityListResponse response = new GetCityListResponse();
            response.CityList = list;
            return response;

        }

        public GetCityResponse GetCity(GetCityRequest request)
        {
            CityView view = new CityView(ObjectFactory.Create<IReadModelStore>());
            CityDto dto = view.Load(request.CityId);
            GetCityResponse response = new GetCityResponse();
            response.City = dto;
            return response;

        }

    }
}
