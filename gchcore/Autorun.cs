/*
 * Модуль управления автозапуском приложения Garant Checker Offline.
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
using System.Reflection;
using Microsoft.Win32;

namespace gchcore
{
    public static class Autorun
    {
        public static bool CheckStatus(string ValName)
        {
            bool Result = false;
            RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(Path.Combine("Software", "Microsoft", "Windows", "CurrentVersion", "Run"), false);
            if (ResKey != null)
            {
                object RetObj = ResKey.GetValue(ValName);
                Result = RetObj != null;
                ResKey.Close();
            }
            return Result;
        }

        public static void Enable(string ValName)
        {
            RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(Path.Combine("Software", "Microsoft", "Windows", "CurrentVersion", "Run"), true);
            ResKey.SetValue(ValName, String.Format("\"{0}\" {1}", Assembly.GetEntryAssembly().Location, "/hide"));
            ResKey.Close();
        }

        public static void Disable(string ValName)
        {
            RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(Path.Combine("Software", "Microsoft", "Windows", "CurrentVersion", "Run"), true);
            ResKey.DeleteValue(ValName, false);
            ResKey.Close();
        }
    }
}
