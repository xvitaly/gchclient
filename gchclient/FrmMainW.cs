/*
 * Главная форма приложения Garant Checker Offline.
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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс главной формы приложения Garant Checker Offline.
    /// </summary>
    public partial class FrmMainW : Form
    {
        #region Internal Properties

        /// <summary>
        /// Хранит и возвращает последний проверенный приложением URL.
        /// </summary>
        private string PrevURL { get; set; }

        /// <summary>
        /// Проверяет и хранит результаты проверки профилей.
        /// </summary>
        private Checker Chk { get; set; }

        /// <summary>
        /// Хранит и возвращает информацию об обновлениях.
        /// </summary>
        private Updater UpdMan { get; set; }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Устанавливает обновление в виде отдельного исполняемого файла.
        /// </summary>
        private void InstallBinaryUpdate()
        {
            // Генерируем имя файла обновления...
            string UpdateFileName = Updater.GenerateUpdateFileName(Path.Combine(Path.GetTempPath(), Path.GetFileName(UpdMan.AppUpdateURL)));

            // Загружаем файл асинхронно...
            WxManager.ShowDownloadForm(UpdMan.AppUpdateURL, UpdateFileName);

            // Выполняем проверки и устанавливаем обновление...
            if (File.Exists(UpdateFileName))
            {
                // Проверяем хеш загруженного файла с эталоном...
                if (CoreLib.CalculateFileMD5(UpdateFileName) == UpdMan.AppUpdateHash)
                {
                    // Выводим сообщение об успешном окончании загрузки и готовности к установке обновления...
                    MessageBox.Show(Properties.Resources.UPD_UpdateSuccessful, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Запускаем установку standalone-обновления...
                    try { CoreLib.OpenWebPage(UpdateFileName); Application.Exit(); } catch { MessageBox.Show(Properties.Resources.UPD_UpdateFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    // Хеш-сумма не совпала, поэтому файл скорее всего повреждён. Удаляем...
                    try { File.Delete(UpdateFileName); } catch { /* Do nothing. */ }

                    // Выводим сообщение о несовпадении контрольной суммы...
                    MessageBox.Show(Properties.Resources.UPD_HashFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Не удалось загрузить файл обновления. Выводим сообщение об ошибке...
                MessageBox.Show(Properties.Resources.UPD_UpdateFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Запускает проверку пользовательского профиля.
        /// </summary>
        /// <param name="API">URL API чекера</param>
        /// <param name="Key1">Первичный ключ токена</param>
        /// <param name="Key2">Вторичный ключ токена</param>
        /// <param name="UID">Строка для проверки</param>
        private void CheckUser(string API, string Key1, string Key2, string UID)
        {
            // Получаем информацию...
            Chk = new Checker(API, CoreLib.md5hash(Key1 + Key2), UID, Properties.Settings.Default.UseSSL);

            // Парсим ответ чекера...
            Invoke((MethodInvoker)delegate () { RV_Nick.Text = Chk.Nickname; RV_SteamID.Text = Properties.Settings.Default.UseSteamIDv3 ? Chk.SteamIDv3 : Chk.SteamID; });

            // Загружаем аватар...
            if (!BW_AvFetch.IsBusy) { BW_AvFetch.RunWorkerAsync(); }

            // Отображаем статус на сайте...
            switch (Chk.SiteStatus)
            {
                case "1": // Гарант...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUMiddle);
                            RV_SiteStatus.ForeColor = Color.Green;
                        });
                    }
                    break;
                case "2": // БС...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUWhite);
                            RV_SiteStatus.ForeColor = Color.Green;
                        });
                    }
                    break;
                case "3": // ЧС...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUBlack);
                            RV_SiteStatus.ForeColor = Color.Red;
                        });
                    }
                    break;
                case "4": // Нейтральный...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUNeutral);
                            RV_SiteStatus.ForeColor = Color.Black;
                        });
                    }
                    break;
                case "5": // ЧС аукциона...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUBlackAuc);
                            RV_SiteStatus.ForeColor = Color.Red;
                        });
                    }
                    break;
                case "6": // Сотрудник...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUStaff);
                            RV_SiteStatus.ForeColor = Color.Blue;
                        });
                    }
                    break;
                case "7": // Премиум-юзер...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUPrem);
                            RV_SiteStatus.ForeColor = Color.DarkViolet;
                        });
                    }
                    break;
                case "8": // Ненадёжный...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUGray);
                            RV_SiteStatus.ForeColor = Color.Purple;
                        });
                    }
                    break;
                default: // Что-то новое. Наверное API сменился, выдадим заглушку...
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_SiteStatus.Text = String.Format(Properties.Resources.TemplateInternal, Properties.Resources.TemplateTFSUUnknown);
                            RV_SiteStatus.ForeColor = Color.Black;
                        });
                    }
                    break;
            }

            // Выводим результат проверки в других системах, а также постоянную ссылку...
            Invoke((MethodInvoker)delegate () { RV_AdvStatus.Text = String.Format(Properties.Resources.TemplateSteamRep, Chk.SRStatus); RV_PermaLink.Text = Chk.Permalink; });

            // Выводим статус VAC...
            if (Chk.VCStatus == "0")
            {
                Invoke((MethodInvoker)delegate ()
                {
                    RV_VCStatusA.Text = String.Format(Properties.Resources.VCStatusA, Properties.Resources.VCStatusNormal);
                    RV_VCStatusA.ForeColor = Color.Black;
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate ()
                {
                    RV_VCStatusA.Text = String.Format(Properties.Resources.VCStatusA, Properties.Resources.VCStatusBanned);
                    RV_VCStatusA.ForeColor = Color.Red;
                });
            }

            // Выводим статус F2P (наличие или отсутствие купленных игр)...
            if (Chk.Free2PlaySt == "1")
            {
                Invoke((MethodInvoker)delegate ()
                {
                    RV_F2P.Text = Properties.Resources.F2PAccTextStatus;
                    RV_F2P.BackColor = Color.Yellow;
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate ()
                {
                    RV_F2P.Text = String.Empty;
                    RV_F2P.BackColor = Control.DefaultBackColor;
                });
            }

            // Выводим кастомное описание...
            Invoke((MethodInvoker)delegate () { RV_CustDescr.Text = (!String.IsNullOrWhiteSpace(Chk.CustomText) && (Chk.CustomText != Properties.Resources.CustInfoNone)) ? Chk.CustomText : Properties.Resources.CustInfoNone; });

            // Выводим статус торговли...
            switch (Chk.TradeStatus)
            {
                case "0":
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_TradeStatus.Text = String.Format(Properties.Resources.TradeST, Properties.Resources.TradeNormal);
                            RV_TradeStatus.ForeColor = Color.Black;
                        });
                    }
                    break;
                case "1":
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_TradeStatus.Text = String.Format(Properties.Resources.TradeST, Properties.Resources.TradeBanned);
                            RV_TradeStatus.ForeColor = Color.IndianRed;
                        });
                    }
                    break;
                case "2":
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            RV_TradeStatus.Text = String.Format(Properties.Resources.TradeST, Properties.Resources.TradeIsp);
                            RV_TradeStatus.ForeColor = Color.DarkBlue;
                        });
                    }
                    break;
            }

            // Выводим статус игровых банов...
            if (Chk.GameBans == "0")
            {
                Invoke((MethodInvoker)delegate ()
                {
                    RV_GameBans.Text = String.Format(Properties.Resources.TemplateGameBans, Properties.Resources.TemplateGameBansNo);
                    RV_GameBans.ForeColor = Color.Black;
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate ()
                {
                    RV_GameBans.Text = String.Format(Properties.Resources.TemplateGameBans, String.Format(Properties.Resources.TemplateGameBansYes, Chk.GameBans));
                    RV_GameBans.ForeColor = Color.Red;
                });
            }
        }

        /// <summary>
        /// Выводит сообщение программы в зависимости от платформы.
        /// </summary>
        /// <param name="Msg">Текст сообщения</param>
        /// <param name="MI">Тип значка сообщения MessageBox</param>
        /// <param name="TI">Тип значка сообщения в трее</param>
        private void ShowNotification(string Msg, MessageBoxIcon MI, ToolTipIcon TI)
        {
            // Проверяем версию ОС. Под W10 всплывающие уведомления не функционируют.
            if (CoreLib.IsModernOS())
            {
                // Выводим сообщение...
                MessageBox.Show(Msg, Properties.Resources.AppName, MessageBoxButtons.OK, MI);
            }
            else
            {
                // Выводим сообщение в трее...
                TrayIcon.ShowBalloonTip(1000, Properties.Resources.AppName, Msg, TI);
            }
        }
        #endregion

        #region Internal Workers
        /// <summary>
        /// Асинхронный обработчик, проверяющий профиль в отдельном потоке.
        /// </summary>
        private void BW_Chk_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate () { Cursor = Cursors.AppStarting; SearchBtn.Image = Properties.Resources.clock; });
            CheckUser(Properties.Resources.APIURI, Properties.Settings.Default.PrimKey, Properties.Settings.Default.SecKey, InpStr.Text);
        }

        /// <summary>
        /// Метод окончания работы асинхронного обработчика, проверяющего профиль.
        /// </summary>
        private void BW_Chk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool res = e.Error == null;
            ResultView.Visible = res;
            Cursor = Cursors.Default;
            SearchBtn.Image = Properties.Resources.search;
            if (res) { Size = new Size(762, 563); L_LegalInfo.Location = new Point(25, 501); Show(); NativeFn.ActivateWindow(Handle); } else { Size = new Size(762, 261); L_LegalInfo.Location = new Point(25, 200); if (Visible) { MessageBox.Show(e.Error.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); } else { ShowNotification(e.Error.Message, MessageBoxIcon.Warning, ToolTipIcon.Warning); } }
        }

        /// <summary>
        /// Асинхронный обработчик, проверяющий обновления программы.
        /// </summary>
        private void BW_UpdChk_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Проверяем наличие обновлений...
                UpdMan = new Updater(Assembly.GetEntryAssembly().Location, Properties.Resources.AppUserAgent);

                // Проверяем версию...
                if (UpdMan.CheckAppUpdate())
                {
                    // Выводом сообщения...
                    Invoke((MethodInvoker)delegate ()
                    {
                        // Выводим текст...
                        L_LegalInfo.Text = String.Format(Properties.Resources.AppUpdateAvailable, UpdMan.AppUpdateVersion);

                        // Изменяем цвета и вид курсора...
                        L_LegalInfo.BackColor = Color.Red;
                        L_LegalInfo.ForeColor = Color.White;
                        L_LegalInfo.Cursor = Cursors.Hand;
                    });
                }
            }
            catch { }
        }

        /// <summary>
        /// Асинхронный обработчик, генерирующий аппаратный ID.
        /// </summary>
        private void BW_HwGet_DoWork(object sender, DoWorkEventArgs e)
        {
            try { Auth.HardwareID = Auth.GenerateHWID(); } catch { Auth.HardwareID = String.Empty; }
        }

        /// <summary>
        /// Метод окончания работы асинхронного обработчика, генерирующего аппаратные ID.
        /// </summary>
        private void BW_HwGet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Включаем перехватчик буфера обмена...
            if (Properties.Settings.Default.AllowClipbCheck) { Timer.Start(); } else { Timer.Stop(); Timer.Enabled = false; }
        }

        /// <summary>
        /// Асинхронный обработчик, загружающий аватары из Интернета.
        /// </summary>
        private void BW_AvFetch_DoWork(object sender, DoWorkEventArgs e)
        {
            // Проверим существует ли каталог для временного хранения загруженных аватаров...
            if (!(Directory.Exists(Chk.LocalAvatarDir))) { Directory.CreateDirectory(Chk.LocalAvatarDir); }
            
            // Проверим существует ли файл. Если нет, загрузим...
            if (!(File.Exists(Chk.LocalAvatarImg)))
            {
                CoreLib.DownloadRemoteFile(Chk.AvatarURL, Chk.LocalAvatarImg, Properties.Resources.AppUserAgent);
            }
        }

        /// <summary>
        /// Событие, выполняемое по завершении загрузки аватара из Интернета.
        /// </summary>
        private void BW_AvFetch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try { RV_Avatar.Image = File.Exists(Chk.LocalAvatarImg) ? new Bitmap(Chk.LocalAvatarImg) : Properties.Resources.null_avatar; } catch { RV_Avatar.Image = Properties.Resources.null_avatar; }
        }
        #endregion

        #region Form Methods
        /// <summary>
        /// Базовый конструктор формы.
        /// </summary>
        public FrmMainW()
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
                WxManager.ShowOptionsForm();
                TrayIcon.Visible = true;
            }
            
            // Регистрируем "горячую" клавишу...
            if (Properties.Settings.Default.AllowGlobKey)
            {
                try
                {
                    Hotkey hk = new Hotkey();
                    hk.KeyCode = Properties.Settings.Default.Hotkey;
                    hk.Pressed += delegate { if (Visible) { Hide(); } else { Show(); NativeFn.ActivateWindow(Handle); } };
                    hk.Register(this);
                }
                catch { }
            }
        }

        /// <summary>
        /// Событие "загрузка формы".
        /// </summary>
        private void FrmMainW_Load(object sender, EventArgs e)
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
            Text = String.Format(Text, Assembly.GetEntryAssembly().GetName().Version);
            Size = new Size(762, 261);
            L_LegalInfo.Location = new Point(25, 200);
            
            // Выводим или скрываем кнопки...
            RV_CheckFriends.Visible = Properties.Settings.Default.ShowQuickBtns;
            RV_AddFriend.Visible = Properties.Settings.Default.ShowQuickBtns;
            RV_ViewBackPack.Visible = Properties.Settings.Default.ShowQuickBtns;
            RV_Report.Visible = Properties.Settings.Default.ShowQuickBtns;
            
            // Проверим наличие обновлений программы (если разрешено в настройках)...
            if (Properties.Settings.Default.EnableAutoUpdate) { if (!BW_UpdChk.IsBusy) { BW_UpdChk.RunWorkerAsync(); } }
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "Выход" значка в трее.
        /// </summary>
        private void CM_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии на кнопку запуска проверки.
        /// </summary>
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(Properties.Settings.Default.PrimKey)) && !(String.IsNullOrWhiteSpace(Properties.Settings.Default.SecKey))) { if (!(String.IsNullOrWhiteSpace(InpStr.Text))) { if (Regex.IsMatch(InpStr.Text, Properties.Resources.AppChkRegEx)) { InpStr.Text = CoreLib.FormatLink(InpStr.Text); } if (!BW_Chk.IsBusy) { BW_Chk.RunWorkerAsync(); } else { MessageBox.Show(Properties.Resources.AppWorkerBusy, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); } } else { MessageBox.Show(Properties.Resources.AppFieldEmpty, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); } } else { MessageBox.Show(Properties.Resources.AppNoTokensErr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии по постоянной ссылке на профиль.
        /// </summary>
        private void RV_PermaLink_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(((Label)sender).Text, Properties.Resources.AppProfileRegex)) { CoreLib.OpenWebPage(((Label)sender).Text); }
        }

        /// <summary>
        /// Метод, срабатывающий при двойном клике по строке ввода.
        /// </summary>
        private void InpStr_DoubleClick(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = String.Empty;
        }

        /// <summary>
        /// Метод, срабатывающий при попытке изменения размеров формы.
        /// </summary>
        private void FrmMainW_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) { Hide(); }
        }

        /// <summary>
        /// Метод, срабатывающий при попытке закрытия формы.
        /// </summary>
        private void FrmMainW_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// Метод, срабатывающий при двойном клике по значку в трее.
        /// </summary>
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Visible) { Hide(); } else { Show(); NativeFn.ActivateWindow(Handle); }
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "О программе" значка в трее.
        /// </summary>
        private void CM_About_Click(object sender, EventArgs e)
        {
            WxManager.ShowAboutForm();
        }

        /// <summary>
        /// Метод, срабатывающий при активации таймера (проверяет ссылки в буфере обмена).
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Останавливаем таймер...
            Timer.Stop();

            // Выполняем проверки...
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

                                // Проверяем наличие в списке игнорирования...
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

                // Снова активируем таймер...
                Timer.Enabled = true;
            }
        }

        /// <summary>
        /// Метод, срабатывающий при выборе нажатии по никнейму.
        /// </summary>
        private void RV_Nick_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CopySIDiN)
            {
                Clipboard.SetText(Properties.Settings.Default.UseSteamIDv3 ? Chk.SteamIDv3 : Chk.SteamID);
                ShowNotification(String.Format(Properties.Resources.AppMsgSiDClipb, Properties.Settings.Default.UseSteamIDv3 ? Chk.SteamIDv3 : Chk.SteamID), MessageBoxIcon.Information, ToolTipIcon.Info);
            }
            else
            {
                Clipboard.SetText(RV_Nick.Text);
                ShowNotification(Properties.Resources.AppMsgNicknClipb, MessageBoxIcon.Information, ToolTipIcon.Info);
            }
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "Копировать ссылку в буфер".
        /// </summary>
        private void LNK_Copy_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(RV_PermaLink.Text, Properties.Resources.AppProfileRegex)) { Clipboard.SetText(RV_PermaLink.Text); }
            ShowNotification(Properties.Resources.AppMSGLnkCopClipb, MessageBoxIcon.Information, ToolTipIcon.Info);
        }

        /// <summary>
        /// Метод, срабатывающий при активации формы.
        /// </summary>
        private void FrmMainW_Activated(object sender, EventArgs e)
        {
            Timer.Enabled = !BW_HwGet.IsBusy && Properties.Settings.Default.AllowClipbCheck && !Focused;
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "Переход по ссылке профиля".
        /// </summary>
        private void LNK_Go_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(RV_PermaLink.Text, Properties.Resources.AppProfileRegex)) { CoreLib.OpenWebPage(RV_PermaLink.Text); }
        }

        /// <summary>
        /// Метод, срабатывающий при клике по авторским правам в подвале.
        /// </summary>
        private void L_LegalInfo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.EnableAutoUpdate && !BW_UpdChk.IsBusy)
            {
                if (UpdMan.CheckAppUpdate())
                {
                    InstallBinaryUpdate();
                }
            }
        }

        /// <summary>
        /// Метод, срабатывающий при клике по URL в поле кастомного описания.
        /// </summary>
        private void CDM_OpenLnk_Click(object sender, EventArgs e)
        {
            // Компилируем регулярное выражение...
            Regex urlRx = new Regex(Properties.Resources.AppURLRegex, RegexOptions.IgnoreCase);

            // Выполняем проверку поля кастомного описания данным регулярным выражением...
            MatchCollection MCol = urlRx.Matches(RV_CustDescr.Text);

            // Обрабатываем найденное...
            foreach (Match MRes in MCol)
            {
                // Проверим не ссылка ли на картинку в URL. Для картинок используем свой вьювер...
                if (Regex.IsMatch(MRes.Groups["url"].Value, Properties.Resources.AppImageRegex))
                {
                    // Откроем форму с вьювером...
                    WxManager.ShowEvidenceViewForm(MRes.Groups["url"].Value, Chk.SteamID64, Properties.Settings.Default.FrWnOverride);
                }
                else
                {
                    // Ссылка не является картинкой, поэтому попробуем открыть через ShellExecute...
                    try { CoreLib.OpenWebPage(MRes.Groups["url"].Value); } catch { MessageBox.Show(Properties.Resources.AppNoURLStr, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
        }

        /// <summary>
        /// Событие "закрытие формы".
        /// </summary>
        private void FrmMainW_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "Скопировать ссылку в буфер".
        /// </summary>
        private void LNK_CustClipB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RV_CustDescr.Text);
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии на кнопку проверки друзей данного пользователя.
        /// </summary>
        private void LNK_ValFriends_Click(object sender, EventArgs e)
        {
            WxManager.ShowFriendChkForm(Chk.SteamID64, Properties.Settings.Default.FrWnOverride);
        }

        /// <summary>
        /// Метод, срабатывающий при клике по SteamID профиля.
        /// </summary>
        private void RV_SteamID_Click(object sender, EventArgs e)
        {
            string Sid = Control.ModifierKeys != Keys.Shift ? (Properties.Settings.Default.UseSteamIDv3 ? Chk.SteamIDv3 : Chk.SteamID) : Chk.SteamID64;
            try { Clipboard.SetText(Sid); ShowNotification(String.Format(Properties.Resources.AppMsgSiDClipb, Sid), MessageBoxIcon.Information, ToolTipIcon.Info); } catch { }
        }

        /// <summary>
        /// Метод, срабатывающий нажатии кнопки добавления пользователя в Steam.
        /// </summary>
        private void RV_AddFriend_Click(object sender, EventArgs e)
        {
            try { CoreLib.OpenWebPage(String.Format(Properties.Resources.AppAddTemplate, Chk.SteamID64)); } catch { MessageBox.Show(Properties.Resources.AppURIStartFail, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки открытия инвентаря.
        /// </summary>
        private void RV_ViewBackPack_Click(object sender, EventArgs e)
        {
            // Выбираем сервис просмотра инвентаря...
            string InvViewer;
            switch (Properties.Settings.Default.InventoryViewer)
            {
                case 0: InvViewer = Properties.Resources.TemplateInvTF2b;
                    break;
                case 1: InvViewer = Properties.Resources.TemplateInvTF2Items;
                    break;
                case 2: InvViewer = Properties.Resources.TemplateInvTF2Outpost;
                    break;
                case 3: InvViewer = Properties.Resources.TemplateInvSteam;
                    break;
                default: InvViewer = Properties.Resources.TemplateInvTF2b;
                    break;
            }

            // Открываем в браузере по умолчанию...
            try { CoreLib.OpenWebPage(String.Format(InvViewer, Chk.SteamID64)); } catch { MessageBox.Show(Properties.Resources.AppStartFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "Настройки" значка в трее.
        /// </summary>
        private void CM_Settings_Click(object sender, EventArgs e)
        {
            WxManager.ShowOptionsForm();
        }

        /// <summary>
        /// Метод, срабатывающий при выборе пункта "Информация" значка в трее.
        /// </summary>
        private void CM_TokenInfo_Click(object sender, EventArgs e)
        {
            WxManager.ShowTokenForm();
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии кнопки "Сообщить о мошенничестве".
        /// </summary>
        private void RV_Report_Click(object sender, EventArgs e)
        {
            WxManager.ShowReportForm(Chk.SteamID);
        }
        #endregion
    }
}
