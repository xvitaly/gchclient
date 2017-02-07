namespace gchclient
{
    partial class FrmEvView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvView));
            this.SB_Main = new System.Windows.Forms.StatusStrip();
            this.SB_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImgBoxMain = new System.Windows.Forms.PictureBox();
            this.BW_ImgLoader = new System.ComponentModel.BackgroundWorker();
            this.SB_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // SB_Main
            // 
            this.SB_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SB_Status});
            this.SB_Main.Location = new System.Drawing.Point(0, 504);
            this.SB_Main.Name = "SB_Main";
            this.SB_Main.Size = new System.Drawing.Size(590, 22);
            this.SB_Main.TabIndex = 0;
            // 
            // SB_Status
            // 
            this.SB_Status.AutoSize = false;
            this.SB_Status.Name = "SB_Status";
            this.SB_Status.Size = new System.Drawing.Size(199, 17);
            this.SB_Status.Text = "Готов.";
            this.SB_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImgBoxMain
            // 
            this.ImgBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgBoxMain.Location = new System.Drawing.Point(0, 0);
            this.ImgBoxMain.Name = "ImgBoxMain";
            this.ImgBoxMain.Size = new System.Drawing.Size(590, 504);
            this.ImgBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgBoxMain.TabIndex = 1;
            this.ImgBoxMain.TabStop = false;
            // 
            // BW_ImgLoader
            // 
            this.BW_ImgLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_ImgLoader_DoWork);
            this.BW_ImgLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_ImgLoader_RunWorkerCompleted);
            // 
            // FrmEvView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 526);
            this.Controls.Add(this.ImgBoxMain);
            this.Controls.Add(this.SB_Main);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEvView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Средство просмотра доказательств - {0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEvView_FormClosing);
            this.Load += new System.EventHandler(this.FrmEvView_Load);
            this.SB_Main.ResumeLayout(false);
            this.SB_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SB_Main;
        private System.Windows.Forms.ToolStripStatusLabel SB_Status;
        private System.Windows.Forms.PictureBox ImgBoxMain;
        private System.ComponentModel.BackgroundWorker BW_ImgLoader;
    }
}