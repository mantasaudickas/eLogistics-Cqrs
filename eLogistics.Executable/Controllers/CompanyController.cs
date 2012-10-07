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
    public class CompanyController : ListBoxController<CompanyEditModel, CompanyDto>
    {
        public CompanyController(ListBox listBox) : base(listBox)
        {
        }

        protected override CompanyEditModel CreateModel(CompanyDto dto = null)
        {
            return new CompanyEditModel(dto);
        }

        protected override IList<CompanyDto> GetList(string filter = null)
        {
            CompanyFacade facade = new CompanyFacade(ObjectFactory.Create<IReadModelStore>());
            GetCompanyListResponse response = facade.GetCompanyList(new GetCompanyListRequest {Filter = filter});
            return response != null ? response.CompanyList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new CompanyEditWindow();
        }
    }
}
