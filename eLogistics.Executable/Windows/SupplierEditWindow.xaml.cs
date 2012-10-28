using System;
using System.Windows;
using System.Windows.Input;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.UI.Domain;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for SupplierEditWindow.xaml
    /// </summary>
    public partial class SupplierEditWindow : Window
    {
        public SupplierEditWindow()
        {
            InitializeComponent();

            Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
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

        private void OnButtonAddBankAccountClick(object sender, RoutedEventArgs e)
        {
            BankAccountEditWindow editWindow = new BankAccountEditWindow();
            editWindow.DataContext = new BankAccount();
            if (editWindow.ShowDialog().GetValueOrDefault())
            {
                ((SupplierEditModel) this.DataContext).BankAccounts.Add((BankAccount) editWindow.DataContext);
            }
        }

        private void OnButtonRemoveBankAccountClick(object sender, RoutedEventArgs e)
        {
            ((SupplierEditModel) this.DataContext).BankAccounts.Remove((BankAccount) this.listItems.SelectedItem);
        }
    }
}
