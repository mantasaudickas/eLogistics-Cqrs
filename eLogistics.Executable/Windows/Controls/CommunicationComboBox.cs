using System;
using System.Collections.Generic;
using System.Windows.Controls;
using eLogistics.Application.CQRS.Interfaces;

namespace eLogistics.Executable.Windows.Controls
{
    public class CommunicationComboBox : ComboBox
    {
        public CommunicationComboBox()
        {
            this.Loaded += OnLoaded;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // TODO: make translations from resources
            List<CommunicationTypeContainer> items = new List<CommunicationTypeContainer>();
            items.Add(new CommunicationTypeContainer {CommunicationType = CommunicationType.Phone, Name = "Telefonas"});
            items.Add(new CommunicationTypeContainer {CommunicationType = CommunicationType.Email, Name = "El. Paštas"});
            items.Add(new CommunicationTypeContainer {CommunicationType = CommunicationType.Fax, Name = "Faksas"});

            this.ItemsSource = items;
            this.DisplayMemberPath = "Name";
            this.SelectedValuePath = "CommunicationType";
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.SelectedValue == null)
                this.SelectedIndex = 0;
        }

        private class CommunicationTypeContainer
        {
            public CommunicationType CommunicationType { get; set; }
            public string Name { get; set; }
        }
    }
}
