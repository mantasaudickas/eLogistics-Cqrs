using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ICountryFacade
    {
        GetCountryListResponse GetCountryList(GetCountryListRequest request);
        GetCountryResponse GetCountry(GetCountryRequest request);
    }

    public partial class CountryFacade : ReadModelFacade, ICountryFacade
    {
    public CountryFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetCountryListResponse GetCountryList(GetCountryListRequest request)
        {
            CountryView view = new CountryView(ObjectFactory.Create<IReadModelStore>());
            List<CountryDto> list = view.GetList(request.Filter);
            GetCountryListResponse response = new GetCountryListResponse();
            response.CountryList = list;
            return response;

        }

        public GetCountryResponse GetCountry(GetCountryRequest request)
        {
            CountryView view = new CountryView(ObjectFactory.Create<IReadModelStore>());
            CountryDto dto = view.Load(request.CountryId);
            GetCountryResponse response = new GetCountryResponse();
            response.Country = dto;
            return response;

        }

    }
}
