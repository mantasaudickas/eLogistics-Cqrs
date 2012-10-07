using System;
using System.Collections.Generic;
using eLogistics.Application.CQRS.Interfaces;
using eLogistics.Application.UI.Domain;
using eLogistics.Executable.Controllers;

namespace eLogistics.Executable.Windows
{
    /// <summary>
    /// Interaction logic for CommunicationListWindow.xaml
    /// </summary>
    public partial class CommunicationListWindow
    {
        private CommunicationController _controller;

        public CommunicationListWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _controller = new CommunicationController(this.listItems, this.Owner, this.OwnerId);
            _controller.Init();
        }

        public Owner Owner { get; set; }
        public Guid OwnerId { get; set; }
        public IList<CommunicationEditModel> Items { get { return _controller.ListBoxItems; } }

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
