/*
 * Форма настроек приложения Garant Checker Offline.
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
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс формы настроек приложения Garant Checker Offline.
    /// </summary>
    public partial class frmOptions : Form
    {
        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        public frmOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод "загрузка формы".
        /// </summary>
        private void frmOptions_Load(object sender, EventArgs e)
        {
            // Считаем настройки...
            InpPriToken.Text = Properties.Settings.Default.PrimKey;
            InpSecToken.Text = Properties.Settings.Default.SecKey;
            HwIDFld.Text = Auth.HardwareID;
            Opt_ProtocolType.SelectedIndex = Properties.Settings.Default.UseSSL ? 0 : 1;
            Opt_InvViewer.SelectedIndex = Properties.Settings.Default.InventoryViewer;
            Opt_FrWOverride.Checked = Properties.Settings.Default.FrWnOverride;
            Opt_FrWHide.Checked = Properties.Settings.Default.FrWnClose;
            Opt_EnableHotKey.Checked = Properties.Settings.Default.AllowGlobKey;
            Opt_Hotkey.Enabled = Properties.Settings.Default.AllowGlobKey;
            Opt_Hotkey.Text = Properties.Settings.Default.Hotkey.ToString();
            Opt_FrWQbnts.Checked = Properties.Settings.Default.ShowQuickBtns;
            Opt_CpSidName.Checked = Properties.Settings.Default.CopySIDiN;
            Opt_UseNewSteamIDFormat.Checked = Properties.Settings.Default.UseSteamIDv3;
            Opt_AutoUpdate.Checked = Properties.Settings.Default.EnableAutoUpdate;
            Opt_ClipbInt.Checked = Properties.Settings.Default.AllowClipbCheck;
            try { Opt_Autorun.Checked = Autorun.CheckStatus("gchclient"); } catch { Opt_Autorun.Checked = false; }
            try { foreach (Object Obj in Properties.Settings.Default.IgnoreList) { Opt_IgnEd.Rows.Add(Obj.ToString()); } } catch { Opt_IgnEd.Rows.Clear(); }
        }

        /// <summary>
        /// Метод, срабатывающий при сохранении изменений.
        /// </summary>
        private void SaveNClose_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(InpPriToken.Text)) && !(String.IsNullOrWhiteSpace(InpSecToken.Text)))
            {
                // Проверим данные токена...
                string XMLFileName = Path.GetTempFileName();

                try
                {
                    // Загружаем XML...
                    CoreLib.DownloadRemoteFile(String.Format(Properties.Resources.APIURI, (Properties.Settings.Default.UseSSL ? "https://" : "http://"), "test", CoreLib.md5hash(InpPriToken.Text + InpSecToken.Text), String.Empty), XMLFileName, Properties.Resources.AppUserAgent, Auth.HardwareID);

                    // Разбираем полученный XML...
                    using (FileStream XMLFS = new FileStream(XMLFileName, FileMode.Open, FileAccess.Read))
                    {
                        XmlDocument XMLD = new XmlDocument();
                        XMLD.Load(XMLFS);
                        if (XMLD.GetElementsByTagName("result")[0].InnerText == "PASSED")
                        {
                            // Сохраняем настройки "горячей клавиши"...
                            switch (Opt_Hotkey.SelectedIndex)
                            {
                                case 0: Properties.Settings.Default.Hotkey = Keys.F8;
                                    break;
                                case 1: Properties.Settings.Default.Hotkey = Keys.F9;
                                    break;
                                case 2: Properties.Settings.Default.Hotkey = Keys.F10;
                                    break;
                                case 3: Properties.Settings.Default.Hotkey = Keys.F11;
                                    break;
                                case 4: Properties.Settings.Default.Hotkey = Keys.F12;
                                    break;
                                default: Properties.Settings.Default.Hotkey = Keys.F11;
                                    break;
                            }

                            // Сохраняем все остальные настройки приложения...
                            Properties.Settings.Default.PrimKey = InpPriToken.Text;
                            Properties.Settings.Default.SecKey = InpSecToken.Text;
                            Properties.Settings.Default.UseSSL = Opt_ProtocolType.SelectedIndex == 0;
                            Properties.Settings.Default.FrWnOverride = Opt_FrWOverride.Checked;
                            Properties.Settings.Default.FrWnClose = Opt_FrWHide.Checked;
                            Properties.Settings.Default.AllowGlobKey = Opt_EnableHotKey.Checked;
                            Properties.Settings.Default.InventoryViewer = Opt_InvViewer.SelectedIndex;
                            Properties.Settings.Default.ShowQuickBtns = Opt_FrWQbnts.Checked;
                            Properties.Settings.Default.CopySIDiN = Opt_CpSidName.Checked;
                            Properties.Settings.Default.EnableAutoUpdate = Opt_AutoUpdate.Checked;
                            Properties.Settings.Default.AllowClipbCheck = Opt_ClipbInt.Checked;
                            Properties.Settings.Default.UseSteamIDv3 = Opt_UseNewSteamIDFormat.Checked;

                            // Сохраняем настройки автозапуска...
                            try { if (Opt_Autorun.Checked) { Autorun.Enable("gchclient"); } else { Autorun.Disable("gchclient"); } } catch { }

                            // Сохраняем настройки списка игнорирования...
                            try
                            {
                                Properties.Settings.Default.IgnoreList.Clear();
                                if (Opt_IgnEd.Rows.Count > 1)
                                {
                                    for (int i = 0; i < Opt_IgnEd.Rows.Count - 1; i++)
                                    {
                                        string RwStr = Opt_IgnEd.Rows[i].Cells[0].Value.ToString().Trim();
                                        if (!(String.IsNullOrWhiteSpace(RwStr)))
                                        {
                                            if (Regex.IsMatch(RwStr, Properties.Resources.AppChkRegEx))
                                            {
                                                RwStr = CoreLib.FormatLink(RwStr);
                                                Properties.Settings.Default.IgnoreList.Add(RwStr.ToLower());
                                            }
                                        }
                                    }
                                }
                            }
                            catch { }

                            // Записываем настройки в файл...
                            Properties.Settings.Default.Save();

                            // Выводим сообщение...
                            MessageBox.Show(Properties.Resources.AppSettSaved, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Закрываем форму настроек...
                            Close();
                        }
                    }

                    // Удаляем временный файл...
                    File.Delete(XMLFileName);
                }
                catch
                {
                    if (File.Exists(XMLFileName)) { File.Delete(XMLFileName); }
                    MessageBox.Show(Properties.Resources.AppIncorrectTokens, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.AppSettEmptyS, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        /// <summary>
        /// Метод, срабатывающий при клике по "включить горячую клавишу".
        /// </summary>
        private void Opt_EnableHotKey_CheckedChanged(object sender, EventArgs e)
        {
            Opt_Hotkey.Enabled = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// Метод, срабатывающий при клике по полю с HardwareID.
        /// </summary>
        private void HwIDFld_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(((Label)sender).Text)) { Clipboard.SetText(((Label)sender).Text); }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Вырезать".
        /// </summary>
        private void Opt_IEd_Tb_Cut_Click(object sender, EventArgs e)
        {
            if (Opt_IgnEd.Rows[Opt_IgnEd.CurrentRow.Index].Cells[Opt_IgnEd.CurrentCell.ColumnIndex].Value != null)
            {
                Clipboard.SetText(Opt_IgnEd.Rows[Opt_IgnEd.CurrentRow.Index].Cells[Opt_IgnEd.CurrentCell.ColumnIndex].Value.ToString());
                Opt_IgnEd.Rows[Opt_IgnEd.CurrentRow.Index].Cells[Opt_IgnEd.CurrentCell.ColumnIndex].Value = null;
            }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Копировать".
        /// </summary>
        private void Opt_IEd_Tb_Copy_Click(object sender, EventArgs e)
        {
            if (Opt_IgnEd.Rows[Opt_IgnEd.CurrentRow.Index].Cells[Opt_IgnEd.CurrentCell.ColumnIndex].Value != null)
            {
                Clipboard.SetText(Opt_IgnEd.Rows[Opt_IgnEd.CurrentRow.Index].Cells[Opt_IgnEd.CurrentCell.ColumnIndex].Value.ToString());
            }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Вставить".
        /// </summary>
        private void Opt_IEd_Tb_Paste_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText()) { Opt_IgnEd.Rows[Opt_IgnEd.CurrentRow.Index].Cells[Opt_IgnEd.CurrentCell.ColumnIndex].Value = Clipboard.GetText(); }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.AppIgnClipbErr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Удалить строку".
        /// </summary>
        private void Opt_IEd_Tb_DelRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (Opt_IgnEd.Rows.Count > 1) { Opt_IgnEd.Rows.Remove(Opt_IgnEd.CurrentRow); }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.AppIgnLDlEx, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Очистить форму".
        /// </summary>
        private void Opt_IEd_Tb_Clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.AppIgnLDMsg, Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) { Opt_IgnEd.Rows.Clear(); }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Добавить строку".
        /// </summary>
        private void Opt_IEd_Tb_AddRow_Click(object sender, EventArgs e)
        {
            Opt_IgnEd.Rows.Add(String.Empty);
        }
    }
}
