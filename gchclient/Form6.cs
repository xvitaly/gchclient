using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;

namespace gchclient
{
    public partial class frmReportU : Form
    {
        private string SteamID;
        private string UserText;
        private string ListID;
        public frmReportU(string Sid32)
        {
            InitializeComponent();
            SteamID = Sid32;
        }

        private void frmReportU_Load(object sender, EventArgs e)
        {
            W_SteamID.Text = SteamID;
            W_List.SelectedIndex = 0;
        }

        private void W_Submit_Click(object sender, EventArgs e)
        {
            UserText = W_ReportText.Text.Trim();
            if (!String.IsNullOrWhiteSpace(UserText))
            {
                switch (W_List.SelectedIndex)
                {
                    case 0: ListID = "3";
                        break;
                    case 1: ListID = "5";
                        break;
                    case 2: ListID = "8";
                        break;
                    default: ListID = "3";
                        break;
                }
                if (!BW_Main.IsBusy) { BW_Main.RunWorkerAsync(); }
            }
            else
            {
                MessageBox.Show(Properties.Resources.RepEmptyField, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void W_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_Main_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Формируем Web-запрос...
                HttpWebRequest WrQ = (HttpWebRequest)WebRequest.Create(String.Format(Properties.Resources.APIRepURL, Properties.Settings.Default.UseSSL ? "https://" : "http://"));
                // Задаём User-Agent, метод запроса и таймаут ожидания ответа...
                WrQ.UserAgent = Properties.Resources.AppUserAgent;
                WrQ.Method = "POST";
                WrQ.Timeout = 250000;
                // Кодируем POST-запрос в UTF8...
                byte[] ByteReqC = Encoding.UTF8.GetBytes(String.Format("hrfff=1&steam={0}&dblist={1}&advtext={2}", SteamID, ListID, String.Format("{0}.\r\n\r\n{1}: {2}", UserText, Properties.Resources.RepPostFix, CoreLib.md5hash(Properties.Settings.Default.PrimKey + Properties.Settings.Default.SecKey))));
                // Указываем тип отправляемых данных [форма] и длину запроса...
                WrQ.ContentType = "application/x-www-form-urlencoded";
                WrQ.ContentLength = ByteReqC.Length;
                // Открываем поток...
                using (Stream HTTPStreamRq = WrQ.GetRequestStream())
                {
                    HTTPStreamRq.Write(ByteReqC, 0, ByteReqC.Length);
                    HTTPStreamRq.Close();
                }
                // Получаем ответ от сервера...
                HttpWebResponse HTTPWResp = (HttpWebResponse)WrQ.GetResponse();
                if (HTTPWResp.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show(Properties.Resources.RepSubmitted, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.RepError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BW_Main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
