using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for AddressListWindow.xaml
    /// </summary>
    public partial class AddressListWindow
    {
        private AddressController _controller;

        public AddressListWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new AddressController(this.listItems, this.Owner, this.OwnerId);
            this.DataContext = _controller;
        }

        public Owner Owner { get; set; }
        public Guid OwnerId { get; set; }

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
