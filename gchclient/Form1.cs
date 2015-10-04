/*
 * Главная форма приложения Garant Checker Offline.
 * 
 * Copyright 2012 - 2015 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2015 EasyCoding Team.
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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection;

namespace gchclient
{
    public partial class frmMain : Form
    {
        #region Internal Variables
        private string AVTDir = Path.Combine(Path.GetTempPath(), Properties.Resources.AppIntName);
        private string AppPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private string PrevURL = "";
        private string UsrSteamID = "";
        private string SID64 = "";
        private string AvatarImage;
        private bool UpdateAvailable;
        private bool LastStatus;
        private string LastError;
        #endregion

        #region Internal Methods
        private void SetAvatar(string AvatarPath)
        {
            try { this.Invoke((MethodInvoker)delegate() { RV_Avatar.Image = new Bitmap(AvatarPath); }); }
            catch { this.Invoke((MethodInvoker)delegate() { RV_Avatar.Image = Properties.Resources.null_avatar; }); }
        }

        private void AvatarDownloader_Completed(object sender, AsyncCompletedEventArgs e)
        {
            SetAvatar(AvatarImage);
        }

        private void CheckUser(string API, string Key1, string Key2, string UID)
        {
            string Key = CoreLib.md5hash(Key1 + Key2);
            Checker Chk = new Checker(API, Key, UID, Properties.Settings.Default.UseSSL);
            LastStatus = Chk.Result;
            LastError = Chk.ErrMsg;
            if (Chk.Result)
            {
                this.Invoke((MethodInvoker)delegate() { RV_Nick.Text = Chk.Nickname; });
                this.Invoke((MethodInvoker)delegate() { RV_SteamID.Text = Chk.SteamID; });
                this.Invoke((MethodInvoker)delegate() { UsrSteamID = Chk.SteamID; });
                if (!(Directory.Exists(AVTDir))) { Directory.CreateDirectory(AVTDir); }
                AvatarImage = Path.Combine(AVTDir, CoreLib.md5hash(Chk.AvatarURL) + ".jpg");
                if (!(File.Exists(AvatarImage)))
                {
                    try
                    {
                        using (WebClient AvatarDownloader = new WebClient())
                        {
                            AvatarDownloader.Headers.Add("User-Agent", Properties.Resources.AppUserAgent);
                            AvatarDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(AvatarDownloader_Completed);
                            AvatarDownloader.DownloadFileAsync(new Uri(Chk.AvatarURL), AvatarImage);
                        }
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate() { RV_Avatar.Image = Properties.Resources.null_avatar; });
                    }
                }
                else
                {
                    SetAvatar(AvatarImage);
                }
                switch (Chk.SiteStatus)
                {
                    case "1": // Гарант...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUMiddle);
                                RV_SiteStatus.ForeColor = Color.Green;
                            });
                        }
                        break;
                    case "2": // БС...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUWhite);
                                RV_SiteStatus.ForeColor = Color.Green;
                            });
                        }
                        break;
                    case "3": // ЧС...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUBlack);
                                RV_SiteStatus.ForeColor = Color.Red;
                            });
                        }
                        break;
                    case "4": // Нейтральный...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUNeutral);
                                RV_SiteStatus.ForeColor = Color.Black;
                            });
                        }
                        break;
                    case "5": // ЧС аукциона...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUBlackAuc);
                                RV_SiteStatus.ForeColor = Color.Red;
                            });
                        }
                        break;
                    case "6": // Сотрудник...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUStaff);
                                RV_SiteStatus.ForeColor = Color.Blue;
                            });
                        }
                        break;
                    case "7": // Премиум-юзер...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUPrem);
                                RV_SiteStatus.ForeColor = Color.DarkViolet;
                            });
                        }
                        break;
                    case "8": // Ненадёжный...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUGray);
                                RV_SiteStatus.ForeColor = Color.Purple;
                            });
                        }
                        break;
                    default: // Что-то новое. Наверное API сменился, выдадим заглушку...
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUUnknown);
                                RV_SiteStatus.ForeColor = Color.Black;
                            });
                        }
                        break;
                }
                this.Invoke((MethodInvoker)delegate() { RV_AdvStatus.Text = String.Format(Properties.Resources.TemplateSteamRep, Chk.SRStatus); });
                this.Invoke((MethodInvoker)delegate() { RV_PermaLink.Text = Chk.Permalink; });
                SID64 = Chk.SteamID64;
                if (Chk.VCStatus == "0")
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        RV_VCStatusA.Text = String.Format(Properties.Resources.VCStatusA, Properties.Resources.VCStatusNormal);
                        RV_VCStatusA.ForeColor = Color.Black;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        RV_VCStatusA.Text = String.Format(Properties.Resources.VCStatusA, Properties.Resources.VCStatusBanned);
                        RV_VCStatusA.ForeColor = Color.Red;
                    });
                }
                if (Chk.Free2PlaySt == "1")
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        RV_F2P.Text = Properties.Resources.F2PAccTextStatus;
                        RV_F2P.BackColor = Color.Yellow;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        RV_F2P.Text = "";
                        RV_F2P.BackColor = Control.DefaultBackColor;
                    });
                }
                this.Invoke((MethodInvoker)delegate() { RV_CustDescr.Text = (!String.IsNullOrWhiteSpace(Chk.CustomText) && (Chk.CustomText != Properties.Resources.CustInfoNone)) ? Chk.CustomText : Properties.Resources.CustInfoNone; });
                switch (Chk.TradeStatus)
                {
                    case "0":
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_TradeStatus.Text = String.Format(Properties.Resources.TradeST, Properties.Resources.TradeNormal);
                                RV_TradeStatus.ForeColor = Color.Black;
                            });
                        }
                        break;
                    case "1":
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_TradeStatus.Text = String.Format(Properties.Resources.TradeST, Properties.Resources.TradeBanned);
                                RV_TradeStatus.ForeColor = Color.IndianRed;
                            });
                        }
                        break;
                    case "2":
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                RV_TradeStatus.Text = String.Format(Properties.Resources.TradeST, Properties.Resources.TradeIsp);
                                RV_TradeStatus.ForeColor = Color.DarkBlue;
                            });
                        }
                        break;
                }
                this.Invoke((MethodInvoker)delegate() { RV_GameBans.Text = String.Format(Properties.Resources.TemplateGameBans, Chk.GameBans); });
            }
        }
        #endregion

        #region Internal Workers
        private void BW_Chk_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckUser(Properties.Resources.APIURI, Properties.Settings.Default.PrimKey, Properties.Settings.Default.SecKey, InpStr.Text);
        }

        private void BW_Chk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResultView.Visible = LastStatus;
            if (LastStatus)
            {
                this.Size = new Size(762, 563);
                L_LegalInfo.Location = new Point(25, 501);
                this.Show();
                NativeFn.ActivateWindow(Handle);
            }
            else
            {
                this.Size = new Size(762, 261);
                L_LegalInfo.Location = new Point(25, 200);
                if (this.Visible) { MessageBox.Show(LastError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); } else { TrayIcon.ShowBalloonTip(800, Properties.Resources.AppName, LastError, ToolTipIcon.Warning); }
            }
        }

        private void BW_UpdChk_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Вычисляем разницу между текущей датой и датой последнего обновления...
                TimeSpan TS = DateTime.Now - Properties.Settings.Default.LastUpdateTime;
                if (TS.Days >= 2) // Проверяем время с момента последней проверки...
                {
                    // Требуется проверка обновлений...
                    using (WebClient Downloader = new WebClient())
                    {
                        Downloader.Headers.Add("User-Agent", Properties.Resources.AppUserAgent);
                        Downloader.Headers.Add("HardwareID", Auth.HardwareID);
                        string DnlStr = Downloader.DownloadString(Properties.Resources.UpdateURL);
                        string NewVersion = DnlStr.Substring(0, DnlStr.IndexOf("!"));
                        string UpdateURI = DnlStr.Remove(0, DnlStr.IndexOf("!") + 1);
                        Version NVer = new Version(NewVersion);
                        if (NVer > Assembly.GetEntryAssembly().GetName().Version)
                        {
                            // Доступны обновления...
                            UpdateAvailable = true;
                            this.Invoke((MethodInvoker)delegate()
                            {
                                // Выводим текст...
                                L_LegalInfo.Text = String.Format(Properties.Resources.AppUpdateAvailable, NVer);
                                // Изменяем цвета и вид курсора...
                                L_LegalInfo.BackColor = Color.Red;
                                L_LegalInfo.ForeColor = Color.White;
                                L_LegalInfo.Cursor = Cursors.Hand;
                            });
                        }
                        else
                        {
                            // Обновлений нет...
                            UpdateAvailable = false;
                            // Установим время последней проверки обновлений...
                            Properties.Settings.Default.LastUpdateTime = DateTime.Now;
                        }
                    }
                }
            }
            catch { }
        }

        private void BW_HwGet_DoWork(object sender, DoWorkEventArgs e)
        {
            try { Auth.HardwareID = Auth.GenerateHWID(); } catch { Auth.HardwareID = ""; }
        }

        private void BW_HwGet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Включаем перехватчик буфера обмена...
            if (Properties.Settings.Default.AllowClipbCheck) { Timer.Start(); } else { Timer.Stop(); Timer.Enabled = false; }
        }
        #endregion

        #region Form Methods
        public frmMain()
        {
            InitializeComponent();
            // Импортируем настройки из предыдущей версии...
            if (Properties.Settings.Default.CallUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.CallUpgrade = false;
            }
            // Вычисляем HardwareID для текущего компьютера...
            if (!BW_HwGet.IsBusy) { BW_HwGet.RunWorkerAsync(); }
            // Проверим наличие токена и в случае отсутствии выведем форму их ввода...
            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.PrimKey) && String.IsNullOrWhiteSpace(Properties.Settings.Default.SecKey))
            {
                TrayIcon.Visible = false;
                frmOptions FRMOPT = new frmOptions();
                FRMOPT.ShowDialog();
                TrayIcon.Visible = true;
            }
            // Регистрируем "горячую" клавишу...
            if (Properties.Settings.Default.AllowGlobKey)
            {
                try
                {
                    Hotkey hk = new Hotkey();
                    hk.KeyCode = Properties.Settings.Default.Hotkey;
                    hk.Pressed += delegate { if (this.Visible) { this.Hide(); } else { this.Show(); NativeFn.ActivateWindow(Handle); } };
                    hk.Register(this);
                }
                catch { }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Проверим на скрытый запуск...
            string[] CMDLineA = Environment.GetCommandLineArgs();
            if (CMDLineA.Length > 1)
            {
                if (CMDLineA[1] == "/hide")
                {
                    // Скрываем форму...
                    BeginInvoke(new MethodInvoker(delegate { Hide(); }));
                }
            }
            // Управляем размерами формы и текстом заголовка...
            this.Text = String.Format(this.Text, Assembly.GetEntryAssembly().GetName().Version.ToString());
            this.Size = new Size(762, 261);
            L_LegalInfo.Location = new Point(25, 200);
            // Выводим или скрываем кнопки...
            RV_CheckFriends.Visible = Properties.Settings.Default.ShowQuickBtns;
            RV_AddFriend.Visible = Properties.Settings.Default.ShowQuickBtns;
            RV_ViewBackPack.Visible = Properties.Settings.Default.ShowQuickBtns;
            RV_Report.Visible = Properties.Settings.Default.ShowQuickBtns;
            // Проверим наличие обновлений программы (если разрешено в настройках)...
            if (Properties.Settings.Default.EnableAutoUpdate && (Properties.Settings.Default.LastUpdateTime != null)) { if (!BW_UpdChk.IsBusy) { BW_UpdChk.RunWorkerAsync(); } }
        }

        private void CM_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(Properties.Settings.Default.PrimKey)) && !(String.IsNullOrWhiteSpace(Properties.Settings.Default.SecKey)))
            {
                if (!(String.IsNullOrWhiteSpace(InpStr.Text)))
                {
                    if (Regex.IsMatch(InpStr.Text, Properties.Resources.AppChkRegEx))
                    {
                        InpStr.Text = CoreLib.FormatLink(InpStr.Text);
                    }
                    if (!BW_Chk.IsBusy)
                    {
                        BW_Chk.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.AppWorkerBusy, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.AppFieldEmpty, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.AppNoTokensErr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RV_PermaLink_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(((Label)sender).Text, "^http://steamcommunity.com/profiles/")) { Process.Start(((Label)sender).Text); }
        }

        private void InpStr_DoubleClick(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState) { this.Hide(); }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                NativeFn.ActivateWindow(Handle);
            }
        }

        private void CM_About_Click(object sender, EventArgs e)
        {
            TrayIcon.ShowBalloonTip(1800, Properties.Resources.AppName, "Авторские права: V1TSK (vitaly@easycoding.org).\n\nАвторы не дают никаких гарантий (явных или подразумеваемых). Вы используете программу на свой страх и риск.\n\nЗапустив программу, вы безоговорочно приняли условия лицензии.", ToolTipIcon.Info);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();
            if (!(String.IsNullOrWhiteSpace(Properties.Settings.Default.PrimKey)) && !(String.IsNullOrWhiteSpace(Properties.Settings.Default.SecKey)))
            {
                // Проверим содержит ли буфер обмена текст...
                if (Clipboard.ContainsText())
                {
                    // Получаем содержимое буфера обмена...
                    string ClipText = Clipboard.GetText();
                    // Не будем проверять одно и то же несколько раз...
                    if (PrevURL != ClipText)
                    {
                        // Проверим наличие ссылки на профиль в буфере обмена...
                        if (Regex.IsMatch(ClipText, Properties.Resources.AppChkRegEx))
                        {
                            // Проверим свободны ли ресурсы обработчика...
                            if (!BW_Chk.IsBusy)
                            {
                                // Сохраняем предыдущее значение...
                                PrevURL = ClipText;
                                // Прочистим строку от аргументов...
                                ClipText = CoreLib.FormatLink(ClipText);
                                if (Properties.Settings.Default.IgnoreList.IndexOf(ClipText.ToLower()) == -1)
                                {
                                    // Прописываем в строке URL...
                                    InpStr.Text = ClipText;
                                    // Выполняем...
                                    BW_Chk.RunWorkerAsync();
                                }
                            }
                        }
                    }
                }
                Timer.Enabled = true;
            }
        }

        private void RV_Nick_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CopySIDiN)
            {
                Clipboard.SetText(UsrSteamID);
                TrayIcon.ShowBalloonTip(1000, Properties.Resources.AppName, String.Format(Properties.Resources.AppMsgSiDClipb, UsrSteamID), ToolTipIcon.Info);
            }
            else
            {
                Clipboard.SetText(RV_Nick.Text);
                TrayIcon.ShowBalloonTip(1000, Properties.Resources.AppName, Properties.Resources.AppMsgNicknClipb, ToolTipIcon.Info);
            }
        }

        private void LNK_Copy_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(RV_PermaLink.Text, "^http://steamcommunity.com/profiles/")) { Clipboard.SetText(RV_PermaLink.Text); }
            TrayIcon.ShowBalloonTip(1000, Properties.Resources.AppName, Properties.Resources.AppMSGLnkCopClipb, ToolTipIcon.Info);
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            Timer.Enabled = !BW_HwGet.IsBusy && Properties.Settings.Default.AllowClipbCheck && !this.Focused;
        }

        private void LNK_Go_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(RV_PermaLink.Text, "^http://steamcommunity.com/profiles/")) { Process.Start(RV_PermaLink.Text); }
        }

        private void L_LegalInfo_Click(object sender, EventArgs e)
        {
            if (UpdateAvailable)
            {
                try
                {
                    Process.Start(Path.Combine(AppPath, "gchupdater.exe"), Path.GetFileName(Assembly.GetEntryAssembly().Location));
                    Application.Exit();
                }
                catch
                {
                    MessageBox.Show(Properties.Resources.AppNoUpdater, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CDM_OpenLnk_Click(object sender, EventArgs e)
        {
            Regex urlRx = new Regex(@"(?<url>((http|https):[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[-]|[?]|[=]|[#]|[~]|[_]|[:])*)", RegexOptions.IgnoreCase);
            MatchCollection MCol = urlRx.Matches(RV_CustDescr.Text);
            foreach (Match MRes in MCol)
            {
                // Проверим не ссылка ли на картинку в URL. Для картинок используем свой вьювер...
                if (Regex.IsMatch(MRes.Groups["url"].Value, ".(png|jpg|jpeg|gif)$"))
                {
                    // Откроем форму с вьювером...
                    frmViewer FView = new frmViewer(MRes.Groups["url"].Value, SID64);
                    if (Properties.Settings.Default.FrWnOverride) { FView.ShowDialog(); } else { FView.Show(); }
                }
                else
                {
                    // Ссылка не является картинкой, поэтому попробуем открыть через ShellExecute...
                    try
                    {
                        Process.Start(MRes.Groups["url"].Value);
                    }
                    catch
                    {
                        MessageBox.Show(Properties.Resources.AppNoURLStr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void LNK_CustClipB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RV_CustDescr.Text);
        }

        private void LNK_ValFriends_Click(object sender, EventArgs e)
        {
            frmFrChk frmChk = new frmFrChk(SID64);
            if (Properties.Settings.Default.FrWnOverride) { frmChk.ShowDialog(); } else { frmChk.Show(); }
        }

        private void CM_Tokens_Click(object sender, EventArgs e)
        {
            frmOptions FRMOPT = new frmOptions();
            FRMOPT.ShowDialog();
        }


        private void RV_SteamID_Click(object sender, EventArgs e)
        {
            string Sid = Control.ModifierKeys != Keys.Shift ? UsrSteamID : SID64;
            try { Clipboard.SetText(Sid); TrayIcon.ShowBalloonTip(1000, Properties.Resources.AppName, String.Format(Properties.Resources.AppMsgSiDClipb, Sid), ToolTipIcon.Info); } catch { }
        }

        private void RV_AddFriend_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(String.Format("steam://friends/add/{0}", SID64));
            }
            catch
            {
                MessageBox.Show(Properties.Resources.AppURIStartFail, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RV_ViewBackPack_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(String.Format("http://www.tf2items.com/profiles/{0}", SID64));
            }
            catch
            {
                MessageBox.Show(Properties.Resources.AppStartFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CM_Settings_Click(object sender, EventArgs e)
        {
            frmOptions FRMOPT = new frmOptions();
            FRMOPT.ShowDialog();
        }

        private void CM_TokenInfo_Click(object sender, EventArgs e)
        {
            frmTokenInfo FrmTInfo = new frmTokenInfo();
            FrmTInfo.ShowDialog();
        }

        private void RV_Report_Click(object sender, EventArgs e)
        {
            frmReportU FrmRep = new frmReportU(RV_SteamID.Text);
            FrmRep.ShowDialog();
        }
        #endregion
    }
}
