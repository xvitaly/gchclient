/*
 * Класс проверки приложения Garant Checker Offline.
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
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
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
        /// Базовый конструктор класса.
        /// </summary>
        /// <param name="Uri">URL API чекера</param>
        /// <param name="Key">API токен</param>
        /// <param name="Par">Строка для проверки</param>
        /// <param name="SSL">Использовать ли SSL</param>
        public Checker(string Uri, string Key, string Par, bool SSL)
        {
            string XMLFileName = Path.GetTempFileName();
            if (CoreLib.DownloadRemoteFile(String.Format(Uri, (SSL ? "https://" : "http://"), "check", Key, Par), XMLFileName, Properties.Resources.AppUserAgent, Auth.HardwareID))
            {
                using (FileStream XMLFS = new FileStream(XMLFileName, FileMode.Open, FileAccess.Read))
                {
                    XmlDocument XMLD = new XmlDocument();
                    XMLD.Load(XMLFS);
                    XmlNodeList XMLNList = XMLD.GetElementsByTagName("userprofile");
                    for (int i = 0; i < XMLNList.Count; i++)
                    {
                        XmlElement GameID = (XmlElement)XMLD.GetElementsByTagName("userprofile")[i];
                        if (XMLD.GetElementsByTagName("qstatus")[i].InnerText == "OK")
                        {
                            try { Nickname = XMLD.GetElementsByTagName("nickname")[i].InnerText; if (Nickname.Length > 25) { Nickname = Nickname.Substring(0, 25); } } catch { Nickname = Properties.Resources.AppNicknameUnknown; }
                            SteamID = XMLD.GetElementsByTagName("steamID")[i].InnerText;
                            SteamIDv3 = XMLD.GetElementsByTagName("steamIDv3")[i].InnerText;
                            SteamID64 = XMLD.GetElementsByTagName("steamID64")[i].InnerText;
                            AvatarURL = XMLD.GetElementsByTagName("avatar")[i].InnerText;
                            SiteStatus = XMLD.GetElementsByTagName("sitestatus")[i].InnerText;
                            Permalink = XMLD.GetElementsByTagName("permalink")[i].InnerText;
                            VCStatus = XMLD.GetElementsByTagName("isbanned")[i].InnerText;
                            Free2PlaySt = XMLD.GetElementsByTagName("isf2p")[i].InnerText;
                            TradeStatus = XMLD.GetElementsByTagName("istrbanned")[i].InnerText;
                            SRStatus = XMLD.GetElementsByTagName("steamrep")[i].InnerText;
                            GameBans = XMLD.GetElementsByTagName("gamebans")[i].InnerText;
                            LocalAvatarImg = Path.Combine(LocalAvatarDir, CoreLib.md5hash(AvatarURL) + ".jpg");
                            try { CustomText = Regex.Replace(XMLD.GetElementsByTagName("customdescr")[i].InnerText, Properties.Resources.AppCustDescrCleanRegex, " "); } catch { CustomText = Properties.Resources.CustInfoNone; }
                        }
                        else
                        {
                            throw new ArgumentException(Properties.Resources.ErrNotExists);
                        }
                    }
                }
                File.Delete(XMLFileName);
            }
            else
            {
                throw new FileNotFoundException(Properties.Resources.ErrXML);
            }
        }
    }
}
