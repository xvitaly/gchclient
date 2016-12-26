/*
 * Форма информации о токенах приложения Garant Checker Offline.
 * 
 * Copyright 2012 - 2013 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2013 EasyCoding Team.
 * 
 * Лицензия кода: модифицированная лицензия BSD.
 * Лицензия контента: Creative Commons 3.0 BY.
 * 
 * Полный текст лицензии находится в файле LICENSE.TXT.
 * 
 * Официальный блог EasyCoding Team: http://www.easycoding.org/
 * Официальная страница проекта: http://www.easycoding.org/projects/gchclient
*/
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace gchclient
{
    public partial class frmTokenInfo : Form
    {
        private bool LastError = true;
        public frmTokenInfo()
        {
            InitializeComponent();
        }

        private void frmTokenInfo_Load(object sender, EventArgs e)
        {
            if (!BW_Rcv.IsBusy) { BW_Rcv.RunWorkerAsync(); }
        }

        private void BW_Rcv_DoWork(object sender, DoWorkEventArgs e)
        {
            string XMLFileName = Path.GetTempFileName();
            try
            {
                using (WebClient Downloader = new WebClient())
                {
                    Downloader.Headers.Add("User-Agent", Properties.Resources.AppUserAgent);
                    Downloader.Headers.Add("HardwareID", Auth.HardwareID);
                    Downloader.DownloadFile(String.Format(Properties.Resources.APIURI, (Properties.Settings.Default.UseSSL ? "https://" : "http://"), "info", CoreLib.md5hash(Properties.Settings.Default.PrimKey + Properties.Settings.Default.SecKey), ""), XMLFileName);
                }
                XmlDocument XMLD = new XmlDocument();
                using (FileStream XMLFS = new FileStream(XMLFileName, FileMode.Open, FileAccess.Read))
                {
                    XMLD.Load(XMLFS);
                    XmlNodeList XMLNList = XMLD.GetElementsByTagName("info");
                    this.Invoke((MethodInvoker)delegate()
                    {
                        Tn_ExpDate.Text = CoreLib.UnixTime2DateTime(Convert.ToDouble(XMLD.GetElementsByTagName("expires")[0].InnerText)).ToString();
                        Tn_Login.Text = XMLD.GetElementsByTagName("nickname")[0].InnerText;
                        Tn_IP.Text = XMLD.GetElementsByTagName("ip")[0].InnerText;
                        Tn_APIVer.Text = XMLD.GetElementsByTagName("apiversion")[0].InnerText;
                        Tn_CliVer.Text = XMLD.GetElementsByTagName("mcliversion")[0].InnerText;
                    });
                    XMLFS.Close();
                }
                File.Delete(XMLFileName);
                LastError = false;
            }
            catch
            {
                if (File.Exists(XMLFileName)) { File.Delete(XMLFileName); }
                MessageBox.Show(Properties.Resources.AppErrTokenInfo, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BW_Rcv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (LastError) { this.Close(); }
        }

        private void frmTokenInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_Rcv.IsBusy;
        }
    }
}
