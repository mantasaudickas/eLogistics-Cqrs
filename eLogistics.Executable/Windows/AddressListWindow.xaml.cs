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
        public AddressListWindow()
        {
            InitializeComponent();
        }

        public void InitController(Owner owner, Guid ownerId)
        {
            this.DataContext = new AddressController(this.listItems, owner, ownerId);
        }

        private void OnAddItem(object sender, System.Windows.RoutedEventArgs e)
        {
            ((AddressController)DataContext).AddModel();
        }

        private void OnRemoveItem(object sender, System.Windows.RoutedEventArgs e)
        {
            ((AddressController)DataContext).RemoveModel();
        }
    }
}
