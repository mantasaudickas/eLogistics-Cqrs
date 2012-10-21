using System;
using System.Windows;
using System.Windows.Input;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.UI.Domain;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for CompanyEditWindow.xaml
    /// </summary>
    public partial class CompanyEditWindow : Window
    {
        public CompanyEditWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            
            CompanyEditModel companyEditModel = (CompanyEditModel)this.DataContext;
            const Owner owner = Application.CQRS.Interfaces.Owner.Company;
            Guid companyId = companyEditModel.CompanyId;

            this.listCommunications.InitController(owner, companyId);
            this.listAddresses.InitController(owner, companyId);
        }

        private void OnButtonOkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void OnButtonCancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
