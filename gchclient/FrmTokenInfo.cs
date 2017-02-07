﻿/*
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
using System.Windows.Forms;
using System.Xml;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс формы информации о токенах приложения Garant Checker Offline.
    /// </summary>
    public partial class FrmTokenInfo : Form
    {
        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        public FrmTokenInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод события "загрузка формы".
        /// </summary>
        private void FrmTokenInfo_Load(object sender, EventArgs e)
        {
            if (!BW_Rcv.IsBusy) { BW_Rcv.RunWorkerAsync(); }
        }

        /// <summary>
        /// Метод обработчика, выполняющегося в отдельном потоке асинхронно.
        /// </summary>
        private void BW_Rcv_DoWork(object sender, DoWorkEventArgs e)
        {
            XmlDocument XMLD = new XmlDocument();
            XMLD.LoadXml(CoreLib.DownloadRemoteString(String.Format(Properties.Resources.APIURI, (Properties.Settings.Default.UseSSL ? "https://" : "http://"), "info", CoreLib.md5hash(Properties.Settings.Default.PrimKey + Properties.Settings.Default.SecKey), String.Empty), Properties.Resources.AppUserAgent, Auth.HardwareID));
            Invoke((MethodInvoker)delegate()
            {
                Tn_ExpDate.Text = CoreLib.UnixTime2DateTime(Convert.ToDouble(XMLD.GetElementsByTagName("expires")[0].InnerText)).ToString();
                Tn_Login.Text = XMLD.GetElementsByTagName("nickname")[0].InnerText;
                Tn_IP.Text = XMLD.GetElementsByTagName("ip")[0].InnerText;
                Tn_APIVer.Text = XMLD.GetElementsByTagName("apiversion")[0].InnerText;
                Tn_CliVer.Text = XMLD.GetElementsByTagName("mcliversion")[0].InnerText;
            });
        }

        /// <summary>
        /// Метод асинхронного обработчика, выполняющийся по окончании работы.
        /// </summary>
        private void BW_Rcv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(Properties.Resources.AppErrTokenInfo, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        /// <summary>
        /// Метод события "попытка закрытия формы".
        /// </summary>
        private void FrmTokenInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_Rcv.IsBusy;
        }
    }
}
