using System;
using System.Windows.Controls;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Executable.Windows.Controls
{
    public class BankComboBox : ComboBox
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var facade = new BankFacade(ObjectFactory.Create<IReadModelStore>());
            var response = facade.GetBankList(new GetBankListRequest());
            if (response != null && response.BankList != null)
            {
                response.BankList.Sort((b1, b2) => String.Compare(b1.Name, b2.Name, StringComparison.Ordinal));
                this.ItemsSource = response.BankList;
                this.DisplayMemberPath = "Name";
                this.SelectedValuePath = "BankId";
            }
        }
    }
}
