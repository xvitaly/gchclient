/*
 * Модуль общих функций приложения Garant Checker Offline.
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
using System.Security.Cryptography;

namespace gchclient
{
    public sealed class CoreLib
    {
        public static string SimpleIntStrWNull(int Numb)
        {
            string Result;
            if ((Numb >= 0) && (Numb <= 9)) { Result = "0" + Numb.ToString(); } else { Result = Numb.ToString(); }
            return Result;
        }
        
        public static DateTime UnixTime2DateTime(double TimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(TimeStamp).ToLocalTime();
            return dtDateTime;
        }
        
        public static string md5hash(string Filename)
        {
            MD5 md5h = MD5.Create();
            byte[] hashsum = md5h.ComputeHash(Encoding.Default.GetBytes(Filename));
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < hashsum.Length; i++) { SB.Append(hashsum[i].ToString("x2")); }
            return SB.ToString();
        }

        public static string FormatLink(string SrcLnk)
        {
            string[] spl = SrcLnk.Split('/');
            return String.Format("http://steamcommunity.com/{0}/{1}/", spl[3], spl[4]);
        }
    }
}
