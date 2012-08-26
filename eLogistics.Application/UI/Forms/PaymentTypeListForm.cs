using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using eLogistics.Application.CQRS;
using eLogistics.Application.CQRS.Client.Facades.Domain;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.CQRS.Interfaces.Messages.Domain;
using eLogistics.Application.CQRS.Service.Storage;
using eLogistics.Application.UI.Domain;

namespace eLogistics.Application.UI.Forms
{
    public partial class PaymentTypeListForm : Form
    {
        private BindingList<PaymentTypeDto> _dtoList;

        public PaymentTypeListForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                PaymentTypeFacade facade = new PaymentTypeFacade(ObjectFactory.Create<IReadModelStore>());
                GetPaymentTypeListResponse response = facade.GetPaymentTypeList(new GetPaymentTypeListRequest());
                _dtoList = new BindingList<PaymentTypeDto>(response.PaymentTypeList ?? new List<PaymentTypeDto>());

                this.ultraGridPaymentTypes.DisplayLayout.NewColumnLoadStyle = NewColumnLoadStyle.Hide;
                this.ultraGridPaymentTypes.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
                this.ultraGridPaymentTypes.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
                this.ultraGridPaymentTypes.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnValidation;
            
                this.ultraGridPaymentTypes.DataSource = _dtoList;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentTypeEditModel editModel = new PaymentTypeEditModel(null);
                bool accepted = false;

                using (PaymentTypeEditForm editForm = new PaymentTypeEditForm())
                {
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    editForm.Bind(editModel);
                    accepted = editForm.ShowDialog(this) == DialogResult.OK;
                }

                if (accepted)
                {
                    editModel.Commit();
                    _dtoList.Add(editModel.Dto);
                }
                else
                    editModel.Delete();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                UltraGridRow row = this.ultraGridPaymentTypes.ActiveRow;
                if (row != null)
                {
                    PaymentTypeDto listObject = (PaymentTypeDto) row.ListObject;

                    PaymentTypeEditModel editModel = new PaymentTypeEditModel(listObject);
                    bool accepted = false;

                    using (PaymentTypeEditForm editForm = new PaymentTypeEditForm())
                    {
                        editForm.StartPosition = FormStartPosition.CenterParent;
                        editForm.Bind(editModel);
                        accepted = editForm.ShowDialog(this) == DialogResult.OK;
                    }

                    if (accepted)
                        editModel.Commit();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            UltraGridRow row = this.ultraGridPaymentTypes.ActiveRow;
            if (row != null)
            {
                PaymentTypeDto listObject = (PaymentTypeDto) row.ListObject;
                PaymentTypeEditModel editModel = new PaymentTypeEditModel(listObject);

                editModel.Delete();
                editModel.Commit();
                _dtoList.Remove(listObject);
            }
        }
    }
}
