using System;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for PaymentTypeListWindow.xaml
    /// </summary>
    public partial class PaymentTypeListWindow
    {
        private PaymentTypesController _controller;

        public PaymentTypeListWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new PaymentTypesController(this.listItems);
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
