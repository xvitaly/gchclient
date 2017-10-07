namespace gchclient
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.OkButton = new System.Windows.Forms.Button();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.LabelLicense = new System.Windows.Forms.Label();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.LabelCompanyName = new System.Windows.Forms.Label();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.LabelProductName = new System.Windows.Forms.Label();
            this.IconApp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OkButton.Location = new System.Drawing.Point(89, 297);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(101, 23);
            this.OkButton.TabIndex = 16;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelCopyright.Location = new System.Drawing.Point(12, 152);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(241, 34);
            this.LabelCopyright.TabIndex = 14;
            this.LabelCopyright.Text = "%COPYRIGHT%";
            // 
            // LabelLicense
            // 
            this.LabelLicense.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelLicense.Location = new System.Drawing.Point(131, 72);
            this.LabelLicense.Name = "LabelLicense";
            this.LabelLicense.Size = new System.Drawing.Size(122, 69);
            this.LabelLicense.TabIndex = 12;
            this.LabelLicense.Text = "Общая лицензия приложения: GNU General Public License версии 3 (или более поздняя" +
    ").";
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(13, 189);
            this.TextBoxDescription.Multiline = true;
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.ReadOnly = true;
            this.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxDescription.Size = new System.Drawing.Size(241, 91);
            this.TextBoxDescription.TabIndex = 15;
            this.TextBoxDescription.TabStop = false;
            this.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text");
            // 
            // LabelCompanyName
            // 
            this.LabelCompanyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelCompanyName.Location = new System.Drawing.Point(131, 52);
            this.LabelCompanyName.Name = "LabelCompanyName";
            this.LabelCompanyName.Size = new System.Drawing.Size(122, 14);
            this.LabelCompanyName.TabIndex = 11;
            this.LabelCompanyName.Text = "%COMPANY_NAME%";
            // 
            // LabelVersion
            // 
            this.LabelVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelVersion.Location = new System.Drawing.Point(131, 36);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(122, 16);
            this.LabelVersion.TabIndex = 10;
            this.LabelVersion.Text = "%APPVERSION%";
            // 
            // LabelProductName
            // 
            this.LabelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LabelProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelProductName.Location = new System.Drawing.Point(8, 9);
            this.LabelProductName.Name = "LabelProductName";
            this.LabelProductName.Size = new System.Drawing.Size(246, 24);
            this.LabelProductName.TabIndex = 8;
            this.LabelProductName.Text = "%PRODUCT_NAME%";
            this.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconApp
            // 
            this.IconApp.Image = global::gchclient.Properties.Resources.task;
            this.IconApp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IconApp.Location = new System.Drawing.Point(12, 36);
            this.IconApp.Name = "IconApp";
            this.IconApp.Size = new System.Drawing.Size(113, 105);
            this.IconApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconApp.TabIndex = 9;
            this.IconApp.TabStop = false;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OkButton;
            this.ClientSize = new System.Drawing.Size(266, 336);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.LabelLicense);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.LabelCompanyName);
            this.Controls.Add(this.LabelVersion);
            this.Controls.Add(this.LabelProductName);
            this.Controls.Add(this.IconApp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label LabelCopyright;
        private System.Windows.Forms.Label LabelLicense;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Label LabelCompanyName;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.Label LabelProductName;
        private System.Windows.Forms.PictureBox IconApp;
    }
}