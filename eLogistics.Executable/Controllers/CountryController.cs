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
    public class CountryController : ListBoxController<CountryEditModel, CountryDto>
    {
        public CountryController(ListBox listBox) : base(listBox)
        {
        }

        protected override CountryEditModel CreateModel(CountryDto dto = null)
        {
            return new CountryEditModel(dto);
        }

        protected override IList<CountryDto> GetList(string filter = null)
        {
            CountryFacade facade = new CountryFacade(ObjectFactory.Create<IReadModelStore>());
            GetCountryListResponse response = facade.GetCountryList(new GetCountryListRequest {Filter = filter});
            return response != null ? response.CountryList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new CountryEditWindow();
        }
    }
}
