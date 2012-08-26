using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface ISupplierInvoiceFacade
    {
        GetSupplierInvoiceListResponse GetSupplierInvoiceList(GetSupplierInvoiceListRequest request);
        GetSupplierInvoiceResponse GetSupplierInvoice(GetSupplierInvoiceRequest request);
    }

    public partial class SupplierInvoiceFacade : ReadModelFacade, ISupplierInvoiceFacade
    {
    public SupplierInvoiceFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetSupplierInvoiceListResponse GetSupplierInvoiceList(GetSupplierInvoiceListRequest request)
        {
            SupplierInvoiceView view = new SupplierInvoiceView(ObjectFactory.Create<IReadModelStore>());
            List<SupplierInvoiceDto> list = view.GetList(request.Filter);
            GetSupplierInvoiceListResponse response = new GetSupplierInvoiceListResponse();
            response.SupplierInvoiceList = list;
            return response;

        }

        public GetSupplierInvoiceResponse GetSupplierInvoice(GetSupplierInvoiceRequest request)
        {
            SupplierInvoiceView view = new SupplierInvoiceView(ObjectFactory.Create<IReadModelStore>());
            SupplierInvoiceDto dto = view.Load(request.SupplierInvoiceId);
            GetSupplierInvoiceResponse response = new GetSupplierInvoiceResponse();
            response.SupplierInvoice = dto;
            return response;

        }

    }
}
