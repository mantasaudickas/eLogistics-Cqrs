using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ICompanyFacade
    {
        GetCompanyListResponse GetCompanyList(GetCompanyListRequest request);
        GetCompanyResponse GetCompany(GetCompanyRequest request);
    }

    public partial class CompanyFacade : ReadModelFacade, ICompanyFacade
    {
    public CompanyFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetCompanyListResponse GetCompanyList(GetCompanyListRequest request)
        {
            CompanyView view = new CompanyView(ObjectFactory.Create<IReadModelStore>());
            List<CompanyDto> list = view.GetList(request.Filter);
            GetCompanyListResponse response = new GetCompanyListResponse();
            response.CompanyList = list;
            return response;

        }

        public GetCompanyResponse GetCompany(GetCompanyRequest request)
        {
            CompanyView view = new CompanyView(ObjectFactory.Create<IReadModelStore>());
            CompanyDto dto = view.Load(request.CompanyId);
            GetCompanyResponse response = new GetCompanyResponse();
            response.Company = dto;
            return response;

        }

    }
}
