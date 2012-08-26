using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Client.Views;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
namespace eLogistics.Application.CQRS.Client.Facades.Domain
{
    public partial interface IPaymentTypeFacade
    {
        GetPaymentTypeListResponse GetPaymentTypeList(GetPaymentTypeListRequest request);
        GetPaymentTypeResponse GetPaymentType(GetPaymentTypeRequest request);
    }

    public partial class PaymentTypeFacade : ReadModelFacade, IPaymentTypeFacade
    {
    public PaymentTypeFacade(IReadModelStore readModelStore) : base(readModelStore) {}        public GetPaymentTypeListResponse GetPaymentTypeList(GetPaymentTypeListRequest request)
        {
            PaymentTypeView view = new PaymentTypeView(ObjectFactory.Create<IReadModelStore>());
            List<PaymentTypeDto> list = view.GetList(request.Filter);
            GetPaymentTypeListResponse response = new GetPaymentTypeListResponse();
            response.PaymentTypeList = list;
            return response;

        }

        public GetPaymentTypeResponse GetPaymentType(GetPaymentTypeRequest request)
        {
            PaymentTypeView view = new PaymentTypeView(ObjectFactory.Create<IReadModelStore>());
            PaymentTypeDto dto = view.Load(request.PaymentTypeId);
            GetPaymentTypeResponse response = new GetPaymentTypeResponse();
            response.PaymentType = dto;
            return response;

        }

    }
}
