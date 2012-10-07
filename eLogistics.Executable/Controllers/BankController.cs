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
    public class BankController : ListBoxController<BankEditModel, BankDto>
    {
        public BankController(ListBox listBox) : base(listBox)
        {
        }

        protected override BankEditModel CreateModel(BankDto dto = null)
        {
            return new BankEditModel(dto);
        }

        protected override IList<BankDto> GetList(string filter = null)
        {
            var facade = new BankFacade(ObjectFactory.Create<IReadModelStore>());
            var response = facade.GetBankList(new GetBankListRequest { Filter = filter });
            return response != null ? response.BankList : null;
        }

        protected override Window CreateEditWindow(bool modelEdit)
        {
            return new BankEditWindow();
        }
    }
}
