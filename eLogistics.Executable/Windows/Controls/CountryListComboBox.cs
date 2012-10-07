using System;
using System.Windows.Controls;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Executable.Windows.Controls
{
    public class CountryListComboBox : ComboBox
    {
        public CountryListComboBox()
        {
            this.Loaded += OnLoaded;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            CountryFacade facade = new CountryFacade(ObjectFactory.Create<IReadModelStore>());
            GetCountryListResponse response = facade.GetCountryList(new GetCountryListRequest());
            if (response != null && response.CountryList != null)
            {
                this.ItemsSource = response.CountryList;
                this.DisplayMemberPath = "Name";
                this.SelectedValuePath = "CountryId";
            }
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.SelectedValue == null)
                this.SelectedIndex = 0;
        }
    }
}
