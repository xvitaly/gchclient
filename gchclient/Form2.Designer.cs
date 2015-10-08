namespace gchclient
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.SaveNClose = new System.Windows.Forms.Button();
            this.TC_Main = new System.Windows.Forms.TabControl();
            this.TC_TP_MainPage = new System.Windows.Forms.TabPage();
            this.GB_Hw = new System.Windows.Forms.GroupBox();
            this.HwIDFld = new System.Windows.Forms.Label();
            this.GB_GenSt = new System.Windows.Forms.GroupBox();
            this.Opt_Autorun = new System.Windows.Forms.CheckBox();
            this.GB_Tokens = new System.Windows.Forms.GroupBox();
            this.Opt_ProtocolType = new System.Windows.Forms.ComboBox();
            this.L_Opt_ProtocolType = new System.Windows.Forms.Label();
            this.InpSecToken = new System.Windows.Forms.TextBox();
            this.L_InpSecToken = new System.Windows.Forms.Label();
            this.InpPriToken = new System.Windows.Forms.TextBox();
            this.L_InpPriToken = new System.Windows.Forms.Label();
            this.TC_TP_AdvSettings = new System.Windows.Forms.TabPage();
            this.GB_Settings = new System.Windows.Forms.GroupBox();
            this.Opt_InvViewer = new System.Windows.Forms.ComboBox();
            this.L_InvViewer = new System.Windows.Forms.Label();
            this.Opt_ClipbInt = new System.Windows.Forms.CheckBox();
            this.Opt_Hotkey = new System.Windows.Forms.ComboBox();
            this.Opt_EnableHotKey = new System.Windows.Forms.CheckBox();
            this.Opt_UseNewSteamIDFormat = new System.Windows.Forms.CheckBox();
            this.Opt_AutoUpdate = new System.Windows.Forms.CheckBox();
            this.Opt_CpSidName = new System.Windows.Forms.CheckBox();
            this.Opt_FrWQbnts = new System.Windows.Forms.CheckBox();
            this.Opt_FrWHide = new System.Windows.Forms.CheckBox();
            this.Opt_FrWOverride = new System.Windows.Forms.CheckBox();
            this.TC_TP_IgnoreEd = new System.Windows.Forms.TabPage();
            this.Opt_IgnEd = new System.Windows.Forms.DataGridView();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opt_IgnEd_TB = new System.Windows.Forms.ToolStrip();
            this.Opt_IEd_Tb_AddRow = new System.Windows.Forms.ToolStripButton();
            this.Opt_IEd_Tb_DelRow = new System.Windows.Forms.ToolStripButton();
            this.Opt_IEd_Tb_Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.Opt_IEd_Tb_Cut = new System.Windows.Forms.ToolStripButton();
            this.Opt_IEd_Tb_Copy = new System.Windows.Forms.ToolStripButton();
            this.Opt_IEd_Tb_Paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TC_Main.SuspendLayout();
            this.TC_TP_MainPage.SuspendLayout();
            this.GB_Hw.SuspendLayout();
            this.GB_GenSt.SuspendLayout();
            this.GB_Tokens.SuspendLayout();
            this.TC_TP_AdvSettings.SuspendLayout();
            this.GB_Settings.SuspendLayout();
            this.TC_TP_IgnoreEd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opt_IgnEd)).BeginInit();
            this.Opt_IgnEd_TB.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveNClose
            // 
            this.SaveNClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SaveNClose.Location = new System.Drawing.Point(73, 298);
            this.SaveNClose.Name = "SaveNClose";
            this.SaveNClose.Size = new System.Drawing.Size(192, 23);
            this.SaveNClose.TabIndex = 1;
            this.SaveNClose.Text = "Сохранить настройки";
            this.SaveNClose.UseVisualStyleBackColor = true;
            this.SaveNClose.Click += new System.EventHandler(this.SaveNClose_Click);
            // 
            // TC_Main
            // 
            this.TC_Main.Controls.Add(this.TC_TP_MainPage);
            this.TC_Main.Controls.Add(this.TC_TP_AdvSettings);
            this.TC_Main.Controls.Add(this.TC_TP_IgnoreEd);
            this.TC_Main.Location = new System.Drawing.Point(12, 12);
            this.TC_Main.Name = "TC_Main";
            this.TC_Main.SelectedIndex = 0;
            this.TC_Main.Size = new System.Drawing.Size(319, 281);
            this.TC_Main.TabIndex = 0;
            // 
            // TC_TP_MainPage
            // 
            this.TC_TP_MainPage.Controls.Add(this.GB_Hw);
            this.TC_TP_MainPage.Controls.Add(this.GB_GenSt);
            this.TC_TP_MainPage.Controls.Add(this.GB_Tokens);
            this.TC_TP_MainPage.Location = new System.Drawing.Point(4, 22);
            this.TC_TP_MainPage.Name = "TC_TP_MainPage";
            this.TC_TP_MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.TC_TP_MainPage.Size = new System.Drawing.Size(311, 255);
            this.TC_TP_MainPage.TabIndex = 0;
            this.TC_TP_MainPage.Text = "Основные";
            this.TC_TP_MainPage.UseVisualStyleBackColor = true;
            // 
            // GB_Hw
            // 
            this.GB_Hw.Controls.Add(this.HwIDFld);
            this.GB_Hw.Location = new System.Drawing.Point(6, 155);
            this.GB_Hw.Name = "GB_Hw";
            this.GB_Hw.Size = new System.Drawing.Size(294, 38);
            this.GB_Hw.TabIndex = 1;
            this.GB_Hw.TabStop = false;
            this.GB_Hw.Text = "Аппаратно-зависимый ключ";
            // 
            // HwIDFld
            // 
            this.HwIDFld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HwIDFld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HwIDFld.Location = new System.Drawing.Point(22, 16);
            this.HwIDFld.Name = "HwIDFld";
            this.HwIDFld.Size = new System.Drawing.Size(250, 15);
            this.HwIDFld.TabIndex = 0;
            this.HwIDFld.Text = "HWID";
            this.HwIDFld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HwIDFld.Click += new System.EventHandler(this.HwIDFld_Click);
            // 
            // GB_GenSt
            // 
            this.GB_GenSt.Controls.Add(this.Opt_Autorun);
            this.GB_GenSt.Location = new System.Drawing.Point(6, 199);
            this.GB_GenSt.Name = "GB_GenSt";
            this.GB_GenSt.Size = new System.Drawing.Size(294, 46);
            this.GB_GenSt.TabIndex = 2;
            this.GB_GenSt.TabStop = false;
            this.GB_GenSt.Text = "Настройки автоматического запуска";
            // 
            // Opt_Autorun
            // 
            this.Opt_Autorun.AutoSize = true;
            this.Opt_Autorun.Location = new System.Drawing.Point(20, 20);
            this.Opt_Autorun.Name = "Opt_Autorun";
            this.Opt_Autorun.Size = new System.Drawing.Size(215, 17);
            this.Opt_Autorun.TabIndex = 0;
            this.Opt_Autorun.Text = "Разрешить автозагрузку программы";
            this.Opt_Autorun.UseVisualStyleBackColor = true;
            // 
            // GB_Tokens
            // 
            this.GB_Tokens.Controls.Add(this.Opt_ProtocolType);
            this.GB_Tokens.Controls.Add(this.L_Opt_ProtocolType);
            this.GB_Tokens.Controls.Add(this.InpSecToken);
            this.GB_Tokens.Controls.Add(this.L_InpSecToken);
            this.GB_Tokens.Controls.Add(this.InpPriToken);
            this.GB_Tokens.Controls.Add(this.L_InpPriToken);
            this.GB_Tokens.Location = new System.Drawing.Point(6, 6);
            this.GB_Tokens.Name = "GB_Tokens";
            this.GB_Tokens.Size = new System.Drawing.Size(294, 143);
            this.GB_Tokens.TabIndex = 0;
            this.GB_Tokens.TabStop = false;
            this.GB_Tokens.Text = "Настройки авторизации";
            // 
            // Opt_ProtocolType
            // 
            this.Opt_ProtocolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Opt_ProtocolType.FormattingEnabled = true;
            this.Opt_ProtocolType.Items.AddRange(new object[] {
            "Безопасный (SSL+TLS)",
            "Без шифрования"});
            this.Opt_ProtocolType.Location = new System.Drawing.Point(126, 108);
            this.Opt_ProtocolType.Name = "Opt_ProtocolType";
            this.Opt_ProtocolType.Size = new System.Drawing.Size(144, 21);
            this.Opt_ProtocolType.TabIndex = 5;
            // 
            // L_Opt_ProtocolType
            // 
            this.L_Opt_ProtocolType.AutoSize = true;
            this.L_Opt_ProtocolType.Location = new System.Drawing.Point(17, 111);
            this.L_Opt_ProtocolType.Name = "L_Opt_ProtocolType";
            this.L_Opt_ProtocolType.Size = new System.Drawing.Size(103, 13);
            this.L_Opt_ProtocolType.TabIndex = 4;
            this.L_Opt_ProtocolType.Text = "Протокол клиента:";
            // 
            // InpSecToken
            // 
            this.InpSecToken.Location = new System.Drawing.Point(20, 77);
            this.InpSecToken.MaxLength = 35;
            this.InpSecToken.Name = "InpSecToken";
            this.InpSecToken.Size = new System.Drawing.Size(250, 20);
            this.InpSecToken.TabIndex = 3;
            // 
            // L_InpSecToken
            // 
            this.L_InpSecToken.AutoSize = true;
            this.L_InpSecToken.Location = new System.Drawing.Point(17, 61);
            this.L_InpSecToken.Name = "L_InpSecToken";
            this.L_InpSecToken.Size = new System.Drawing.Size(131, 13);
            this.L_InpSecToken.TabIndex = 2;
            this.L_InpSecToken.Text = "Вторичный ключ токена:";
            // 
            // InpPriToken
            // 
            this.InpPriToken.Location = new System.Drawing.Point(20, 35);
            this.InpPriToken.MaxLength = 35;
            this.InpPriToken.Name = "InpPriToken";
            this.InpPriToken.Size = new System.Drawing.Size(250, 20);
            this.InpPriToken.TabIndex = 1;
            // 
            // L_InpPriToken
            // 
            this.L_InpPriToken.AutoSize = true;
            this.L_InpPriToken.Location = new System.Drawing.Point(17, 19);
            this.L_InpPriToken.Name = "L_InpPriToken";
            this.L_InpPriToken.Size = new System.Drawing.Size(133, 13);
            this.L_InpPriToken.TabIndex = 0;
            this.L_InpPriToken.Text = "Первичный ключ токена:";
            // 
            // TC_TP_AdvSettings
            // 
            this.TC_TP_AdvSettings.Controls.Add(this.GB_Settings);
            this.TC_TP_AdvSettings.Location = new System.Drawing.Point(4, 22);
            this.TC_TP_AdvSettings.Name = "TC_TP_AdvSettings";
            this.TC_TP_AdvSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TC_TP_AdvSettings.Size = new System.Drawing.Size(311, 255);
            this.TC_TP_AdvSettings.TabIndex = 1;
            this.TC_TP_AdvSettings.Text = "Расширенные";
            this.TC_TP_AdvSettings.UseVisualStyleBackColor = true;
            // 
            // GB_Settings
            // 
            this.GB_Settings.Controls.Add(this.Opt_InvViewer);
            this.GB_Settings.Controls.Add(this.L_InvViewer);
            this.GB_Settings.Controls.Add(this.Opt_ClipbInt);
            this.GB_Settings.Controls.Add(this.Opt_Hotkey);
            this.GB_Settings.Controls.Add(this.Opt_EnableHotKey);
            this.GB_Settings.Controls.Add(this.Opt_UseNewSteamIDFormat);
            this.GB_Settings.Controls.Add(this.Opt_AutoUpdate);
            this.GB_Settings.Controls.Add(this.Opt_CpSidName);
            this.GB_Settings.Controls.Add(this.Opt_FrWQbnts);
            this.GB_Settings.Controls.Add(this.Opt_FrWHide);
            this.GB_Settings.Controls.Add(this.Opt_FrWOverride);
            this.GB_Settings.Location = new System.Drawing.Point(6, 6);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Size = new System.Drawing.Size(294, 243);
            this.GB_Settings.TabIndex = 0;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Общие настройки программы";
            // 
            // Opt_InvViewer
            // 
            this.Opt_InvViewer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Opt_InvViewer.FormattingEnabled = true;
            this.Opt_InvViewer.Items.AddRange(new object[] {
            "TF2b.com",
            "TF2Items.com",
            "TF2 Outpost"});
            this.Opt_InvViewer.Location = new System.Drawing.Point(132, 208);
            this.Opt_InvViewer.Name = "Opt_InvViewer";
            this.Opt_InvViewer.Size = new System.Drawing.Size(145, 21);
            this.Opt_InvViewer.TabIndex = 10;
            // 
            // L_InvViewer
            // 
            this.L_InvViewer.Location = new System.Drawing.Point(12, 211);
            this.L_InvViewer.Name = "L_InvViewer";
            this.L_InvViewer.Size = new System.Drawing.Size(121, 18);
            this.L_InvViewer.TabIndex = 9;
            this.L_InvViewer.Text = "Просмотр инвентаря:";
            // 
            // Opt_ClipbInt
            // 
            this.Opt_ClipbInt.AutoSize = true;
            this.Opt_ClipbInt.Location = new System.Drawing.Point(15, 183);
            this.Opt_ClipbInt.Name = "Opt_ClipbInt";
            this.Opt_ClipbInt.Size = new System.Drawing.Size(246, 17);
            this.Opt_ClipbInt.TabIndex = 8;
            this.Opt_ClipbInt.Text = "Включить проверку URL из буфера обмена";
            this.Opt_ClipbInt.UseVisualStyleBackColor = true;
            // 
            // Opt_Hotkey
            // 
            this.Opt_Hotkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Opt_Hotkey.Enabled = false;
            this.Opt_Hotkey.FormattingEnabled = true;
            this.Opt_Hotkey.Items.AddRange(new object[] {
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.Opt_Hotkey.Location = new System.Drawing.Point(192, 89);
            this.Opt_Hotkey.Name = "Opt_Hotkey";
            this.Opt_Hotkey.Size = new System.Drawing.Size(85, 21);
            this.Opt_Hotkey.TabIndex = 4;
            // 
            // Opt_EnableHotKey
            // 
            this.Opt_EnableHotKey.Location = new System.Drawing.Point(15, 91);
            this.Opt_EnableHotKey.Name = "Opt_EnableHotKey";
            this.Opt_EnableHotKey.Size = new System.Drawing.Size(176, 17);
            this.Opt_EnableHotKey.TabIndex = 3;
            this.Opt_EnableHotKey.Text = "Включить \"горячую\" клавишу F11";
            this.Opt_EnableHotKey.UseVisualStyleBackColor = true;
            this.Opt_EnableHotKey.CheckedChanged += new System.EventHandler(this.Opt_EnableHotKey_CheckedChanged);
            // 
            // Opt_UseNewSteamIDFormat
            // 
            this.Opt_UseNewSteamIDFormat.AutoSize = true;
            this.Opt_UseNewSteamIDFormat.Location = new System.Drawing.Point(15, 160);
            this.Opt_UseNewSteamIDFormat.Name = "Opt_UseNewSteamIDFormat";
            this.Opt_UseNewSteamIDFormat.Size = new System.Drawing.Size(212, 17);
            this.Opt_UseNewSteamIDFormat.TabIndex = 7;
            this.Opt_UseNewSteamIDFormat.Text = "Выводить SteamID в новом формате";
            this.Opt_UseNewSteamIDFormat.UseVisualStyleBackColor = true;
            // 
            // Opt_AutoUpdate
            // 
            this.Opt_AutoUpdate.AutoSize = true;
            this.Opt_AutoUpdate.Location = new System.Drawing.Point(15, 137);
            this.Opt_AutoUpdate.Name = "Opt_AutoUpdate";
            this.Opt_AutoUpdate.Size = new System.Drawing.Size(224, 17);
            this.Opt_AutoUpdate.TabIndex = 6;
            this.Opt_AutoUpdate.Text = "Включить автоматическое обновление";
            this.Opt_AutoUpdate.UseVisualStyleBackColor = true;
            // 
            // Opt_CpSidName
            // 
            this.Opt_CpSidName.AutoSize = true;
            this.Opt_CpSidName.Location = new System.Drawing.Point(15, 114);
            this.Opt_CpSidName.Name = "Opt_CpSidName";
            this.Opt_CpSidName.Size = new System.Drawing.Size(223, 17);
            this.Opt_CpSidName.TabIndex = 5;
            this.Opt_CpSidName.Text = "Копировать SteamID вместо никнейма";
            this.Opt_CpSidName.UseVisualStyleBackColor = true;
            // 
            // Opt_FrWQbnts
            // 
            this.Opt_FrWQbnts.AutoSize = true;
            this.Opt_FrWQbnts.Location = new System.Drawing.Point(15, 68);
            this.Opt_FrWQbnts.Name = "Opt_FrWQbnts";
            this.Opt_FrWQbnts.Size = new System.Drawing.Size(176, 17);
            this.Opt_FrWQbnts.TabIndex = 2;
            this.Opt_FrWQbnts.Text = "Показывать быстрые кнопки";
            this.Opt_FrWQbnts.UseVisualStyleBackColor = true;
            // 
            // Opt_FrWHide
            // 
            this.Opt_FrWHide.AutoSize = true;
            this.Opt_FrWHide.Location = new System.Drawing.Point(15, 45);
            this.Opt_FrWHide.Name = "Opt_FrWHide";
            this.Opt_FrWHide.Size = new System.Drawing.Size(232, 17);
            this.Opt_FrWHide.TabIndex = 1;
            this.Opt_FrWHide.Text = "Автоматически закрывать чекер друзей";
            this.Opt_FrWHide.UseVisualStyleBackColor = true;
            // 
            // Opt_FrWOverride
            // 
            this.Opt_FrWOverride.AutoSize = true;
            this.Opt_FrWOverride.Location = new System.Drawing.Point(15, 22);
            this.Opt_FrWOverride.Name = "Opt_FrWOverride";
            this.Opt_FrWOverride.Size = new System.Drawing.Size(250, 17);
            this.Opt_FrWOverride.TabIndex = 0;
            this.Opt_FrWOverride.Text = "Перекрывать главное окно чекером друзей";
            this.Opt_FrWOverride.UseVisualStyleBackColor = true;
            // 
            // TC_TP_IgnoreEd
            // 
            this.TC_TP_IgnoreEd.Controls.Add(this.Opt_IgnEd);
            this.TC_TP_IgnoreEd.Controls.Add(this.Opt_IgnEd_TB);
            this.TC_TP_IgnoreEd.Location = new System.Drawing.Point(4, 22);
            this.TC_TP_IgnoreEd.Name = "TC_TP_IgnoreEd";
            this.TC_TP_IgnoreEd.Padding = new System.Windows.Forms.Padding(3);
            this.TC_TP_IgnoreEd.Size = new System.Drawing.Size(311, 255);
            this.TC_TP_IgnoreEd.TabIndex = 2;
            this.TC_TP_IgnoreEd.Text = "Игнорирование";
            this.TC_TP_IgnoreEd.UseVisualStyleBackColor = true;
            // 
            // Opt_IgnEd
            // 
            this.Opt_IgnEd.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Opt_IgnEd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Opt_IgnEd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Opt_IgnEd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URL});
            this.Opt_IgnEd.Location = new System.Drawing.Point(-4, 29);
            this.Opt_IgnEd.MultiSelect = false;
            this.Opt_IgnEd.Name = "Opt_IgnEd";
            this.Opt_IgnEd.Size = new System.Drawing.Size(317, 202);
            this.Opt_IgnEd.TabIndex = 1;
            // 
            // URL
            // 
            this.URL.HeaderText = "Игнорируемая ссылка";
            this.URL.Name = "URL";
            this.URL.Width = 250;
            // 
            // Opt_IgnEd_TB
            // 
            this.Opt_IgnEd_TB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opt_IEd_Tb_AddRow,
            this.Opt_IEd_Tb_DelRow,
            this.Opt_IEd_Tb_Clear,
            this.toolStripSeparator,
            this.Opt_IEd_Tb_Cut,
            this.Opt_IEd_Tb_Copy,
            this.Opt_IEd_Tb_Paste,
            this.toolStripSeparator1});
            this.Opt_IgnEd_TB.Location = new System.Drawing.Point(3, 3);
            this.Opt_IgnEd_TB.Name = "Opt_IgnEd_TB";
            this.Opt_IgnEd_TB.Size = new System.Drawing.Size(305, 25);
            this.Opt_IgnEd_TB.TabIndex = 0;
            // 
            // Opt_IEd_Tb_AddRow
            // 
            this.Opt_IEd_Tb_AddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Opt_IEd_Tb_AddRow.Image = ((System.Drawing.Image)(resources.GetObject("Opt_IEd_Tb_AddRow.Image")));
            this.Opt_IEd_Tb_AddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Opt_IEd_Tb_AddRow.Name = "Opt_IEd_Tb_AddRow";
            this.Opt_IEd_Tb_AddRow.Size = new System.Drawing.Size(23, 22);
            this.Opt_IEd_Tb_AddRow.Text = "Добавить строку";
            this.Opt_IEd_Tb_AddRow.Click += new System.EventHandler(this.Opt_IEd_Tb_AddRow_Click);
            // 
            // Opt_IEd_Tb_DelRow
            // 
            this.Opt_IEd_Tb_DelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Opt_IEd_Tb_DelRow.Image = ((System.Drawing.Image)(resources.GetObject("Opt_IEd_Tb_DelRow.Image")));
            this.Opt_IEd_Tb_DelRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Opt_IEd_Tb_DelRow.Name = "Opt_IEd_Tb_DelRow";
            this.Opt_IEd_Tb_DelRow.Size = new System.Drawing.Size(23, 22);
            this.Opt_IEd_Tb_DelRow.Text = "Удалить выделенную строку";
            this.Opt_IEd_Tb_DelRow.Click += new System.EventHandler(this.Opt_IEd_Tb_DelRow_Click);
            // 
            // Opt_IEd_Tb_Clear
            // 
            this.Opt_IEd_Tb_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Opt_IEd_Tb_Clear.Image = ((System.Drawing.Image)(resources.GetObject("Opt_IEd_Tb_Clear.Image")));
            this.Opt_IEd_Tb_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Opt_IEd_Tb_Clear.Name = "Opt_IEd_Tb_Clear";
            this.Opt_IEd_Tb_Clear.Size = new System.Drawing.Size(23, 22);
            this.Opt_IEd_Tb_Clear.Text = "Очистить редактор";
            this.Opt_IEd_Tb_Clear.Click += new System.EventHandler(this.Opt_IEd_Tb_Clear_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // Opt_IEd_Tb_Cut
            // 
            this.Opt_IEd_Tb_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Opt_IEd_Tb_Cut.Image = ((System.Drawing.Image)(resources.GetObject("Opt_IEd_Tb_Cut.Image")));
            this.Opt_IEd_Tb_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Opt_IEd_Tb_Cut.Name = "Opt_IEd_Tb_Cut";
            this.Opt_IEd_Tb_Cut.Size = new System.Drawing.Size(23, 22);
            this.Opt_IEd_Tb_Cut.Text = "Вырезать";
            this.Opt_IEd_Tb_Cut.Click += new System.EventHandler(this.Opt_IEd_Tb_Cut_Click);
            // 
            // Opt_IEd_Tb_Copy
            // 
            this.Opt_IEd_Tb_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Opt_IEd_Tb_Copy.Image = ((System.Drawing.Image)(resources.GetObject("Opt_IEd_Tb_Copy.Image")));
            this.Opt_IEd_Tb_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Opt_IEd_Tb_Copy.Name = "Opt_IEd_Tb_Copy";
            this.Opt_IEd_Tb_Copy.Size = new System.Drawing.Size(23, 22);
            this.Opt_IEd_Tb_Copy.Text = "Копировать";
            this.Opt_IEd_Tb_Copy.Click += new System.EventHandler(this.Opt_IEd_Tb_Copy_Click);
            // 
            // Opt_IEd_Tb_Paste
            // 
            this.Opt_IEd_Tb_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Opt_IEd_Tb_Paste.Image = ((System.Drawing.Image)(resources.GetObject("Opt_IEd_Tb_Paste.Image")));
            this.Opt_IEd_Tb_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Opt_IEd_Tb_Paste.Name = "Opt_IEd_Tb_Paste";
            this.Opt_IEd_Tb_Paste.Size = new System.Drawing.Size(23, 22);
            this.Opt_IEd_Tb_Paste.Text = "Вставить";
            this.Opt_IEd_Tb_Paste.Click += new System.EventHandler(this.Opt_IEd_Tb_Paste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.SaveNClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SaveNClose;
            this.ClientSize = new System.Drawing.Size(341, 329);
            this.ControlBox = false;
            this.Controls.Add(this.TC_Main);
            this.Controls.Add(this.SaveNClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки программы";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.TC_Main.ResumeLayout(false);
            this.TC_TP_MainPage.ResumeLayout(false);
            this.GB_Hw.ResumeLayout(false);
            this.GB_GenSt.ResumeLayout(false);
            this.GB_GenSt.PerformLayout();
            this.GB_Tokens.ResumeLayout(false);
            this.GB_Tokens.PerformLayout();
            this.TC_TP_AdvSettings.ResumeLayout(false);
            this.GB_Settings.ResumeLayout(false);
            this.GB_Settings.PerformLayout();
            this.TC_TP_IgnoreEd.ResumeLayout(false);
            this.TC_TP_IgnoreEd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opt_IgnEd)).EndInit();
            this.Opt_IgnEd_TB.ResumeLayout(false);
            this.Opt_IgnEd_TB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveNClose;
        private System.Windows.Forms.TabControl TC_Main;
        private System.Windows.Forms.TabPage TC_TP_MainPage;
        private System.Windows.Forms.GroupBox GB_Tokens;
        private System.Windows.Forms.TextBox InpSecToken;
        private System.Windows.Forms.Label L_InpSecToken;
        private System.Windows.Forms.TextBox InpPriToken;
        private System.Windows.Forms.Label L_InpPriToken;
        private System.Windows.Forms.TabPage TC_TP_AdvSettings;
        private System.Windows.Forms.GroupBox GB_Settings;
        private System.Windows.Forms.CheckBox Opt_UseNewSteamIDFormat;
        private System.Windows.Forms.CheckBox Opt_AutoUpdate;
        private System.Windows.Forms.CheckBox Opt_CpSidName;
        private System.Windows.Forms.CheckBox Opt_FrWQbnts;
        private System.Windows.Forms.CheckBox Opt_FrWHide;
        private System.Windows.Forms.CheckBox Opt_FrWOverride;
        private System.Windows.Forms.GroupBox GB_GenSt;
        private System.Windows.Forms.ComboBox Opt_ProtocolType;
        private System.Windows.Forms.Label L_Opt_ProtocolType;
        private System.Windows.Forms.CheckBox Opt_Autorun;
        private System.Windows.Forms.CheckBox Opt_EnableHotKey;
        private System.Windows.Forms.ComboBox Opt_Hotkey;
        private System.Windows.Forms.CheckBox Opt_ClipbInt;
        private System.Windows.Forms.TabPage TC_TP_IgnoreEd;
        private System.Windows.Forms.DataGridView Opt_IgnEd;
        private System.Windows.Forms.ToolStrip Opt_IgnEd_TB;
        private System.Windows.Forms.ToolStripButton Opt_IEd_Tb_AddRow;
        private System.Windows.Forms.ToolStripButton Opt_IEd_Tb_DelRow;
        private System.Windows.Forms.ToolStripButton Opt_IEd_Tb_Clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton Opt_IEd_Tb_Cut;
        private System.Windows.Forms.ToolStripButton Opt_IEd_Tb_Copy;
        private System.Windows.Forms.ToolStripButton Opt_IEd_Tb_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.GroupBox GB_Hw;
        private System.Windows.Forms.Label HwIDFld;
        private System.Windows.Forms.ComboBox Opt_InvViewer;
        private System.Windows.Forms.Label L_InvViewer;
    }
}