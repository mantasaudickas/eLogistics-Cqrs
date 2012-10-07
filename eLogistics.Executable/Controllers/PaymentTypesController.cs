using System;
using System.Collections.Generic;
using System.Windows;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Windows;
using ListBox = System.Windows.Controls.ListBox;

namespace eLogistics.Executable.Controllers
{
    public class PaymentTypesController : ListBoxController<PaymentTypeEditModel, PaymentTypeDto>
    {
        public PaymentTypesController(ListBox listBox) : base(listBox)
        {
        }

        protected override PaymentTypeEditModel CreateModel(PaymentTypeDto dto = null)
        {
            return new PaymentTypeEditModel(dto);
        }

        protected override IList<PaymentTypeDto> GetList(string filter = null)
        {
            PaymentTypeFacade facade = new PaymentTypeFacade(ObjectFactory.Create<IReadModelStore>());
            GetPaymentTypeListRequest request = new GetPaymentTypeListRequest {Filter = filter};
            GetPaymentTypeListResponse list = facade.GetPaymentTypeList(request);
            return list != null ? list.PaymentTypeList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new PaymentTypeEditWindow();
        }
    }
}
