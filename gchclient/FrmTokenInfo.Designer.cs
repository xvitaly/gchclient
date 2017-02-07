namespace gchclient
{
    partial class FrmTokenInfo
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
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.Tn_ExpDate = new System.Windows.Forms.Label();
            this.Tn_IP = new System.Windows.Forms.Label();
            this.Tn_Login = new System.Windows.Forms.Label();
            this.L_Tn_ExpDate = new System.Windows.Forms.Label();
            this.L_Tn_IP = new System.Windows.Forms.Label();
            this.L_Tn_Login = new System.Windows.Forms.Label();
            this.GB2 = new System.Windows.Forms.GroupBox();
            this.Tn_CliVer = new System.Windows.Forms.Label();
            this.Tn_APIVer = new System.Windows.Forms.Label();
            this.L_Tn_CliVer = new System.Windows.Forms.Label();
            this.L_Tn_APIVer = new System.Windows.Forms.Label();
            this.BW_Rcv = new System.ComponentModel.BackgroundWorker();
            this.GB1.SuspendLayout();
            this.GB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.Tn_ExpDate);
            this.GB1.Controls.Add(this.Tn_IP);
            this.GB1.Controls.Add(this.Tn_Login);
            this.GB1.Controls.Add(this.L_Tn_ExpDate);
            this.GB1.Controls.Add(this.L_Tn_IP);
            this.GB1.Controls.Add(this.L_Tn_Login);
            this.GB1.Location = new System.Drawing.Point(12, 12);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(307, 95);
            this.GB1.TabIndex = 0;
            this.GB1.TabStop = false;
            this.GB1.Text = "Пользовательская информация";
            // 
            // Tn_ExpDate
            // 
            this.Tn_ExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tn_ExpDate.Location = new System.Drawing.Point(163, 65);
            this.Tn_ExpDate.Name = "Tn_ExpDate";
            this.Tn_ExpDate.Size = new System.Drawing.Size(124, 18);
            this.Tn_ExpDate.TabIndex = 5;
            // 
            // Tn_IP
            // 
            this.Tn_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tn_IP.Location = new System.Drawing.Point(163, 43);
            this.Tn_IP.Name = "Tn_IP";
            this.Tn_IP.Size = new System.Drawing.Size(124, 18);
            this.Tn_IP.TabIndex = 3;
            // 
            // Tn_Login
            // 
            this.Tn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tn_Login.Location = new System.Drawing.Point(163, 21);
            this.Tn_Login.Name = "Tn_Login";
            this.Tn_Login.Size = new System.Drawing.Size(124, 18);
            this.Tn_Login.TabIndex = 1;
            // 
            // L_Tn_ExpDate
            // 
            this.L_Tn_ExpDate.Location = new System.Drawing.Point(13, 65);
            this.L_Tn_ExpDate.Name = "L_Tn_ExpDate";
            this.L_Tn_ExpDate.Size = new System.Drawing.Size(144, 18);
            this.L_Tn_ExpDate.TabIndex = 4;
            this.L_Tn_ExpDate.Text = "Срок действия истекает:";
            // 
            // L_Tn_IP
            // 
            this.L_Tn_IP.Location = new System.Drawing.Point(13, 43);
            this.L_Tn_IP.Name = "L_Tn_IP";
            this.L_Tn_IP.Size = new System.Drawing.Size(144, 18);
            this.L_Tn_IP.TabIndex = 2;
            this.L_Tn_IP.Text = "Разрешённые IP-адреса:";
            // 
            // L_Tn_Login
            // 
            this.L_Tn_Login.Location = new System.Drawing.Point(13, 21);
            this.L_Tn_Login.Name = "L_Tn_Login";
            this.L_Tn_Login.Size = new System.Drawing.Size(144, 18);
            this.L_Tn_Login.TabIndex = 0;
            this.L_Tn_Login.Text = "Форумный логин:";
            // 
            // GB2
            // 
            this.GB2.Controls.Add(this.Tn_CliVer);
            this.GB2.Controls.Add(this.Tn_APIVer);
            this.GB2.Controls.Add(this.L_Tn_CliVer);
            this.GB2.Controls.Add(this.L_Tn_APIVer);
            this.GB2.Location = new System.Drawing.Point(12, 113);
            this.GB2.Name = "GB2";
            this.GB2.Size = new System.Drawing.Size(307, 72);
            this.GB2.TabIndex = 1;
            this.GB2.TabStop = false;
            this.GB2.Text = "Служебная информация";
            // 
            // Tn_CliVer
            // 
            this.Tn_CliVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tn_CliVer.Location = new System.Drawing.Point(163, 44);
            this.Tn_CliVer.Name = "Tn_CliVer";
            this.Tn_CliVer.Size = new System.Drawing.Size(124, 18);
            this.Tn_CliVer.TabIndex = 3;
            // 
            // Tn_APIVer
            // 
            this.Tn_APIVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tn_APIVer.Location = new System.Drawing.Point(163, 22);
            this.Tn_APIVer.Name = "Tn_APIVer";
            this.Tn_APIVer.Size = new System.Drawing.Size(124, 18);
            this.Tn_APIVer.TabIndex = 1;
            // 
            // L_Tn_CliVer
            // 
            this.L_Tn_CliVer.Location = new System.Drawing.Point(13, 44);
            this.L_Tn_CliVer.Name = "L_Tn_CliVer";
            this.L_Tn_CliVer.Size = new System.Drawing.Size(144, 18);
            this.L_Tn_CliVer.TabIndex = 2;
            this.L_Tn_CliVer.Text = "Миним. версия клиента:";
            // 
            // L_Tn_APIVer
            // 
            this.L_Tn_APIVer.Location = new System.Drawing.Point(13, 22);
            this.L_Tn_APIVer.Name = "L_Tn_APIVer";
            this.L_Tn_APIVer.Size = new System.Drawing.Size(144, 18);
            this.L_Tn_APIVer.TabIndex = 0;
            this.L_Tn_APIVer.Text = "Версия API чекера:";
            // 
            // BW_Rcv
            // 
            this.BW_Rcv.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Rcv_DoWork);
            this.BW_Rcv.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Rcv_RunWorkerCompleted);
            // 
            // FrmTokenInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 201);
            this.Controls.Add(this.GB1);
            this.Controls.Add(this.GB2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTokenInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о токенах доступа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTokenInfo_FormClosing);
            this.Load += new System.EventHandler(this.FrmTokenInfo_Load);
            this.GB1.ResumeLayout(false);
            this.GB2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.Label L_Tn_ExpDate;
        private System.Windows.Forms.Label L_Tn_IP;
        private System.Windows.Forms.Label L_Tn_Login;
        private System.Windows.Forms.GroupBox GB2;
        private System.Windows.Forms.Label L_Tn_CliVer;
        private System.Windows.Forms.Label L_Tn_APIVer;
        private System.Windows.Forms.Label Tn_IP;
        private System.Windows.Forms.Label Tn_Login;
        private System.Windows.Forms.Label Tn_ExpDate;
        private System.Windows.Forms.Label Tn_CliVer;
        private System.Windows.Forms.Label Tn_APIVer;
        private System.ComponentModel.BackgroundWorker BW_Rcv;

    }
}