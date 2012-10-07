using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class CityController : ListBoxController<CityEditModel, CityDto>
    {
        public CityController(ListBox listBox)
            : base(listBox)
        {
        }

        protected override CityEditModel CreateModel(CityDto dto = null)
        {
            return new CityEditModel(dto);
        }

        protected override IList<CityDto> GetList(string filter = null)
        {
            CityFacade facade = new CityFacade(ObjectFactory.Create<IReadModelStore>());
            GetCityListResponse response = facade.GetCityList(new GetCityListRequest {Filter = filter});
            return response != null ? response.CityList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new CityEditWindow();
        }
    }
}
