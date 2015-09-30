namespace gchclient
{
    partial class frmFrChk
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFrChk));
            this.DVList = new System.Windows.Forms.DataGridView();
            this.DV_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DV_LastNick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DV_List = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SV_FrSince = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DV_Link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.BW_Rcv = new System.ComponentModel.BackgroundWorker();
            this.SB_Main = new System.Windows.Forms.StatusStrip();
            this.SB_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.SV_SaveDlg = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DVList)).BeginInit();
            this.SB_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // DVList
            // 
            this.DVList.AllowUserToAddRows = false;
            this.DVList.AllowUserToDeleteRows = false;
            this.DVList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DVList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DVList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DVList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DVList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DVList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DV_Number,
            this.DV_LastNick,
            this.DV_List,
            this.SV_FrSince,
            this.DV_Link});
            this.DVList.Location = new System.Drawing.Point(-1, -1);
            this.DVList.MultiSelect = false;
            this.DVList.Name = "DVList";
            this.DVList.ReadOnly = true;
            this.DVList.RowHeadersVisible = false;
            this.DVList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DVList.Size = new System.Drawing.Size(636, 382);
            this.DVList.TabIndex = 0;
            this.DVList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DVList_CellMouseClick);
            this.DVList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DVList_KeyDown);
            // 
            // DV_Number
            // 
            this.DV_Number.HeaderText = "№";
            this.DV_Number.Name = "DV_Number";
            this.DV_Number.ReadOnly = true;
            this.DV_Number.Width = 30;
            // 
            // DV_LastNick
            // 
            this.DV_LastNick.HeaderText = "Последний ник";
            this.DV_LastNick.Name = "DV_LastNick";
            this.DV_LastNick.ReadOnly = true;
            this.DV_LastNick.Width = 125;
            // 
            // DV_List
            // 
            this.DV_List.HeaderText = "Список";
            this.DV_List.Name = "DV_List";
            this.DV_List.ReadOnly = true;
            this.DV_List.Width = 55;
            // 
            // SV_FrSince
            // 
            this.SV_FrSince.HeaderText = "В друзьях с";
            this.SV_FrSince.Name = "SV_FrSince";
            this.SV_FrSince.ReadOnly = true;
            // 
            // DV_Link
            // 
            this.DV_Link.HeaderText = "Ссылка";
            this.DV_Link.Name = "DV_Link";
            this.DV_Link.ReadOnly = true;
            this.DV_Link.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DV_Link.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DV_Link.Width = 305;
            // 
            // BW_Rcv
            // 
            this.BW_Rcv.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Rcv_DoWork);
            this.BW_Rcv.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Rcv_RunWorkerCompleted);
            // 
            // SB_Main
            // 
            this.SB_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SB_Status});
            this.SB_Main.Location = new System.Drawing.Point(0, 381);
            this.SB_Main.Name = "SB_Main";
            this.SB_Main.Size = new System.Drawing.Size(635, 22);
            this.SB_Main.TabIndex = 1;
            this.SB_Main.Text = "statusStrip1";
            // 
            // SB_Status
            // 
            this.SB_Status.AutoSize = false;
            this.SB_Status.Name = "SB_Status";
            this.SB_Status.Size = new System.Drawing.Size(199, 17);
            this.SB_Status.Text = "Готов.";
            this.SB_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SV_SaveDlg
            // 
            this.SV_SaveDlg.DefaultExt = "txt";
            this.SV_SaveDlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            this.SV_SaveDlg.Title = "Сохранение списка друзей";
            // 
            // frmFrChk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 403);
            this.Controls.Add(this.SB_Main);
            this.Controls.Add(this.DVList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFrChk";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр друзей пользователя {0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFrChk_FormClosing);
            this.Load += new System.EventHandler(this.frmFrChk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DVList)).EndInit();
            this.SB_Main.ResumeLayout(false);
            this.SB_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DVList;
        private System.ComponentModel.BackgroundWorker BW_Rcv;
        private System.Windows.Forms.StatusStrip SB_Main;
        private System.Windows.Forms.ToolStripStatusLabel SB_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DV_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn DV_LastNick;
        private System.Windows.Forms.DataGridViewTextBoxColumn DV_List;
        private System.Windows.Forms.DataGridViewTextBoxColumn SV_FrSince;
        private System.Windows.Forms.DataGridViewLinkColumn DV_Link;
        private System.Windows.Forms.SaveFileDialog SV_SaveDlg;
    }
}