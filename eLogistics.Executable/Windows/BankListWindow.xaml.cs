using System;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for BankListWindow.xaml
    /// </summary>
    public partial class BankListWindow
    {
        private BankController _controller;

        public BankListWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new BankController(this.listItems);
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
