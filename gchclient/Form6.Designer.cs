namespace gchclient
{
    partial class frmReportU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportU));
            this.WLabel = new System.Windows.Forms.Label();
            this.L_SteamID = new System.Windows.Forms.Label();
            this.W_SteamID = new System.Windows.Forms.TextBox();
            this.L_List = new System.Windows.Forms.Label();
            this.W_List = new System.Windows.Forms.ComboBox();
            this.L_ReportText = new System.Windows.Forms.Label();
            this.W_ReportText = new System.Windows.Forms.TextBox();
            this.W_Submit = new System.Windows.Forms.Button();
            this.W_Cancel = new System.Windows.Forms.Button();
            this.BW_Main = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // WLabel
            // 
            this.WLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WLabel.Location = new System.Drawing.Point(12, 9);
            this.WLabel.Name = "WLabel";
            this.WLabel.Size = new System.Drawing.Size(445, 47);
            this.WLabel.TabIndex = 0;
            this.WLabel.Text = "Сообщить о мошеннике";
            this.WLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_SteamID
            // 
            this.L_SteamID.AutoSize = true;
            this.L_SteamID.Location = new System.Drawing.Point(34, 68);
            this.L_SteamID.Name = "L_SteamID";
            this.L_SteamID.Size = new System.Drawing.Size(51, 13);
            this.L_SteamID.TabIndex = 1;
            this.L_SteamID.Text = "SteamID:";
            // 
            // W_SteamID
            // 
            this.W_SteamID.Location = new System.Drawing.Point(91, 65);
            this.W_SteamID.Name = "W_SteamID";
            this.W_SteamID.ReadOnly = true;
            this.W_SteamID.Size = new System.Drawing.Size(134, 20);
            this.W_SteamID.TabIndex = 2;
            // 
            // L_List
            // 
            this.L_List.AutoSize = true;
            this.L_List.Location = new System.Drawing.Point(244, 68);
            this.L_List.Name = "L_List";
            this.L_List.Size = new System.Drawing.Size(47, 13);
            this.L_List.TabIndex = 3;
            this.L_List.Text = "Список:";
            // 
            // W_List
            // 
            this.W_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.W_List.FormattingEnabled = true;
            this.W_List.Items.AddRange(new object[] {
            "Чёрный список",
            "ЧС аукциона",
            "Ненадёжные"});
            this.W_List.Location = new System.Drawing.Point(297, 65);
            this.W_List.Name = "W_List";
            this.W_List.Size = new System.Drawing.Size(134, 21);
            this.W_List.TabIndex = 4;
            // 
            // L_ReportText
            // 
            this.L_ReportText.AutoSize = true;
            this.L_ReportText.Location = new System.Drawing.Point(34, 98);
            this.L_ReportText.Name = "L_ReportText";
            this.L_ReportText.Size = new System.Drawing.Size(328, 13);
            this.L_ReportText.TabIndex = 5;
            this.L_ReportText.Text = "Введите текст заявления с необходимыми доказательствами:";
            // 
            // W_ReportText
            // 
            this.W_ReportText.Location = new System.Drawing.Point(37, 118);
            this.W_ReportText.Multiline = true;
            this.W_ReportText.Name = "W_ReportText";
            this.W_ReportText.Size = new System.Drawing.Size(394, 138);
            this.W_ReportText.TabIndex = 6;
            // 
            // W_Submit
            // 
            this.W_Submit.Location = new System.Drawing.Point(81, 269);
            this.W_Submit.Name = "W_Submit";
            this.W_Submit.Size = new System.Drawing.Size(136, 23);
            this.W_Submit.TabIndex = 7;
            this.W_Submit.Text = "Отправить жалобу";
            this.W_Submit.UseVisualStyleBackColor = true;
            this.W_Submit.Click += new System.EventHandler(this.W_Submit_Click);
            // 
            // W_Cancel
            // 
            this.W_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.W_Cancel.Location = new System.Drawing.Point(247, 269);
            this.W_Cancel.Name = "W_Cancel";
            this.W_Cancel.Size = new System.Drawing.Size(136, 23);
            this.W_Cancel.TabIndex = 8;
            this.W_Cancel.Text = "Отменить";
            this.W_Cancel.UseVisualStyleBackColor = true;
            this.W_Cancel.Click += new System.EventHandler(this.W_Cancel_Click);
            // 
            // BW_Main
            // 
            this.BW_Main.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Main_DoWork);
            this.BW_Main.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Main_RunWorkerCompleted);
            // 
            // frmReportU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.W_Cancel;
            this.ClientSize = new System.Drawing.Size(466, 308);
            this.Controls.Add(this.W_Cancel);
            this.Controls.Add(this.W_Submit);
            this.Controls.Add(this.W_ReportText);
            this.Controls.Add(this.L_ReportText);
            this.Controls.Add(this.W_List);
            this.Controls.Add(this.L_List);
            this.Controls.Add(this.W_SteamID);
            this.Controls.Add(this.L_SteamID);
            this.Controls.Add(this.WLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportU";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма сообщения о мошенничестве";
            this.Load += new System.EventHandler(this.frmReportU_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WLabel;
        private System.Windows.Forms.Label L_SteamID;
        private System.Windows.Forms.TextBox W_SteamID;
        private System.Windows.Forms.Label L_List;
        private System.Windows.Forms.ComboBox W_List;
        private System.Windows.Forms.Label L_ReportText;
        private System.Windows.Forms.TextBox W_ReportText;
        private System.Windows.Forms.Button W_Submit;
        private System.Windows.Forms.Button W_Cancel;
        private System.ComponentModel.BackgroundWorker BW_Main;
    }
}