/*
 * This file is a part of Garant Checker Offline. For more information
 * visit official site: https://www.easycoding.org/projects/gchclient
 * 
 * Copyright (c) 2012 - 2017 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2017 EasyCoding Team.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
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
