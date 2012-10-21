using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.UI;
using eLogistics.Application.UI.Domain;
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

        public CommunicationController Controller
        {
            get { return (CommunicationController) this.DataContext; }
            set { this.DataContext = value; }
        }

        private void OnAddItem(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.AddModel();
        }

        private void OnRemoveItem(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.RemoveModel();
        }
    }
}
