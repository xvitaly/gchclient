/*
 * Модуль общих функций приложения Garant Checker Offline.
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
using System.Diagnostics;
using System.IO;
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
        /// Рассчитывает MD5-хеш файла.
        /// </summary>
        /// <param name="Filename">Имя файла, для которого будем вычислять хеш</param>
        /// <returns>Хеш в формате MD5</returns>
        public static string md5hash(string Filename)
        {
            MD5 md5h = MD5.Create();
            byte[] hashsum = md5h.ComputeHash(Encoding.Default.GetBytes(Filename));
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
    }
}
