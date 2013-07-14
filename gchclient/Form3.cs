﻿/*
 * Форма чекера друзей приложения Garant Checker Offline.
 * 
 * Copyright 2012 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2012 EasyCoding Team.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace gchclient
{
    public partial class frmFrChk : Form
    {
        private string SteamID;
        public frmFrChk(string sid64)
        {
            InitializeComponent();
            SteamID = sid64;
            DVList.Columns[3].ValueType = typeof(DateTime);
            DVList.Columns[0].ValueType = typeof(int);
        }

        private void frmFrChk_Load(object sender, EventArgs e)
        {
            // Изменяем заголовок окна формы...
            this.Text = String.Format(this.Text, SteamID);
            
            // Задаём параметры окна согласно настройкам приложения...
            this.MinimizeBox = !Properties.Settings.Default.FrWnOverride;
            this.ShowInTaskbar = !Properties.Settings.Default.FrWnOverride;
            this.ShowIcon = !Properties.Settings.Default.FrWnOverride;

            // Запускаем процесс получения списка в отдельном потоке...
            if (!BW_Rcv.IsBusy) { BW_Rcv.RunWorkerAsync(); }

            // Устанавливаем фокус...
            this.Focus();
        }

        private void DVList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string Lnk = DVList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (Regex.IsMatch(Lnk, "^http://steamcommunity.com/profiles/")) { if (Control.ModifierKeys == Keys.Shift) { Process.Start(Lnk); } else { Clipboard.SetText(Lnk); } if (Properties.Settings.Default.FrWnClose) { this.Close(); } }
            }
            catch { }
        }

        private void BW_Rcv_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate() { SB_Status.Text = Properties.Resources.AppSBReceiving; });
                string XMLFileName = Path.GetTempFileName();
                using (WebClient Downloader = new WebClient())
                {
                    Downloader.Headers.Add("User-Agent", Properties.Resources.AppUserAgent);
                    Downloader.Headers.Add("HardwareID", Auth.HardwareID);
                    Downloader.DownloadFile(String.Format(Properties.Resources.APIURI, (Properties.Settings.Default.UseSSL ? "https://" : "http://"), "friends", CoreLib.md5hash(Properties.Settings.Default.PrimKey + Properties.Settings.Default.SecKey), SteamID), XMLFileName);
                }
                try
                {
                    this.Invoke((MethodInvoker)delegate() { SB_Status.Text = Properties.Resources.AppSBBuilding; });
                    XmlDocument XMLD = new XmlDocument();
                    using (FileStream XMLFS = new FileStream(XMLFileName, FileMode.Open, FileAccess.Read))
                    {
                        XMLD.Load(XMLFS);
                        XmlNodeList XMLNList = XMLD.GetElementsByTagName("friend");
                        for (int i = 0; i < XMLNList.Count; i++)
                        {
                            DateTime dtfr = CoreLib.UnixTime2DateTime(Convert.ToDouble(XMLD.GetElementsByTagName("friend_since")[i].InnerText));
                            string friendlystat = "";
                            switch (XMLD.GetElementsByTagName("sitestatus")[i].InnerText)
                            {
                                case "1": friendlystat = Properties.Resources.ListGarantName;
                                    break;
                                case "2": friendlystat = Properties.Resources.ListWhiteName;
                                    break;
                                case "3": friendlystat = Properties.Resources.ListBlackName;
                                    break;
                                case "5": friendlystat = Properties.Resources.ListBlAucName;
                                    break;
                                case "6": friendlystat = Properties.Resources.ListStaffName;
                                    break;
                                case "7": friendlystat = Properties.Resources.ListPremName;
                                    break;
                                case "8": friendlystat = Properties.Resources.ListNotTrName;
                                    break;
                                default: friendlystat = Properties.Resources.ListNoneName;
                                    break;
                            }
                            this.Invoke((MethodInvoker)delegate() { DVList.Rows.Add(i + 1, XMLD.GetElementsByTagName("lastnick")[i].InnerText, friendlystat, dtfr, String.Format(@"http://steamcommunity.com/profiles/{0}/", XMLD.GetElementsByTagName("steamid64")[i].InnerText)); });
                        }
                        XMLFS.Close();
                    }
                    File.Delete(XMLFileName);
                }
                catch
                {
                    if (File.Exists(XMLFileName)) { File.Delete(XMLFileName); }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BW_Rcv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Изменяем статус в строке...
            this.Invoke((MethodInvoker)delegate() { SB_Status.Text = Properties.Resources.AppSBReady; });

            // Устанавливаем фокус на окно...
            this.Focus();

            // Проверяем нашлось ли что-то...
            if (DVList.Rows.Count == 0)
            {
                MessageBox.Show(Properties.Resources.AppFrErr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void frmFrChk_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_Rcv.IsBusy;
        }
    }
}