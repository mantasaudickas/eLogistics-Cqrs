using System;
using System.Collections.Generic;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for CountryListWindow.xaml
    /// </summary>
    public partial class CountryListWindow
    {
        private CountryController _controller;

        public CountryListWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new CountryController(this.listItems);
            _controller.Init();
        }

        public IList<CountryEditModel> Items { get { return _controller.ListBoxItems; } }

        private void OnAddItem(object sender, System.Windows.RoutedEventArgs e)
        {
            _controller.AddModel();
        }

        private void OnRemoveItem(object sender, System.Windows.RoutedEventArgs e)
        {
            _controller.RemoveModel();
        }
    }
}
