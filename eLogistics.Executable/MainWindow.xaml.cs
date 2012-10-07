using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using eLogistics.Executable.Suppliers;
using eLogistics.Executable.Windows;

namespace eLogistics.Executable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDictionary<string, UserControl> _createdControls = new Dictionary<string, UserControl>();
        private UserControl _currentControl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListViewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = listView.SelectedValue as ListViewItem;
            if (item != null)
            {
                UserControl userControl = null;

                if (!_createdControls.TryGetValue(item.Name, out userControl))
                {
                    switch (item.Name)
                    {
                        case "PaymentTypes":
                            userControl = new PaymentTypeListWindow();
                            break;
                        case "Countries":
                            userControl = new CountryListWindow();
                            break;
                        case "Cities":
                            userControl = new CityListWindow();
                            break;
                        case "Banks":
                            userControl = new BankListWindow();
                            break;
                        case "Companies":
                            userControl = new CompanyListWindow();
                            break;
                        case "Suppliers":
                            userControl = new SuppliersPage();
                            break;
                        default:
                            break;
                    }

                    if (userControl != null)
                    {
                        _createdControls.Add(item.Name, userControl);
                    }
                }

                if (_currentControl != null)
                {
                    gridMaster.Children.Remove(_currentControl);
                    _currentControl = null;
                }

                if (userControl != null)
                {
                    gridMaster.Children.Add(userControl);
                    Grid.SetColumn(userControl, 1);

                    _currentControl = userControl;
                }
            }
        }
    }
}
