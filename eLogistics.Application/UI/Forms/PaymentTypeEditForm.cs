using System;
using System.Windows.Forms;
using eLogistics.Application.CQRS.Interfaces.Dto.Domain;
using eLogistics.Application.UI.Domain;

namespace eLogistics.Application.UI.Forms
{
    public partial class PaymentTypeEditForm : Form
    {
        public PaymentTypeEditForm()
        {
            InitializeComponent();
        }

        private PaymentTypeEditModel _editModel;

        public PaymentTypeDto CurrentObject { get { return _editModel.Dto; } }

        public void Bind(PaymentTypeEditModel model)
        {
            _editModel = model;
            this.textName.Text = _editModel.Name;
            this.checkIsCredit.Checked = _editModel.IsCredit;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _editModel.Name = this.textName.Text;
            _editModel.IsCredit = this.checkIsCredit.Checked;
        }
    }
}
