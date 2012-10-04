using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
using eLogistics.Application.UI.Domain;
using eLogistics.Application.UI.Forms;
using eLogistics.Executable.Windows;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using ListBox = System.Windows.Controls.ListBox;

namespace eLogistics.Executable.Controllers
{
    public class PaymentTypesController
    {
        private readonly ListBox _listBox;
        private readonly ObservableCollection<PaymentTypeEditModel> _paymentTypeList = new ObservableCollection<PaymentTypeEditModel>();

        public PaymentTypesController(ListBox listBox)
        {
            _listBox = listBox;
            this._listBox.KeyDown += (sender, args) => HandleListItemsKeys(args);
            this._listBox.MouseDoubleClick += (sender, args) => HandleListItemsDoubleClick(args);

            PaymentTypeFacade facade = new PaymentTypeFacade(ObjectFactory.Create<IReadModelStore>());
            GetPaymentTypeListResponse list = facade.GetPaymentTypeList(new GetPaymentTypeListRequest());
            if (list != null)
            {
                foreach (var dto in list.PaymentTypeList)
                {
                    _paymentTypeList.Add(new PaymentTypeEditModel(dto));
                }
            }
        }

        public ObservableCollection<PaymentTypeEditModel> PaymentTypeList
        {
            get { return _paymentTypeList; }
        }

        private void HandleListItemsDoubleClick(MouseButtonEventArgs args)
        {
            EditSelected();
        }

        private void HandleListItemsKeys(KeyEventArgs args)
        {
            if (args.Key == Key.Insert)
            {
                this.EditNew();
            }
            else if (args.Key == Key.Enter)
            {
                this.EditSelected();
            }
        }

        public void EditNew()
        {
            PaymentTypeEditModel editModel = new PaymentTypeEditModel(null);
            if (this.Edit(editModel))
            {
                editModel.Commit();

                this.PaymentTypeList.Add(editModel);
                this._listBox.SelectedItem = editModel;
            }
        }

        public void EditSelected()
        {
            PaymentTypeEditModel editModel = (PaymentTypeEditModel)_listBox.SelectedItem;
            if (editModel != null)
            {
                if (this.Edit(editModel))
                {
                    editModel.Commit();
                }
            }
        }

        public void RemoveSelected()
        {
            PaymentTypeEditModel editModel = (PaymentTypeEditModel)_listBox.SelectedItem;
            if (editModel != null)
            {
                editModel.Delete();
                editModel.Commit();
                _paymentTypeList.Remove(editModel);
            }
        }

        private bool Edit(PaymentTypeEditModel editModel)
        {
            PaymentTypeEditWindow window = new PaymentTypeEditWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowInTaskbar = false;
            window.DataContext = editModel;
            return window.ShowDialog().GetValueOrDefault();
        }
    }
}
