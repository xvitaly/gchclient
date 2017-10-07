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
    public partial class FrmEvView : Form
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
        public FrmEvView(string URL, string SteamID)
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
        private void FrmEvView_Load(object sender, EventArgs e)
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
        private void FrmEvView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && BW_ImgLoader.IsBusy;
        }
    }
}
