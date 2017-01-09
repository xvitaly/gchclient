/*
 * Форма информации о токенах приложения Garant Checker Offline.
 * 
 * Copyright 2012 - 2017 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2017 EasyCoding Team.
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
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс формы информации о токенах приложения Garant Checker Offline.
    /// </summary>
    public partial class frmTokenInfo : Form
    {
        /// <summary>
        /// Хранит информацию об успешности последней операции.
        /// </summary>
        private bool LastError { get; set; } = true;

        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        public frmTokenInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод события "загрузка формы".
        /// </summary>
        private void frmTokenInfo_Load(object sender, EventArgs e)
        {
            if (!BW_Rcv.IsBusy) { BW_Rcv.RunWorkerAsync(); }
        }

        /// <summary>
        /// Метод обработчика, выполняющегося в отдельном потоке асинхронно.
        /// </summary>
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

                using (FileStream XMLFS = new FileStream(XMLFileName, FileMode.Open, FileAccess.Read))
                {
                    XmlDocument XMLD = new XmlDocument();
                    XMLD.Load(XMLFS);
                    Invoke((MethodInvoker)delegate()
                    {
                        Tn_ExpDate.Text = CoreLib.UnixTime2DateTime(Convert.ToDouble(XMLD.GetElementsByTagName("expires")[0].InnerText)).ToString();
                        Tn_Login.Text = XMLD.GetElementsByTagName("nickname")[0].InnerText;
                        Tn_IP.Text = XMLD.GetElementsByTagName("ip")[0].InnerText;
                        Tn_APIVer.Text = XMLD.GetElementsByTagName("apiversion")[0].InnerText;
                        Tn_CliVer.Text = XMLD.GetElementsByTagName("mcliversion")[0].InnerText;
                    });
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

        /// <summary>
        /// Метод асинхронного обработчика, выполняющийся по окончании работы.
        /// </summary>
        private void BW_Rcv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (LastError) { Close(); }
        }

        /// <summary>
        /// Метод события "попытка закрытия формы".
        /// </summary>
        private void frmTokenInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_Rcv.IsBusy;
        }
    }
}
