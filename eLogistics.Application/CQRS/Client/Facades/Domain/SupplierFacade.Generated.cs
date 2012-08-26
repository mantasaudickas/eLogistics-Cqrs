using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ISupplierFacade
    {
        GetSupplierListResponse GetSupplierList(GetSupplierListRequest request);
        GetSupplierResponse GetSupplier(GetSupplierRequest request);
    }

    public partial class SupplierFacade : ReadModelFacade, ISupplierFacade
    {
    public SupplierFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetSupplierListResponse GetSupplierList(GetSupplierListRequest request)
        {
            SupplierView view = new SupplierView(ObjectFactory.Create<IReadModelStore>());
            List<SupplierDto> list = view.GetList(request.Filter);
            GetSupplierListResponse response = new GetSupplierListResponse();
            response.SupplierList = list;
            return response;

        }

        public GetSupplierResponse GetSupplier(GetSupplierRequest request)
        {
            SupplierView view = new SupplierView(ObjectFactory.Create<IReadModelStore>());
            SupplierDto dto = view.Load(request.SupplierId);
            GetSupplierResponse response = new GetSupplierResponse();
            response.Supplier = dto;
            return response;

        }

    }
}
