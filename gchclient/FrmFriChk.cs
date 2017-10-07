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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс формы чекера друзей приложения Garant Checker Offline.
    /// </summary>
    public partial class FrmFriChk : Form
    {
        /// <summary>
        /// Хранит и возвращает SteamID профиля.
        /// </summary>
        private string SteamID { get; set; }

        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        /// <param name="sid64">SteamID профиля в 64-битном формате</param>
        public FrmFriChk(string sid64)
        {
            InitializeComponent();
            SteamID = sid64;
            DVList.Columns[3].ValueType = typeof(DateTime);
            DVList.Columns[0].ValueType = typeof(int);
        }

        /// <summary>
        /// Экспортирует содержимое таблицы в список.
        /// </summary>
        /// <returns>Экспортированный список</returns>
        private List<String> ExportDgvToList()
        {
            // Инициализируем массив...
            List<String> Dv = new List<String>();
            
            // Обойдём все строки...
            foreach (DataGridViewRow Row in DVList.Rows)
            {
                // Инициализируем ещё один массив...
                List<String> Bx = new List<String>();

                // Обойдём все столбцы выбранной строки...
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    Bx.Add(Cell.Value.ToString());
                }

                // Сохраняем результат...
                Dv.Add(String.Join<String>(Properties.Resources.SCDelim, Bx));
            }

            // Возвращаем результат...
            return Dv;
        }

        /// <summary>
        /// Экспортирует содержимое таблицы в файл.
        /// </summary>
        /// <param name="FileName">Имя файла для экспорта</param>
        private void ExportDgvToFile(string FileName)
        {
            // Проверим существование файла и если он есть, удалим...
            if (File.Exists(FileName)) { File.Delete(FileName); }

            // Сохраняем нашу таблицу в файл...
            File.WriteAllLines(FileName, ExportDgvToList());
        }

        /// <summary>
        /// Сравнивает содержимое загруженного файла с таблицей.
        /// </summary>
        /// <param name="FileName">Имя файла экспорта</param>
        private void CompareTableWithDump(string FileName)
        {
            // Создаём массив...
            List<String> Dump = new List<String>(File.ReadAllLines(FileName));
            
            // Создаём переменную для индекса...
            int BufIndex;

            // Обходим нашу базу таблицу в цикле...
            foreach (DataGridViewRow Row in DVList.Rows)
            {
                // Проверяем есть ли такая ссылка на профиль в дампе...
                BufIndex = Dump.FindIndex(x => x.Contains(Row.Cells[4].Value.ToString()));
                
                // Переключаем флаг в таблице...
                if (BufIndex >= 0) { Row.Cells[5].Value = Properties.Resources.SCEqual; Dump.RemoveAt(BufIndex); } else { Row.Cells[5].Value = Properties.Resources.SCAdded; }
            }

            // Проверим оставшееся содержимое загруженного дампа...
            if (Dump.Count() > 0)
            {
                // В файле что-то есть, поэтому обойдём его построчно...
                foreach (string Str in Dump)
                {
                    // Разбираем строку по разделителю...
                    string[] PrX = Str.Split(new string[] { Properties.Resources.SCDelim }, StringSplitOptions.RemoveEmptyEntries);
                    
                    // Вставляем запись в таблицу...
                    try { DVList.Rows.Add(DVList.Rows.Count + 1, PrX[1].Trim(), PrX[2].Trim(), DateTime.Parse(PrX[3].Trim()), PrX[4].Trim(), Properties.Resources.SCDeleted); } catch { /* Do nothing. */ }
                }
            }
        }

        /// <summary>
        /// Событие загрузки формы.
        /// </summary>
        private void FrmFriChk_Load(object sender, EventArgs e)
        {
            // Изменяем заголовок окна формы...
            Text = String.Format(Text, SteamID);
            
            // Задаём параметры окна согласно настройкам приложения...
            MinimizeBox = !Properties.Settings.Default.FrWnOverride;
            ShowInTaskbar = !Properties.Settings.Default.FrWnOverride;
            ShowIcon = !Properties.Settings.Default.FrWnOverride;

            // Запускаем процесс получения списка в отдельном потоке...
            if (!BW_Rcv.IsBusy) { BW_Rcv.RunWorkerAsync(); }

            // Устанавливаем фокус...
            Focus();
        }

        /// <summary>
        /// Событие нажатия левой кнопкой мыши по ячейке таблицы.
        /// </summary>
        private void DVList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string Lnk = DVList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (Regex.IsMatch(Lnk, Properties.Resources.AppProfileRegex)) { if (Control.ModifierKeys == Keys.Shift) { CoreLib.OpenWebPage(Lnk); } else { Clipboard.SetText(Lnk); } if (Properties.Settings.Default.FrWnClose) { Close(); } }
            }
            catch { }
        }

        /// <summary>
        /// Асинхронный обработчик. Выполняется в отдельном потоке. Заполняет таблицу.
        /// </summary>
        private void BW_Rcv_DoWork(object sender, DoWorkEventArgs e)
        {
            // Получаем XML с сервера...
            Invoke((MethodInvoker)delegate () { SB_Status.Text = Properties.Resources.AppSBReceiving; });
            string XMLObj = CoreLib.DownloadRemoteString(String.Format(Properties.Resources.APIURI, (Properties.Settings.Default.UseSSL ? "https://" : "http://"), "friends", CoreLib.md5hash(Properties.Settings.Default.PrimKey + Properties.Settings.Default.SecKey), SteamID), Properties.Resources.AppUserAgent, Auth.HardwareID);

            // Обходим полученный XML...
            Invoke((MethodInvoker)delegate () { SB_Status.Text = Properties.Resources.AppSBBuilding; });
            XmlDocument XMLD = new XmlDocument();
            XMLD.LoadXml(XMLObj);
            XmlNodeList XMLNList = XMLD.GetElementsByTagName("friend");
            for (int i = 0; i < XMLNList.Count; i++)
            {
                DateTime dtfr = CoreLib.UnixTime2DateTime(Convert.ToDouble(XMLD.GetElementsByTagName("friend_since")[i].InnerText));
                string friendlystat = String.Empty;
                switch (XMLD.GetElementsByTagName("sitestatus")[i].InnerText)
                {
                    case "1":
                        friendlystat = Properties.Resources.ListGarantName;
                        break;
                    case "2":
                        friendlystat = Properties.Resources.ListWhiteName;
                        break;
                    case "3":
                        friendlystat = Properties.Resources.ListBlackName;
                        break;
                    case "5":
                        friendlystat = Properties.Resources.ListBlAucName;
                        break;
                    case "6":
                        friendlystat = Properties.Resources.ListStaffName;
                        break;
                    case "7":
                        friendlystat = Properties.Resources.ListPremName;
                        break;
                    case "8":
                        friendlystat = Properties.Resources.ListNotTrName;
                        break;
                    default:
                        friendlystat = Properties.Resources.ListNoneName;
                        break;
                }
                Invoke((MethodInvoker)delegate () { DVList.Rows.Add(i + 1, XMLD.GetElementsByTagName("lastnick")[i].InnerText, friendlystat, dtfr, String.Format(@"http://steamcommunity.com/profiles/{0}/", XMLD.GetElementsByTagName("steamid64")[i].InnerText), Properties.Resources.SCUnknown); });
            }
        }

        /// <summary>
        /// Событие завершения работы асинхронного обработчика.
        /// </summary>
        private void BW_Rcv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Изменяем статус в строке...
            Invoke((MethodInvoker)delegate() { SB_Status.Text = Properties.Resources.AppSBReady; });

            if (e.Error == null)
            {
                // Устанавливаем фокус на окно...
                Focus();

                // Проверяем нашлось ли что-то...
                if (DVList.Rows.Count == 0)
                {
                    MessageBox.Show(Properties.Resources.AppFrErr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Событие "попытка закрытия формы".
        /// </summary>
        private void FrmFriChk_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_Rcv.IsBusy;
        }

        /// <summary>
        /// Событие "нажатие клавиши".
        /// </summary>
        private void DVList_KeyDown(object sender, KeyEventArgs e)
        {
            // Нажата комбинация Ctrl+S. Начнём сохранение содержимого таблицы в файл...
            if (e.Control && e.KeyCode == Keys.S)
            {
                // Выведем диалог сохранения файла...
                if (SV_SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    try { ExportDgvToFile(SV_SaveDlg.FileName); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

            // Нажата комбинация Ctrl+O. Откроем дамп списка друзей и начнём сравнение...
            if (e.Control && e.KeyCode == Keys.O)
            {
                // Выведем диалог открытия файла...
                if (SV_OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    try { CompareTableWithDump(SV_OpenDlg.FileName); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
    }
}
