﻿using System;
using System.Windows;
using System.Windows.Input;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for BankEditWindow.xaml
    /// </summary>
    public partial class BankEditWindow : Window
    {
        public BankEditWindow()
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
    }
}
