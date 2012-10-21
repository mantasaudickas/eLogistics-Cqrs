﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

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

            CommunicationController communicationController = new CommunicationController(this.listCommunications.listItems, companyEditModel.CommunicationList);
            communicationController.Owner = Application.CQRS.Interfaces.Owner.Company;
            communicationController.OwnerId = companyEditModel.CompanyId;
            this.listCommunications.DataContext = communicationController;
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
