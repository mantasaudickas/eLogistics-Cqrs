namespace eLogistics.Application.UI.Forms
{
    partial class PaymentTypeEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.textName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.checkIsCredit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.buttonOk = new Infragistics.Win.Misc.UltraButton();
            this.buttonCancel = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.textName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(126, 23);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Mokėjimo tipas:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(144, 12);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(191, 21);
            this.textName.TabIndex = 1;
            // 
            // checkIsCredit
            // 
            this.checkIsCredit.Location = new System.Drawing.Point(144, 39);
            this.checkIsCredit.Name = "checkIsCredit";
            this.checkIsCredit.Size = new System.Drawing.Size(196, 20);
            this.checkIsCredit.TabIndex = 2;
            // 
            // ultraLabel2
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.Location = new System.Drawing.Point(12, 38);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(126, 23);
            this.ultraLabel2.TabIndex = 3;
            this.ultraLabel2.Text = "Kreditinis mokėjimas";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(179, 65);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Gerai";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(260, 65);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Atšaukti";
            // 
            // PaymentTypeEditForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(347, 96);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.checkIsCredit);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.ultraLabel1);
            this.Name = "PaymentTypeEditForm";
            this.Text = "Mokėjimo tipas";
            ((System.ComponentModel.ISupportInitialize)(this.textName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor textName;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkIsCredit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraButton buttonOk;
        private Infragistics.Win.Misc.UltraButton buttonCancel;
    }
}