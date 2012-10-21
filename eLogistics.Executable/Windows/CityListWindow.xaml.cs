using System;
using System.Collections.Generic;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for CityListWindow.xaml
    /// </summary>
    public partial class CityListWindow
    {
        private CityController _controller;

        public CityListWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new CityController(this.listItems);
            this.DataContext = _controller;
        }

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
