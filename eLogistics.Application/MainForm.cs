using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinListBar;
using eLogistics.Application.UI.Forms;

namespace eLogistics.Application
{
    public partial class MainForm : Form
    {
        private readonly IDictionary<Type, Form> _shownForms = new Dictionary<Type, Form>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ultraListBar_ItemSelected(object sender, ItemEventArgs e)
        {
            try
            {
                Item selectedItem = e.Item;
                if (selectedItem != null)
                {
                    Type formTypeToShow = null;
                    switch (selectedItem.Key)
                    {
                        case "PaymentTypes":
                            formTypeToShow = typeof(PaymentTypeListForm);
                            break;
                        case "Suppliers":
                            formTypeToShow = typeof (SupplierListForm);
                            break;
                        case "Customers":
                            formTypeToShow = typeof (CustomerListForm);
                            break;
                        case "ArticleGroups":
                            formTypeToShow = typeof (ArticleGroupListForm);
                            break;
                        case "Articles":
                            formTypeToShow = typeof (ArticleListForm);
                            break;
                        case "SupplierInvoices":
                            formTypeToShow = typeof (SupplierInvoiceListForm);
                            break;
                        case "Orders":
                            formTypeToShow = typeof (OrderListForm);
                            break;
                    }

                    if (formTypeToShow != null)
                    {
                        Form formToShow;
                        if (!_shownForms.TryGetValue(formTypeToShow, out formToShow))
                        {
                            formToShow = (Form) Activator.CreateInstance(formTypeToShow);
                            formToShow.MdiParent = this;
                            formToShow.WindowState = FormWindowState.Maximized;
                            formToShow.Closed += (o, args) => _shownForms.Remove(formTypeToShow);
                            formToShow.Show();
                            _shownForms.Add(formTypeToShow, formToShow);
                        }
                        else
                        {
                            formToShow.Activate();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
