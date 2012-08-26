namespace SimpleCQRSCodeGenerator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textContent = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.buttonToggleWatching = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textContent
            // 
            this.textContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textContent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textContent.Location = new System.Drawing.Point(0, 52);
            this.textContent.Name = "textContent";
            this.textContent.ReadOnly = true;
            this.textContent.Size = new System.Drawing.Size(932, 512);
            this.textContent.TabIndex = 0;
            this.textContent.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textFolder);
            this.panel1.Controls.Add(this.buttonToggleWatching);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 52);
            this.panel1.TabIndex = 1;
            // 
            // textFolder
            // 
            this.textFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFolder.Location = new System.Drawing.Point(183, 14);
            this.textFolder.Name = "textFolder";
            this.textFolder.Size = new System.Drawing.Size(746, 20);
            this.textFolder.TabIndex = 1;
            // 
            // buttonToggleWatching
            // 
            this.buttonToggleWatching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleWatching.Location = new System.Drawing.Point(12, 12);
            this.buttonToggleWatching.Name = "buttonToggleWatching";
            this.buttonToggleWatching.Size = new System.Drawing.Size(165, 23);
            this.buttonToggleWatching.TabIndex = 0;
            this.buttonToggleWatching.Text = "Toggle watching";
            this.buttonToggleWatching.UseVisualStyleBackColor = true;
            this.buttonToggleWatching.Click += new System.EventHandler(this.buttonToggleWatching_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Code generator";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 564);
            this.Controls.Add(this.textContent);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CQRS Code Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToggleWatching;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}