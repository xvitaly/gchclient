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
using System.Xml;

namespace gchcore
{
    /// <summary>
    /// Класс, используемый для проверки обновлений.
    /// </summary>
    public class Updater
    {
        /// <summary>
        /// Хранит последнюю доступную версию приложения.
        /// </summary>
        public Version AppUpdateVersion { get; private set; }

        /// <summary>
        /// Хранит URL для загрузки последней доступной версии приложения.
        /// </summary>
        public string AppUpdateURL { get; private set; }

        /// <summary>
        /// Хранит хеш-сумму установщика последней доступной версии приложения.
        /// </summary>
        public string AppUpdateHash { get; private set; }

        /// <summary>
        /// Хранит UserAgent, который будет использоваться в соответствующем
        /// HTTP заголовке запроса.
        /// </summary>
        private string UserAgent { get; set; }

        /// <summary>
        /// Хранит имя главного бинарника приложения.
        /// </summary>
        private string BinExecName { get; set; }

        /// <summary>
        /// Хранит загруженный с сервера обновлений XML.
        /// </summary>
        private string UpdateXML { get; set; }

        /// <summary>
        /// Парсит загруженный XML файл. Заполняет поля класса значениями.
        /// Вызывается конструктором класса.
        /// </summary>
        private void ParseXML()
        {
            // Загружаем XML...
            XmlDocument XMLD = new XmlDocument();
            XMLD.LoadXml(UpdateXML);

            // Разбираем XML в цикле...
            foreach (XmlNode Node in XMLD.SelectNodes("Updates"))
            {
                foreach (XmlNode Child in Node.ChildNodes)
                {
                    switch (Child.Name)
                    {
                        case "Application":
                            AppUpdateVersion = new Version(Child.ChildNodes[0].InnerText);
                            AppUpdateURL = Child.ChildNodes[1].InnerText;
                            AppUpdateHash = Child.ChildNodes[2].InnerText;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Проверяет наличие обновлений для приложения.
        /// </summary>
        /// <returns>Возвращает булево наличия обновлений</returns>
        public bool CheckAppUpdate()
        {
            FileVersionInfo GchCl = FileVersionInfo.GetVersionInfo(BinExecName);
            return AppUpdateVersion > new Version(GchCl.FileVersion);
        }

        /// <summary>
        /// Проверяет hash обновления приложения с переданным в качестве параметра.
        /// </summary>
        /// <param name="Hash">Хеш загруженного файла</param>
        /// <returns>Возвращает булево соответствия хешей</returns>
        public bool CheckAppHash(string Hash)
        {
            return AppUpdateHash == Hash;
        }

        /// <summary>
        /// Генерирует имя файла на диске для обновления.
        /// </summary>
        /// <param name="Url">URL загрузки</param>
        /// <returns>Возвращает имя файла</returns>
        public static string GenerateUpdateFileName(string Url)
        {
            return Path.HasExtension(Url) ? Url : Path.ChangeExtension(Url, "exe");
        }

        /// <summary>
        /// Конструктор класса. Получает информацию об обновлениях.
        /// </summary>
        /// <param name="ExecBin">Имя главного бинарника</param>
        /// <param name="UA">UserAgent приложения</param>
        public Updater(string ExecBin, string UA)
        {
            BinExecName = ExecBin;
            UserAgent = UA;

            // Загружаем и парсим XML...
            UpdateXML = CoreLib.DownloadRemoteString(Properties.Resources.AppUpdateURL, UA);
            ParseXML();
        }
    }
}
