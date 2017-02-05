/*
 * Форма просмотрщика доказательств приложения Garant Checker Offline.
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
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс формы просмотрщика доказательств приложения Garant Checker Offline.
    /// </summary>
    public partial class frmViewer : Form
    {
        /// <summary>
        /// Хранит и предоставляет доступ к URL изображения.
        /// </summary>
        private string ImageURL { get; set; }

        /// <summary>
        /// Хранит и предоставляет доступ к SteamID профиля.
        /// </summary>
        private string SteamID64 { get; set; }

        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        public frmViewer(string URL, string SteamID)
        {
            InitializeComponent();
            ImageURL = URL;
            SteamID64 = SteamID;
        }

        /// <summary>
        /// Изменяет размер изображения.
        /// </summary>
        /// <param name="OriginalImg">Оригинальное изображение</param>
        /// <param name="nWidth">Новое значение высоты</param>
        /// <param name="nHeight">Новое значение ширины</param>
        /// <returns>Масштабированное изображение</returns>
        private Image ResizeImg(Image OriginalImg, int nWidth, int nHeight)
        {
            Image Result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)Result))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(OriginalImg, 0, 0, nWidth, nHeight);
            }
            return Result;
        }

        /// <summary>
        /// Событие "загрузка формы".
        /// </summary>
        private void frmViewer_Load(object sender, EventArgs e)
        {
            // Изменяем заголовок формы...
            Text = String.Format(Text, SteamID64);

            // Задаём параметры окна согласно настройкам приложения...
            MinimizeBox = !Properties.Settings.Default.FrWnOverride;
            ShowInTaskbar = !Properties.Settings.Default.FrWnOverride;
            ShowIcon = !Properties.Settings.Default.FrWnOverride;

            // Загружаем изображение...
            if (!BW_ImgLoader.IsBusy) { BW_ImgLoader.RunWorkerAsync(); }
        }

        /// <summary>
        /// Асинхронный обработчик. Выполняется в отдельном потоке.
        /// </summary>
        private void BW_ImgLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            // Изменяем текст строки состояния...
            Invoke((MethodInvoker)delegate () { SB_Status.Text = Properties.Resources.AppSBReceiving; });

            // Генерируем временный файл...
            string ImgFileName = Path.GetTempFileName();

            // Загружаем файл...
            CoreLib.DownloadRemoteFile(ImageURL, ImgFileName, Properties.Resources.AppUserAgent);

            // Создаём файловый поток во избежание блокировки файла приложением...
            using (FileStream ImgStream = new FileStream(ImgFileName, FileMode.Open, FileAccess.Read))
            {
                // Загружаем картинку в контрол из потока...
                Invoke((MethodInvoker)delegate () { ImgBoxMain.Image = Image.FromStream(ImgStream); });
            }

            // Удаляем исходный файл...
            if (File.Exists(ImgFileName)) { File.Delete(ImgFileName); }
        }

        /// <summary>
        /// Метод, вызываемый по окончании работы асинхронного обработчика.
        /// </summary>
        private void BW_ImgLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null) { SB_Status.Text = Properties.Resources.AppSBReady; } else { MessageBox.Show(e.Error.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Событие "попытка закрытия формы".
        /// </summary>
        private void frmViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_ImgLoader.IsBusy;
        }
    }
}
