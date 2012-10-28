using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Windows;

namespace eLogistics.Executable.Controllers
{
    public class SupplierController : ListBoxController<SupplierEditModel, SupplierDto>
    {
        public SupplierController(ListBox listBox, List<SupplierEditModel> parentList = null) : base(listBox, parentList)
        {
        }

        protected override SupplierEditModel CreateModel(SupplierDto dto = null)
        {
            return new SupplierEditModel(dto);
        }

        protected override IList<SupplierDto> GetList(string filter = null)
        {
            SupplierFacade facade = new SupplierFacade(ObjectFactory.Create<IReadModelStore>());
            GetSupplierListRequest request = new GetSupplierListRequest { Filter = filter };
            GetSupplierListResponse list = facade.GetSupplierList(request);
            return list != null ? list.SupplierList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new SupplierEditWindow();
        }
    }
}
