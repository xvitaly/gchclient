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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;

namespace gchcore
{
    /// <summary>
    /// Класс, предоставляющий методы для общих целей.
    /// </summary>
    public static class CoreLib
    {
        /// <summary>
        /// Добавляет незначащие нули перед числом и возвращает в качестве строки.
        /// </summary>
        /// <param name="Numb">Целое, для которого нужно добавить нули</param>
        /// <returns>Число в строковом представлении с незначащими нулями</returns>
        public static string SimpleIntStrWNull(int Numb)
        {
            string Result;
            if ((Numb >= 0) && (Numb <= 9)) { Result = "0" + Numb.ToString(); } else { Result = Numb.ToString(); }
            return Result;
        }

        /// <summary>
        /// Преобразует дату/время из формата unixtime в DateTime.
        /// </summary>
        /// <param name="TimeStamp">Штамп времени в формате UnixTime</param>
        /// <returns>Возвращает штамп времени в формате DateTime</returns>
        public static DateTime UnixTime2DateTime(double TimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(TimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Вычисляет MD5 хеш файла.
        /// </summary>
        /// <param name="FileName">Имя файла</param>
        public static string CalculateFileMD5(string FileName)
        {
            byte[] RValue;
            using (FileStream FileP = new FileStream(FileName, FileMode.Open))
            {
                using (MD5 MD5Crypt = new MD5CryptoServiceProvider())
                {
                    RValue = MD5Crypt.ComputeHash(FileP);
                }
            }
            StringBuilder StrRes = new StringBuilder();
            for (int i = 0; i < RValue.Length; i++) { StrRes.Append(RValue[i].ToString("x2")); }
            return StrRes.ToString();
        }

        /// <summary>
        /// Рассчитывает MD5-хеш строки.
        /// </summary>
        /// <param name="Contents">Строка для расчёта хеша</param>
        /// <returns>Хеш в формате MD5</returns>
        public static string GetMD5Hash(string Contents)
        {
            MD5 md5h = MD5.Create();
            byte[] hashsum = md5h.ComputeHash(Encoding.Default.GetBytes(Contents));
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < hashsum.Length; i++) { SB.Append(hashsum[i].ToString("x2")); }
            return SB.ToString();
        }

        /// <summary>
        /// Переформатирует ссылку в соответствие с шаблоном.
        /// </summary>
        /// <param name="SrcLnk">Ссылка для преобразования</param>
        /// <returns>Форматированная по шаблону ссылка</returns>
        public static string FormatLink(string SrcLnk)
        {
            string[] spl = SrcLnk.Split('/');
            return String.Format("http://steamcommunity.com/{0}/{1}/", spl[3], spl[4]);
        }

        /// <summary>
        /// Завершает процесс с указанным именем.
        /// </summary>
        /// <param name="ProcessName">Имя процесса для завершения</param>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public static void ProcessTerminate(string ProcessName)
        {
            Process[] LocalByName = Process.GetProcessesByName(ProcessName);
            foreach (Process ResName in LocalByName)
            {
                ResName.Kill();
            }
        }

        /// <summary>
        /// Получает содержимое текстового файла из внутреннего ресурса приложения.
        /// </summary>
        /// <param name="FileName">Внутреннее имя ресурсного файла</param>
        /// <returns>Содержимое текстового файла</returns>
        public static string GetTemplateFromResource(string FileName)
        {
            string Result = String.Empty;
            using (StreamReader Reader = new StreamReader(Assembly.GetCallingAssembly().GetManifestResourceStream(FileName)))
            {
                Result = Reader.ReadToEnd();
            }
            return Result;
        }

        /// <summary>
        /// Открывает указанный URL в системном браузере по умолчанию.
        /// </summary>
        /// <param name="URI">URL для загрузки в браузере</param>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public static void OpenWebPage(string URI)
        {
            Process.Start(URI);
        }

        /// <summary>
        /// Получает содержимое текстового файла из Интернета по указанному URL.
        /// </summary>
        /// <param name="URL">URL для загрузки</param>
        /// <param name="UserAgent">Заголовок HTTP UserAgent для запроса</param>
        /// <param name="URL">Заголовок HTTP HardwareID для запроса</param>
        /// <returns>Содержимое текстового файла из указанного URL</returns>
        public static string DownloadRemoteString(string URL, string UserAgent, string HardwareID = "")
        {
            // Инициализируем пустую строку...
            string Result = String.Empty;

            // Загружаем из Интернета...
            using (WebClient Downloader = new WebClient())
            {
                Downloader.Encoding = Encoding.UTF8;
                Downloader.Headers.Add("User-Agent", UserAgent);
                Downloader.Headers.Add("HardwareID", HardwareID);
                Result = Downloader.DownloadString(URL);
            }

            // Возвращаем результат...
            return Result;
        }

        /// <summary>
        /// Загружает указанный файл из Интернета по указанному URL.
        /// </summary>
        /// <param name="URL">URL для загрузки</param>
        /// <param name="FileName">Имя файла для записи скачанного</param>
        /// <param name="UserAgent">Заголовок HTTP UserAgent для запроса</param>
        /// <param name="URL">Заголовок HTTP HardwareID для запроса</param>
        public static bool DownloadRemoteFile(string URL, string FileName, string UserAgent, string HardwareID = "")
        {
            // Загружаем файл из Интернета...
            using (WebClient Downloader = new WebClient())
            {
                Downloader.Headers.Add("User-Agent", UserAgent);
                Downloader.Headers.Add("HardwareID", HardwareID);
                Downloader.DownloadFile(URL, FileName);
            }

            // Проверяем прошла ли загрузка...
            return File.Exists(FileName);
        }

        /// <summary>
        /// Определяет запуск под Windows 10.
        /// </summary>
        public static bool IsModernOS()
        {
            return Environment.OSVersion.Version >= new Version("10.0.0.0");
        }
    }
}
