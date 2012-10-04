using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using eLogistics.Executable.Suppliers;
using eLogistics.Executable.Windows;

namespace eLogistics.Executable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserControl currentControl = null;

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
                switch (item.Name)
                {
                    case "PaymentTypes":
                        userControl = new PaymentTypeListWindow();
                        break;
                    case "Suppliers":
                        userControl = new SuppliersPage();
                        break;
                    default:
                        break;
                }

                if (currentControl != null)
                {
                    gridMaster.Children.Remove(currentControl);
                    currentControl = null;
                }

                if (userControl != null)
                {
                    gridMaster.Children.Add(userControl);
                    Grid.SetColumn(userControl, 1);

                    currentControl = userControl;
                }
            }
        }
    }
}
