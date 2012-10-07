using System;
using System.Windows.Controls;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;

namespace eLogistics.Executable.Windows.Controls
{
    public class CityComboBox : ComboBox
    {
        public CityComboBox()
        {
            this.Loaded += OnLoaded;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var facade = new CityFacade(ObjectFactory.Create<IReadModelStore>());
            var response = facade.GetCityList(new GetCityListRequest());
            if (response != null && response.CityList != null)
            {
                this.ItemsSource = response.CityList;
                this.DisplayMemberPath = "Name";
                this.SelectedValuePath = "CityId";
            }
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.SelectedValue == null)
                this.SelectedIndex = 0;
        }
    }
}
