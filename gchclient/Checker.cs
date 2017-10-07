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
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web;
using gchcore;

namespace gchclient
{
    /// <summary>
    /// Класс проверки приложения Garant Checker Offline.
    /// </summary>
    public sealed class Checker
    {
        /// <summary>
        /// Хранит никнейм проверяемого игрока.
        /// </summary>
        public string Nickname { get; private set; }

        /// <summary>
        /// Хранит SteamID проверяемого пользователя в формате SteamID32.
        /// </summary>
        public string SteamID { get; private set; }

        /// <summary>
        /// Хранит результат проверки по базе данных сайта.
        /// </summary>
        public string SiteStatus { get; private set; }

        /// <summary>
        /// Хранит URL аватара проверяемого пользователя.
        /// </summary>
        public string AvatarURL { get; private set; }

        /// <summary>
        /// Хранит постоянную ссылку на проверяемый профиль.
        /// </summary>
        public string Permalink { get; private set; }

        /// <summary>
        /// Хранит кастомное описание проверяемого пользователя из базы сайта.
        /// </summary>
        public string CustomText { get; private set; }

        /// <summary>
        /// Хранит статус VAC-блокировок проверяемого профиля.
        /// </summary>
        public string VCStatus { get; private set; }

        /// <summary>
        /// Хранит тип аккаунта проверяемого профиля (есть ли купленные игры).
        /// </summary>
        public string Free2PlaySt { get; private set; }

        /// <summary>
        /// Хранит статус торговли проверяемого аккаунта.
        /// </summary>
        public string TradeStatus { get; private set; }

        /// <summary>
        /// Хранит SteamID проверямого профиля в 64-битном формате.
        /// </summary>
        public string SteamID64 { get; private set; }

        /// <summary>
        /// Хранит SteamID проверяемого профиля в формате SteamIDv3.
        /// </summary>
        public string SteamIDv3 { get; private set; }

        /// <summary>
        /// Хранит результат проверки профиля по базе SteamRep.
        /// </summary>
        public string SRStatus { get; private set; }

        /// <summary>
        /// Хранит количество игровых банов на проверяемом профиле.
        /// </summary>
        public string GameBans { get; private set; }

        /// <summary>
        /// Хранит путь к файлу аватара на диске.
        /// </summary>
        public string LocalAvatarImg { get; private set; }

        /// <summary>
        /// Хранит и возвращает путь к каталогу временного хранения аватаров.
        /// </summary>
        public string LocalAvatarDir { get; } = Path.Combine(Path.GetTempPath(), Properties.Resources.AppIntName);

        /// <summary>
        /// Занимается очисткой строки от различных специальных символов и ссылок.
        /// </summary>
        /// <param name="Str">Строка для очистки</param>
        /// <param name="Target">Заменитель</param>
        /// <returns>Исправленная строка</returns>
        private string CleanHTMLEntities(string Str, string Target = " ")
        {
            return Regex.Replace(HttpUtility.HtmlDecode(Str), Properties.Resources.AppCustDescrCleanRegex, Target);
        }

        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        /// <param name="Uri">URL API чекера</param>
        /// <param name="Key">API токен</param>
        /// <param name="Par">Строка для проверки</param>
        /// <param name="SSL">Использовать ли SSL</param>
        public Checker(string Uri, string Key, string Par, bool SSL)
        {
            XmlDocument XMLD = new XmlDocument();
            XMLD.LoadXml(CoreLib.DownloadRemoteString(String.Format(Uri, (SSL ? "https://" : "http://"), "check", Key, Par), Properties.Resources.AppUserAgent, Auth.HardwareID));
            if (XMLD.GetElementsByTagName("qstatus")[0].InnerText == "OK")
            {
                try { Nickname = XMLD.GetElementsByTagName("nickname")[0].InnerText; if (Nickname.Length > 25) { Nickname = Nickname.Substring(0, 25); } } catch { Nickname = Properties.Resources.AppNicknameUnknown; }
                SteamID = XMLD.GetElementsByTagName("steamID")[0].InnerText;
                SteamIDv3 = XMLD.GetElementsByTagName("steamIDv3")[0].InnerText;
                SteamID64 = XMLD.GetElementsByTagName("steamID64")[0].InnerText;
                AvatarURL = XMLD.GetElementsByTagName("avatar")[0].InnerText;
                SiteStatus = XMLD.GetElementsByTagName("sitestatus")[0].InnerText;
                Permalink = XMLD.GetElementsByTagName("permalink")[0].InnerText;
                VCStatus = XMLD.GetElementsByTagName("isbanned")[0].InnerText;
                Free2PlaySt = XMLD.GetElementsByTagName("isf2p")[0].InnerText;
                TradeStatus = XMLD.GetElementsByTagName("istrbanned")[0].InnerText;
                SRStatus = CleanHTMLEntities(XMLD.GetElementsByTagName("steamrep")[0].InnerText, String.Empty);
                GameBans = XMLD.GetElementsByTagName("gamebans")[0].InnerText;
                LocalAvatarImg = Path.Combine(LocalAvatarDir, CoreLib.GetMD5Hash(AvatarURL) + ".jpg");
                try { CustomText = CleanHTMLEntities(XMLD.GetElementsByTagName("customdescr")[0].InnerText); } catch { CustomText = Properties.Resources.CustInfoNone; }
            }
            else
            {
                throw new ArgumentException(Properties.Resources.ErrNotExists);
            }
        }
    }
}
