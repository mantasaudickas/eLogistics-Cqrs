﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;
using eLogistics.Executable.Windows.Controls;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for BankListWindow.xaml
    /// </summary>
    public partial class BankListWindow
    {
        private BankController _controller;
        public static WidthConverter test = new WidthConverter();

        public BankListWindow()
        {
            this.DataContext = new List<BankEditModel>();
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new BankController(this.listItems);
            _controller.Init();
            this.DataContext = _controller.ListBoxItems;
        }

        public IList<BankEditModel> Items { get { return _controller.ListBoxItems; } }

        private void OnAddItem(object sender, System.Windows.RoutedEventArgs e)
        {
            BindingExpression expression = listItems.GetBindingExpression(ListView.ItemsSourceProperty);
            _controller.AddModel();
        }

        private void OnRemoveItem(object sender, System.Windows.RoutedEventArgs e)
        {
            _controller.RemoveModel();
        }
    }
}