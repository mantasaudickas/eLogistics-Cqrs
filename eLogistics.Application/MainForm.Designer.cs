namespace eLogistics.Application
{
    partial class MainForm
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
            Infragistics.Win.UltraWinListBar.Group group1 = new Infragistics.Win.UltraWinListBar.Group(true);
            Infragistics.Win.UltraWinListBar.Item item1 = new Infragistics.Win.UltraWinListBar.Item();
            Infragistics.Win.UltraWinListBar.Item item2 = new Infragistics.Win.UltraWinListBar.Item();
            Infragistics.Win.UltraWinListBar.Item item3 = new Infragistics.Win.UltraWinListBar.Item();
            Infragistics.Win.UltraWinListBar.Group group2 = new Infragistics.Win.UltraWinListBar.Group();
            Infragistics.Win.UltraWinListBar.Item item4 = new Infragistics.Win.UltraWinListBar.Item();
            Infragistics.Win.UltraWinListBar.Item item5 = new Infragistics.Win.UltraWinListBar.Item();
            Infragistics.Win.UltraWinListBar.Group group3 = new Infragistics.Win.UltraWinListBar.Group();
            Infragistics.Win.UltraWinListBar.Item item6 = new Infragistics.Win.UltraWinListBar.Item();
            Infragistics.Win.UltraWinListBar.Item item7 = new Infragistics.Win.UltraWinListBar.Item();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraListBar = new Infragistics.Win.UltraWinListBar.UltraListBar();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraListBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1064, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "Failai";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.closeToolStripMenuItem.Text = "Uždaryti programą";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // ultraListBar
            // 
            this.ultraListBar.Dock = System.Windows.Forms.DockStyle.Left;
            item1.Key = "PaymentTypes";
            item1.Text = "Mokėjimų tipai";
            item2.Key = "Suppliers";
            item2.Text = "Tiekėjai";
            item3.Key = "Customers";
            item3.Text = "Klientai";
            group1.Items.Add(item1);
            group1.Items.Add(item2);
            group1.Items.Add(item3);
            group1.Text = "Programos";
            item4.Key = "ArticleGroups";
            item4.Text = "Prekių grupės";
            item5.Key = "Articles";
            item5.Text = "Prekės";
            group2.Items.Add(item4);
            group2.Items.Add(item5);
            group2.Text = "Sandėlys";
            item6.Key = "SupplierInvoices";
            item6.Text = "Tiekėjų sąskaitos";
            item7.Key = "Orders";
            item7.Text = "Užsakymai";
            group3.Items.Add(item6);
            group3.Items.Add(item7);
            group3.Text = "Sąskaitos";
            this.ultraListBar.Groups.Add(group1);
            this.ultraListBar.Groups.Add(group2);
            this.ultraListBar.Groups.Add(group3);
            this.ultraListBar.Location = new System.Drawing.Point(0, 24);
            this.ultraListBar.Name = "ultraListBar";
            this.ultraListBar.Size = new System.Drawing.Size(212, 541);
            this.ultraListBar.ItemSelected += new Infragistics.Win.UltraWinListBar.ItemEventHandler(this.ultraListBar_ItemSelected);
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.Location = new System.Drawing.Point(212, 24);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 0;
            this.ultraSplitter1.Size = new System.Drawing.Size(6, 541);
            this.ultraSplitter1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 565);
            this.Controls.Add(this.ultraSplitter1);
            this.Controls.Add(this.ultraListBar);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraListBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Infragistics.Win.UltraWinListBar.UltraListBar ultraListBar;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
    }
}

