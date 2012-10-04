using System;
using System.Collections.ObjectModel;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for PaymentTypeListWindow.xaml
    /// </summary>
    public partial class PaymentTypeListWindow
    {
        private readonly PaymentTypesController _controller;

        public PaymentTypeListWindow()
        {
            InitializeComponent();

            _controller = new PaymentTypesController(this.listItems);
            this.DataContext = this;
        }

        public ObservableCollection<PaymentTypeEditModel> PaymentTypeList { get { return _controller.PaymentTypeList; } }

        private void OnAddItem(object sender, System.Windows.RoutedEventArgs e)
        {
            _controller.EditNew();
        }

        private void OnRemoveItem(object sender, System.Windows.RoutedEventArgs e)
        {
            _controller.RemoveSelected();
        }
    }
}
