using System;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for CommunicationListWindow.xaml
    /// </summary>
    public partial class CommunicationListWindow
    {
        public CommunicationListWindow()
        {
            InitializeComponent();
        }

        public void InitController(Owner owner, Guid ownerId)
        {
            this.DataContext = new CommunicationController(this.listItems, owner, ownerId);
        }

        private void OnAddItem(object sender, System.Windows.RoutedEventArgs e)
        {
            ((CommunicationController)DataContext).AddModel();
        }

        private void OnRemoveItem(object sender, System.Windows.RoutedEventArgs e)
        {
            ((CommunicationController)DataContext).RemoveModel();
        }
    }
}
