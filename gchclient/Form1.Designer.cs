namespace gchclient
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CM_About = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_TokenInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.L_T_Msg1 = new System.Windows.Forms.Label();
            this.L_T_Msg2 = new System.Windows.Forms.Label();
            this.L_T_Msg3 = new System.Windows.Forms.Label();
            this.InpStr = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.ResultView = new System.Windows.Forms.Panel();
            this.RV_Report = new System.Windows.Forms.Button();
            this.RV_ViewBackPack = new System.Windows.Forms.Button();
            this.RV_AddFriend = new System.Windows.Forms.Button();
            this.RV_CheckFriends = new System.Windows.Forms.Button();
            this.RV_SteamID = new System.Windows.Forms.Label();
            this.RV_TradeStatus = new System.Windows.Forms.Label();
            this.RV_F2P = new System.Windows.Forms.Label();
            this.RV_VCStatusA = new System.Windows.Forms.Label();
            this.RV_CustDescr = new System.Windows.Forms.Label();
            this.CustMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LNK_CustClipB = new System.Windows.Forms.ToolStripMenuItem();
            this.RV_PermaLink = new System.Windows.Forms.Label();
            this.LnkMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LNK_Go = new System.Windows.Forms.ToolStripMenuItem();
            this.LNK_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.LNK_ValFriends = new System.Windows.Forms.ToolStripMenuItem();
            this.L_PLink = new System.Windows.Forms.Label();
            this.RV_AdvStatus = new System.Windows.Forms.Label();
            this.RV_SiteStatus = new System.Windows.Forms.Label();
            this.RV_Nick = new System.Windows.Forms.Label();
            this.RV_Avatar = new System.Windows.Forms.PictureBox();
            this.RV_AvatarHolder = new System.Windows.Forms.PictureBox();
            this.L_LegalInfo = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ToolTipCtr = new System.Windows.Forms.ToolTip(this.components);
            this.BW_Chk = new System.ComponentModel.BackgroundWorker();
            this.BW_UpdChk = new System.ComponentModel.BackgroundWorker();
            this.BW_HwGet = new System.ComponentModel.BackgroundWorker();
            this.TrayMenu.SuspendLayout();
            this.ResultView.SuspendLayout();
            this.CustMenu.SuspendLayout();
            this.LnkMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RV_Avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RV_AvatarHolder)).BeginInit();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Служба проверки пользователей";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CM_About,
            this.CM_TokenInfo,
            this.CM_Settings,
            this.CM_Quit});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(150, 92);
            // 
            // CM_About
            // 
            this.CM_About.Name = "CM_About";
            this.CM_About.Size = new System.Drawing.Size(149, 22);
            this.CM_About.Text = "О программе";
            this.CM_About.Click += new System.EventHandler(this.CM_About_Click);
            // 
            // CM_TokenInfo
            // 
            this.CM_TokenInfo.Name = "CM_TokenInfo";
            this.CM_TokenInfo.Size = new System.Drawing.Size(149, 22);
            this.CM_TokenInfo.Text = "Информация";
            this.CM_TokenInfo.Click += new System.EventHandler(this.CM_TokenInfo_Click);
            // 
            // CM_Settings
            // 
            this.CM_Settings.Name = "CM_Settings";
            this.CM_Settings.Size = new System.Drawing.Size(149, 22);
            this.CM_Settings.Text = "Настройки";
            this.CM_Settings.Click += new System.EventHandler(this.CM_Settings_Click);
            // 
            // CM_Quit
            // 
            this.CM_Quit.Name = "CM_Quit";
            this.CM_Quit.Size = new System.Drawing.Size(149, 22);
            this.CM_Quit.Text = "Выход";
            this.CM_Quit.Click += new System.EventHandler(this.CM_Quit_Click);
            // 
            // L_T_Msg1
            // 
            this.L_T_Msg1.AutoSize = true;
            this.L_T_Msg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_T_Msg1.Location = new System.Drawing.Point(159, 9);
            this.L_T_Msg1.Name = "L_T_Msg1";
            this.L_T_Msg1.Size = new System.Drawing.Size(448, 42);
            this.L_T_Msg1.TabIndex = 0;
            this.L_T_Msg1.Text = "Проверь на надёжность!";
            // 
            // L_T_Msg2
            // 
            this.L_T_Msg2.AutoSize = true;
            this.L_T_Msg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_T_Msg2.Location = new System.Drawing.Point(75, 51);
            this.L_T_Msg2.Name = "L_T_Msg2";
            this.L_T_Msg2.Size = new System.Drawing.Size(604, 20);
            this.L_T_Msg2.TabIndex = 1;
            this.L_T_Msg2.Text = "Введите ниже ссылку на профиль в сообществе Steam нужного вам человека";
            // 
            // L_T_Msg3
            // 
            this.L_T_Msg3.AutoSize = true;
            this.L_T_Msg3.Location = new System.Drawing.Point(256, 76);
            this.L_T_Msg3.Name = "L_T_Msg3";
            this.L_T_Msg3.Size = new System.Drawing.Size(244, 13);
            this.L_T_Msg3.TabIndex = 2;
            this.L_T_Msg3.Text = "Например, http://steamcommunity.com/id/GrinJ/";
            // 
            // InpStr
            // 
            this.InpStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InpStr.Location = new System.Drawing.Point(79, 111);
            this.InpStr.Name = "InpStr";
            this.InpStr.Size = new System.Drawing.Size(528, 38);
            this.InpStr.TabIndex = 3;
            this.ToolTipCtr.SetToolTip(this.InpStr, "Введите ссылку на профиль, SteamID или CustomID в это поле");
            this.InpStr.DoubleClick += new System.EventHandler(this.InpStr_DoubleClick);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Image = global::gchclient.Properties.Resources.search;
            this.SearchBtn.Location = new System.Drawing.Point(621, 111);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(42, 38);
            this.SearchBtn.TabIndex = 4;
            this.ToolTipCtr.SetToolTip(this.SearchBtn, "Запустить проверку по базе T-F.RU");
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // ResultView
            // 
            this.ResultView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultView.Controls.Add(this.RV_Report);
            this.ResultView.Controls.Add(this.RV_ViewBackPack);
            this.ResultView.Controls.Add(this.RV_AddFriend);
            this.ResultView.Controls.Add(this.RV_CheckFriends);
            this.ResultView.Controls.Add(this.RV_SteamID);
            this.ResultView.Controls.Add(this.RV_TradeStatus);
            this.ResultView.Controls.Add(this.RV_F2P);
            this.ResultView.Controls.Add(this.RV_VCStatusA);
            this.ResultView.Controls.Add(this.RV_CustDescr);
            this.ResultView.Controls.Add(this.RV_PermaLink);
            this.ResultView.Controls.Add(this.L_PLink);
            this.ResultView.Controls.Add(this.RV_AdvStatus);
            this.ResultView.Controls.Add(this.RV_SiteStatus);
            this.ResultView.Controls.Add(this.RV_Nick);
            this.ResultView.Controls.Add(this.RV_Avatar);
            this.ResultView.Controls.Add(this.RV_AvatarHolder);
            this.ResultView.Location = new System.Drawing.Point(25, 168);
            this.ResultView.Name = "ResultView";
            this.ResultView.Size = new System.Drawing.Size(702, 320);
            this.ResultView.TabIndex = 5;
            this.ResultView.Visible = false;
            // 
            // RV_Report
            // 
            this.RV_Report.Image = global::gchclient.Properties.Resources.iconReport;
            this.RV_Report.Location = new System.Drawing.Point(625, 21);
            this.RV_Report.Name = "RV_Report";
            this.RV_Report.Size = new System.Drawing.Size(29, 24);
            this.RV_Report.TabIndex = 4;
            this.RV_Report.TabStop = false;
            this.ToolTipCtr.SetToolTip(this.RV_Report, "Отправить жалобу");
            this.RV_Report.UseVisualStyleBackColor = true;
            this.RV_Report.Click += new System.EventHandler(this.RV_Report_Click);
            // 
            // RV_ViewBackPack
            // 
            this.RV_ViewBackPack.Image = global::gchclient.Properties.Resources.iconInventory;
            this.RV_ViewBackPack.Location = new System.Drawing.Point(654, 21);
            this.RV_ViewBackPack.Name = "RV_ViewBackPack";
            this.RV_ViewBackPack.Size = new System.Drawing.Size(29, 24);
            this.RV_ViewBackPack.TabIndex = 5;
            this.RV_ViewBackPack.TabStop = false;
            this.ToolTipCtr.SetToolTip(this.RV_ViewBackPack, "Показать рюкзак TF2");
            this.RV_ViewBackPack.UseVisualStyleBackColor = true;
            this.RV_ViewBackPack.Click += new System.EventHandler(this.RV_ViewBackPack_Click);
            // 
            // RV_AddFriend
            // 
            this.RV_AddFriend.Image = global::gchclient.Properties.Resources.iconAddFriend;
            this.RV_AddFriend.Location = new System.Drawing.Point(595, 21);
            this.RV_AddFriend.Name = "RV_AddFriend";
            this.RV_AddFriend.Size = new System.Drawing.Size(29, 24);
            this.RV_AddFriend.TabIndex = 3;
            this.RV_AddFriend.TabStop = false;
            this.ToolTipCtr.SetToolTip(this.RV_AddFriend, "Добавить в друзья");
            this.RV_AddFriend.UseVisualStyleBackColor = true;
            this.RV_AddFriend.Click += new System.EventHandler(this.RV_AddFriend_Click);
            // 
            // RV_CheckFriends
            // 
            this.RV_CheckFriends.Image = global::gchclient.Properties.Resources.srchfr;
            this.RV_CheckFriends.Location = new System.Drawing.Point(565, 21);
            this.RV_CheckFriends.Name = "RV_CheckFriends";
            this.RV_CheckFriends.Size = new System.Drawing.Size(29, 24);
            this.RV_CheckFriends.TabIndex = 2;
            this.RV_CheckFriends.TabStop = false;
            this.ToolTipCtr.SetToolTip(this.RV_CheckFriends, "Проверить друзей пользователя");
            this.RV_CheckFriends.UseVisualStyleBackColor = true;
            this.RV_CheckFriends.Click += new System.EventHandler(this.LNK_ValFriends_Click);
            // 
            // RV_SteamID
            // 
            this.RV_SteamID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RV_SteamID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_SteamID.Location = new System.Drawing.Point(18, 214);
            this.RV_SteamID.Name = "RV_SteamID";
            this.RV_SteamID.Size = new System.Drawing.Size(187, 23);
            this.RV_SteamID.TabIndex = 0;
            this.RV_SteamID.Text = "%STEAMID32%";
            this.RV_SteamID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipCtr.SetToolTip(this.RV_SteamID, "Нормализованное представление SteamID");
            this.RV_SteamID.Click += new System.EventHandler(this.RV_SteamID_Click);
            // 
            // RV_TradeStatus
            // 
            this.RV_TradeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_TradeStatus.Location = new System.Drawing.Point(223, 214);
            this.RV_TradeStatus.Name = "RV_TradeStatus";
            this.RV_TradeStatus.Size = new System.Drawing.Size(460, 23);
            this.RV_TradeStatus.TabIndex = 11;
            this.RV_TradeStatus.Text = "%СТАТУС ТОРГОВЛИ%";
            this.ToolTipCtr.SetToolTip(this.RV_TradeStatus, "Статус торговли");
            // 
            // RV_F2P
            // 
            this.RV_F2P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_F2P.Location = new System.Drawing.Point(448, 181);
            this.RV_F2P.Name = "RV_F2P";
            this.RV_F2P.Size = new System.Drawing.Size(235, 23);
            this.RV_F2P.TabIndex = 10;
            this.RV_F2P.Text = "%ФРИТУПЛЕЙ АКК%";
            // 
            // RV_VCStatusA
            // 
            this.RV_VCStatusA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_VCStatusA.Location = new System.Drawing.Point(223, 182);
            this.RV_VCStatusA.Name = "RV_VCStatusA";
            this.RV_VCStatusA.Size = new System.Drawing.Size(218, 23);
            this.RV_VCStatusA.TabIndex = 9;
            this.RV_VCStatusA.Text = "%СТАТУС ВАК%";
            this.ToolTipCtr.SetToolTip(this.RV_VCStatusA, "Статус VAC");
            // 
            // RV_CustDescr
            // 
            this.RV_CustDescr.ContextMenuStrip = this.CustMenu;
            this.RV_CustDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_CustDescr.Location = new System.Drawing.Point(224, 123);
            this.RV_CustDescr.Name = "RV_CustDescr";
            this.RV_CustDescr.Size = new System.Drawing.Size(459, 55);
            this.RV_CustDescr.TabIndex = 8;
            this.RV_CustDescr.Text = "%КАСТОМНОЕ ОПИСАНИЕ, СТАТУС VAC И ПРОЧЕЕ%";
            this.RV_CustDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTipCtr.SetToolTip(this.RV_CustDescr, "Кастомное описание пользователя");
            this.RV_CustDescr.Click += new System.EventHandler(this.RV_CustDescr_Click);
            // 
            // CustMenu
            // 
            this.CustMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LNK_CustClipB});
            this.CustMenu.Name = "CustMenu";
            this.CustMenu.Size = new System.Drawing.Size(236, 26);
            // 
            // LNK_CustClipB
            // 
            this.LNK_CustClipB.Name = "LNK_CustClipB";
            this.LNK_CustClipB.Size = new System.Drawing.Size(235, 22);
            this.LNK_CustClipB.Text = "Скопировать в буфер обмена";
            this.LNK_CustClipB.Click += new System.EventHandler(this.LNK_CustClipB_Click);
            // 
            // RV_PermaLink
            // 
            this.RV_PermaLink.AutoSize = true;
            this.RV_PermaLink.ContextMenuStrip = this.LnkMenu;
            this.RV_PermaLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RV_PermaLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_PermaLink.ForeColor = System.Drawing.Color.Blue;
            this.RV_PermaLink.Location = new System.Drawing.Point(224, 278);
            this.RV_PermaLink.Name = "RV_PermaLink";
            this.RV_PermaLink.Size = new System.Drawing.Size(180, 16);
            this.RV_PermaLink.TabIndex = 13;
            this.RV_PermaLink.Text = "%ССЫЛКА НА ПРОФИЛЬ%";
            this.ToolTipCtr.SetToolTip(this.RV_PermaLink, "Постоянная ссылка на профиль (щёлкните для перехода)");
            this.RV_PermaLink.Click += new System.EventHandler(this.RV_PermaLink_Click);
            // 
            // LnkMenu
            // 
            this.LnkMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LNK_Go,
            this.LNK_Copy,
            this.LNK_ValFriends});
            this.LnkMenu.Name = "LnkMenu";
            this.LnkMenu.Size = new System.Drawing.Size(269, 70);
            // 
            // LNK_Go
            // 
            this.LNK_Go.Name = "LNK_Go";
            this.LNK_Go.Size = new System.Drawing.Size(268, 22);
            this.LNK_Go.Text = "Перейти по ссылке";
            this.LNK_Go.Click += new System.EventHandler(this.LNK_Go_Click);
            // 
            // LNK_Copy
            // 
            this.LNK_Copy.Name = "LNK_Copy";
            this.LNK_Copy.Size = new System.Drawing.Size(268, 22);
            this.LNK_Copy.Text = "Копировать ссылку в буфер обмена";
            this.LNK_Copy.Click += new System.EventHandler(this.LNK_Copy_Click);
            // 
            // LNK_ValFriends
            // 
            this.LNK_ValFriends.Name = "LNK_ValFriends";
            this.LNK_ValFriends.Size = new System.Drawing.Size(268, 22);
            this.LNK_ValFriends.Text = "Проверить друзей пользователя";
            this.LNK_ValFriends.Click += new System.EventHandler(this.LNK_ValFriends_Click);
            // 
            // L_PLink
            // 
            this.L_PLink.AutoSize = true;
            this.L_PLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_PLink.Location = new System.Drawing.Point(223, 250);
            this.L_PLink.Name = "L_PLink";
            this.L_PLink.Size = new System.Drawing.Size(299, 24);
            this.L_PLink.TabIndex = 12;
            this.L_PLink.Text = "Постоянная ссылка на профиль:";
            // 
            // RV_AdvStatus
            // 
            this.RV_AdvStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RV_AdvStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_AdvStatus.Location = new System.Drawing.Point(223, 83);
            this.RV_AdvStatus.Name = "RV_AdvStatus";
            this.RV_AdvStatus.Size = new System.Drawing.Size(460, 40);
            this.RV_AdvStatus.TabIndex = 7;
            this.RV_AdvStatus.Text = "%ИНФОРМАЦИЯ О ПРИСУТСТВИИ В ЧЁРНОМ ИЛИ БЕЛОМ СПИСКАХ САЙТА%";
            this.ToolTipCtr.SetToolTip(this.RV_AdvStatus, "Дополнительная информация");
            this.RV_AdvStatus.Click += new System.EventHandler(this.RV_AdvStatus_Click);
            // 
            // RV_SiteStatus
            // 
            this.RV_SiteStatus.AutoSize = true;
            this.RV_SiteStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_SiteStatus.Location = new System.Drawing.Point(223, 54);
            this.RV_SiteStatus.Name = "RV_SiteStatus";
            this.RV_SiteStatus.Size = new System.Drawing.Size(325, 20);
            this.RV_SiteStatus.TabIndex = 6;
            this.RV_SiteStatus.Text = "%ИНФОРМАЦИЯ О СТАТУСЕ ГАРАНТА%";
            this.ToolTipCtr.SetToolTip(this.RV_SiteStatus, "Информация о статусе на сайте");
            // 
            // RV_Nick
            // 
            this.RV_Nick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RV_Nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RV_Nick.Location = new System.Drawing.Point(223, 21);
            this.RV_Nick.Name = "RV_Nick";
            this.RV_Nick.Size = new System.Drawing.Size(320, 24);
            this.RV_Nick.TabIndex = 1;
            this.RV_Nick.Text = "%Nickname%";
            this.ToolTipCtr.SetToolTip(this.RV_Nick, "Ник пользователя");
            this.RV_Nick.Click += new System.EventHandler(this.RV_Nick_Click);
            // 
            // RV_Avatar
            // 
            this.RV_Avatar.Location = new System.Drawing.Point(21, 21);
            this.RV_Avatar.Name = "RV_Avatar";
            this.RV_Avatar.Size = new System.Drawing.Size(184, 184);
            this.RV_Avatar.TabIndex = 0;
            this.RV_Avatar.TabStop = false;
            this.ToolTipCtr.SetToolTip(this.RV_Avatar, "Аватар пользователя");
            // 
            // RV_AvatarHolder
            // 
            this.RV_AvatarHolder.Image = global::gchclient.Properties.Resources.avatarholder;
            this.RV_AvatarHolder.Location = new System.Drawing.Point(17, 17);
            this.RV_AvatarHolder.Name = "RV_AvatarHolder";
            this.RV_AvatarHolder.Size = new System.Drawing.Size(192, 192);
            this.RV_AvatarHolder.TabIndex = 14;
            this.RV_AvatarHolder.TabStop = false;
            // 
            // L_LegalInfo
            // 
            this.L_LegalInfo.Location = new System.Drawing.Point(25, 501);
            this.L_LegalInfo.Name = "L_LegalInfo";
            this.L_LegalInfo.Size = new System.Drawing.Size(702, 17);
            this.L_LegalInfo.TabIndex = 6;
            this.L_LegalInfo.Text = "(c) 2005 - 2013 EasyCoding Team и TEAM-FORTRESS.SU. Все права защищены.";
            this.L_LegalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L_LegalInfo.Click += new System.EventHandler(this.L_LegalInfo_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 2000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BW_Chk
            // 
            this.BW_Chk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Chk_DoWork);
            this.BW_Chk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Chk_RunWorkerCompleted);
            // 
            // BW_UpdChk
            // 
            this.BW_UpdChk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_UpdChk_DoWork);
            // 
            // BW_HwGet
            // 
            this.BW_HwGet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_HwGet_DoWork);
            this.BW_HwGet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_HwGet_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AcceptButton = this.SearchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 531);
            this.Controls.Add(this.ResultView);
            this.Controls.Add(this.L_T_Msg2);
            this.Controls.Add(this.L_T_Msg3);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.InpStr);
            this.Controls.Add(this.L_T_Msg1);
            this.Controls.Add(this.L_LegalInfo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Служба проверки пользователей TEAM-FORTRESS.SU (версия {0})";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.TrayMenu.ResumeLayout(false);
            this.ResultView.ResumeLayout(false);
            this.ResultView.PerformLayout();
            this.CustMenu.ResumeLayout(false);
            this.LnkMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RV_Avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RV_AvatarHolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem CM_About;
        private System.Windows.Forms.ToolStripMenuItem CM_Quit;
        private System.Windows.Forms.Label L_T_Msg1;
        private System.Windows.Forms.Label L_T_Msg2;
        private System.Windows.Forms.Label L_T_Msg3;
        private System.Windows.Forms.TextBox InpStr;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Panel ResultView;
        private System.Windows.Forms.Label L_LegalInfo;
        private System.Windows.Forms.Label RV_SiteStatus;
        private System.Windows.Forms.Label RV_Nick;
        private System.Windows.Forms.PictureBox RV_Avatar;
        private System.Windows.Forms.Label RV_PermaLink;
        private System.Windows.Forms.Label L_PLink;
        private System.Windows.Forms.Label RV_AdvStatus;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label RV_CustDescr;
        private System.Windows.Forms.Label RV_VCStatusA;
        private System.Windows.Forms.Label RV_F2P;
        private System.Windows.Forms.ContextMenuStrip LnkMenu;
        private System.Windows.Forms.ToolStripMenuItem LNK_Go;
        private System.Windows.Forms.ToolStripMenuItem LNK_Copy;
        private System.Windows.Forms.Label RV_TradeStatus;
        private System.Windows.Forms.ToolStripMenuItem CM_Settings;
        private System.Windows.Forms.ContextMenuStrip CustMenu;
        private System.Windows.Forms.ToolStripMenuItem LNK_CustClipB;
        private System.Windows.Forms.ToolStripMenuItem LNK_ValFriends;
        private System.Windows.Forms.Label RV_SteamID;
        private System.Windows.Forms.Button RV_CheckFriends;
        private System.Windows.Forms.Button RV_AddFriend;
        private System.Windows.Forms.Button RV_ViewBackPack;
        private System.Windows.Forms.Button RV_Report;
        private System.Windows.Forms.PictureBox RV_AvatarHolder;
        private System.Windows.Forms.ToolTip ToolTipCtr;
        private System.Windows.Forms.ToolStripMenuItem CM_TokenInfo;
        private System.ComponentModel.BackgroundWorker BW_Chk;
        private System.ComponentModel.BackgroundWorker BW_UpdChk;
        private System.ComponentModel.BackgroundWorker BW_HwGet;
    }
}

