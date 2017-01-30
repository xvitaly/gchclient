namespace gchclient
{
    partial class FrmDnWrk
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
            this.DN_PrgBr = new System.Windows.Forms.ProgressBar();
            this.DN_WlcMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DN_PrgBr
            // 
            this.DN_PrgBr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DN_PrgBr.Location = new System.Drawing.Point(12, 35);
            this.DN_PrgBr.Name = "DN_PrgBr";
            this.DN_PrgBr.Size = new System.Drawing.Size(354, 29);
            this.DN_PrgBr.TabIndex = 3;
            // 
            // DN_WlcMsg
            // 
            this.DN_WlcMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DN_WlcMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DN_WlcMsg.Location = new System.Drawing.Point(12, 9);
            this.DN_WlcMsg.Name = "DN_WlcMsg";
            this.DN_WlcMsg.Size = new System.Drawing.Size(354, 19);
            this.DN_WlcMsg.TabIndex = 2;
            this.DN_WlcMsg.Text = "Downloading file... Please wait.";
            this.DN_WlcMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDnWrk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 78);
            this.ControlBox = false;
            this.Controls.Add(this.DN_PrgBr);
            this.Controls.Add(this.DN_WlcMsg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDnWrk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Модуль загрузок";
            this.Load += new System.EventHandler(this.FrmDnWrk_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar DN_PrgBr;
        private System.Windows.Forms.Label DN_WlcMsg;
    }
}