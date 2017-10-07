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
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс сообщения о мошеннике Garant Checker Offline.
    /// </summary>
    public partial class FrmRep : Form
    {
        /// <summary>
        /// Хранит и возвращает SteamID профиля.
        /// </summary>
        private string SteamID { get; set; }

        /// <summary>
        /// Хранит и возвращает пользовательский текст жалобы.
        /// </summary>
        private string UserText { get; set; }

        /// <summary>
        /// Хранит и возвращает индекс катагории жалобы.
        /// </summary>
        private string ListID { get; set; }

        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        /// <param name="Sid32">SteamID профиля в 32-битном формате</param>
        public FrmRep(string Sid32)
        {
            InitializeComponent();
            SteamID = Sid32;
        }

        /// <summary>
        /// Событие загрузки формы.
        /// </summary>
        private void FrmRep_Load(object sender, EventArgs e)
        {
            W_SteamID.Text = SteamID;
            W_List.SelectedIndex = 0;
        }

        /// <summary>
        /// Событие нажатия на кнопку отправки жалобы.
        /// </summary>
        private void W_Submit_Click(object sender, EventArgs e)
        {
            // Сохраняем пользовательский текст...
            UserText = W_ReportText.Text.Trim();

            // Начинаем обработку жалобы...
            if (!String.IsNullOrWhiteSpace(UserText))
            {
                // Сохраняем индекс списка, куда будем жаловаться...
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

                // Отправляем жалобу в отдельном потоке...
                if (!BW_Main.IsBusy) { BW_Main.RunWorkerAsync(); }
            }
            else
            {
                MessageBox.Show(Properties.Resources.RepEmptyField, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Событие нажатия на кнопку отмены.
        /// </summary>
        private void W_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Асинхронный обработчик. Отправляет жалобу в отдельном потоке.
        /// </summary>
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
                }
                
                // Получаем ответ от сервера...
                using (HttpWebResponse HTTPWResp = (HttpWebResponse)WrQ.GetResponse())
                {
                    if (HTTPWResp.StatusCode == HttpStatusCode.OK) { MessageBox.Show(Properties.Resources.RepSubmitted, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); } else { MessageBox.Show(Properties.Resources.RepError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Событие завершения работы асинхронного обработчика.
        /// </summary>
        private void BW_Main_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
