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
            this.labelContent = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelLicense = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.iconApp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconApp)).BeginInit();
            this.SuspendLayout();
            // 
            // labelContent
            // 
            this.labelContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelContent.Location = new System.Drawing.Point(131, 108);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(122, 33);
            this.labelContent.TabIndex = 13;
            this.labelContent.Text = "Лицензия контента: Creative Commons BY.";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okButton.Location = new System.Drawing.Point(89, 297);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCopyright.Location = new System.Drawing.Point(12, 152);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(241, 34);
            this.labelCopyright.TabIndex = 14;
            this.labelCopyright.Text = "%COPYRIGHT%";
            // 
            // labelLicense
            // 
            this.labelLicense.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelLicense.Location = new System.Drawing.Point(131, 72);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(122, 31);
            this.labelLicense.TabIndex = 12;
            this.labelLicense.Text = "Общая лицензия приложения: BSD.";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(13, 189);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(241, 91);
            this.textBoxDescription.TabIndex = 15;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCompanyName.Location = new System.Drawing.Point(131, 52);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(122, 14);
            this.labelCompanyName.TabIndex = 11;
            this.labelCompanyName.Text = "%COMPANY_NAME%";
            // 
            // labelVersion
            // 
            this.labelVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVersion.Location = new System.Drawing.Point(131, 36);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(122, 16);
            this.labelVersion.TabIndex = 10;
            this.labelVersion.Text = "%APPVERSION%";
            // 
            // labelProductName
            // 
            this.labelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelProductName.Location = new System.Drawing.Point(8, 9);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(246, 24);
            this.labelProductName.TabIndex = 8;
            this.labelProductName.Text = "%PRODUCT_NAME%";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconApp
            // 
            this.iconApp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.iconApp.Location = new System.Drawing.Point(12, 36);
            this.iconApp.Name = "iconApp";
            this.iconApp.Size = new System.Drawing.Size(113, 105);
            this.iconApp.TabIndex = 9;
            this.iconApp.TabStop = false;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(266, 336);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.iconApp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.PictureBox iconApp;
    }
}