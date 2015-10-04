/*
 * Класс проверки приложения Garant Checker Offline.
 * 
 * Copyright 2012 - 2015 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2015 EasyCoding Team.
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
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace gchclient
{
    public sealed class Checker
    {
        public bool Result;
        public string Nickname;
        public string SteamID;
        public string SiteStatus;
        public string AvatarURL;
        public string Permalink;
        public string CustomText;
        public string VCStatus;
        public string Free2PlaySt;
        public string ErrMsg;
        public string TradeStatus;
        public string SteamID64;
        public string SteamIDv3;
        public string SRStatus;
        public string GameBans;
        public Checker(string Uri, string Key, string Par, bool SSL)
        {
            string XMLFileName = Path.GetTempFileName();
            Result = false;
            try
            {
                using (WebClient Downloader = new WebClient())
                {
                    Downloader.Headers.Add("User-Agent", Properties.Resources.AppUserAgent);
                    Downloader.Headers.Add("HardwareID", Auth.HardwareID);
                    Downloader.DownloadFile(String.Format(Uri, (SSL ? "https://" : "http://"), "check", Key, Par), XMLFileName);
                }
                if (File.Exists(XMLFileName))
                {
                    try
                    {
                        XmlDocument XMLD = new XmlDocument();
                        using (FileStream XMLFS = new FileStream(XMLFileName, FileMode.Open, FileAccess.Read))
                        {
                            XMLD.Load(XMLFS);
                            XmlNodeList XMLNList = XMLD.GetElementsByTagName("userprofile");
                            for (int i = 0; i < XMLNList.Count; i++)
                            {
                                XmlElement GameID = (XmlElement)XMLD.GetElementsByTagName("userprofile")[i];
                                if (XMLD.GetElementsByTagName("qstatus")[i].InnerText == "OK")
                                {
                                    Result = true;
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
                                    try
                                    {
                                        CustomText = Regex.Replace(XMLD.GetElementsByTagName("customdescr")[i].InnerText, @"<(.|\n)*?>", " ");
                                    }
                                    catch
                                    {
                                        CustomText = Properties.Resources.CustInfoNone;
                                    }
                                }
                                else
                                {
                                    Result = false;
                                    ErrMsg = Properties.Resources.ErrNotExists;
                                }
                            }
                            XMLFS.Close();
                        }
                        File.Delete(XMLFileName);
                    }
                    catch (Exception ex)
                    {
                        Result = false;
                        ErrMsg = ex.Message;
                    }
                }
                else
                {
                    Result = false;
                    ErrMsg = Properties.Resources.ErrXML;
                }
            }
            catch (Exception ex)
            {
                Result = false;
                ErrMsg = ex.Message;
            }
        }
    }
}
