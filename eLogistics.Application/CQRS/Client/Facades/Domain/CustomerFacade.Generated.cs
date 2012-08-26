using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ICustomerFacade
    {
        GetCustomerListResponse GetCustomerList(GetCustomerListRequest request);
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
    }

    public partial class CustomerFacade : ReadModelFacade, ICustomerFacade
    {
    public CustomerFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetCustomerListResponse GetCustomerList(GetCustomerListRequest request)
        {
            CustomerView view = new CustomerView(ObjectFactory.Create<IReadModelStore>());
            List<CustomerDto> list = view.GetList(request.Filter);
            GetCustomerListResponse response = new GetCustomerListResponse();
            response.CustomerList = list;
            return response;

        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            CustomerView view = new CustomerView(ObjectFactory.Create<IReadModelStore>());
            CustomerDto dto = view.Load(request.CustomerId);
            GetCustomerResponse response = new GetCustomerResponse();
            response.Customer = dto;
            return response;

        }

    }
}
