using System;
using System.Collections.Generic;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for CompanyListWindow.xaml
    /// </summary>
    public partial class CompanyListWindow
    {
        private CompanyController _controller;

        public CompanyListWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new CompanyController(this.listItems);
            _controller.Init();
        }

        public IList<CompanyEditModel> Items { get { return _controller.ListBoxItems; } }

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
