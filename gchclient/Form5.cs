/*
 * Форма просмотрщика доказательств приложения Garant Checker Offline.
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
using System.IO;
using System.Net;
using System.Drawing.Drawing2D;

namespace gchclient
{
    public partial class frmViewer : Form
    {
        private string ImageURL;
        private string SteamID64;
        public frmViewer(string URL, string SteamID)
        {
            InitializeComponent();
            ImageURL = URL;
            SteamID64 = SteamID;
        }

        private Image ResizeImg(Image OriginalImg, int nWidth, int nHeight)
        {
            Image Result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)Result))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(OriginalImg, 0, 0, nWidth, nHeight);
                g.Dispose();
            }
            return Result;
        }

        private void frmViewer_Load(object sender, EventArgs e)
        {
            // Изменяем заголовок формы...
            this.Text = String.Format(this.Text, SteamID64);

            // Задаём параметры окна согласно настройкам приложения...
            this.MinimizeBox = !Properties.Settings.Default.FrWnOverride;
            this.ShowInTaskbar = !Properties.Settings.Default.FrWnOverride;
            this.ShowIcon = !Properties.Settings.Default.FrWnOverride;

            // Загружаем изображение...
            if (!BW_ImgLoader.IsBusy) { BW_ImgLoader.RunWorkerAsync(); }
        }

        private void BW_ImgLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Изменяем текст строки состояния...
                this.Invoke((MethodInvoker)delegate() { SB_Status.Text = Properties.Resources.AppSBReceiving; });
                // Генерируем временный файл...
                string ImgFileName = Path.GetTempFileName();
                // Загружаем файл...
                using (WebClient Downloader = new WebClient())
                {
                    Downloader.Headers.Add("User-Agent", Properties.Resources.AppUserAgent);
                    Downloader.DownloadFile(ImageURL, ImgFileName);
                }
                // Создаём файловый поток во избежание блокировки файла приложением...
                FileStream ImgStream = new FileStream(ImgFileName, FileMode.Open, FileAccess.Read);
                // Загружаем картинку в контрол из потока...
                this.Invoke((MethodInvoker)delegate() { ImgBoxMain.Image = Image.FromStream(ImgStream); });
                // Закрываем поток...
                ImgStream.Close();
                // Удаляем исходный файл...
                if (File.Exists(ImgFileName)) { File.Delete(ImgFileName); }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BW_ImgLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate() { SB_Status.Text = Properties.Resources.AppSBReady; });
        }

        private void frmViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_ImgLoader.IsBusy;
        }
    }
}
