﻿using System;
using System.Collections.Generic;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for PaymentTypeListWindow.xaml
    /// </summary>
    public partial class PaymentTypeListWindow
    {
        private PaymentTypesController _controller;

        public PaymentTypeListWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new PaymentTypesController(this.listItems);
            _controller.Init();
        }

        public IList<PaymentTypeEditModel> Items { get { return _controller.ListBoxItems; } }

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
