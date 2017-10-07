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
using System.Reflection;
using Microsoft.Win32;

namespace gchcore
{
    /// <summary>
    /// Класс управления автозапуском приложения Garant Checker Offline.
    /// </summary>
    public static class Autorun
    {
        /// <summary>
        /// Проверяет статус автоматического запуска программы.
        /// </summary>
        /// <param name="ValName">Имя значения в реестре</param>
        /// <returns>Результат проверки</returns>
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

        /// <summary>
        /// Включает автоматический запуск приложения посредством создания ключа реестра.
        /// </summary>
        /// <param name="ValName">Имя значения в реестре</param>
        public static void Enable(string ValName)
        {
            RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(Path.Combine("Software", "Microsoft", "Windows", "CurrentVersion", "Run"), true);
            ResKey.SetValue(ValName, String.Format("\"{0}\" {1}", Assembly.GetEntryAssembly().Location, "/hide"));
            ResKey.Close();
        }

        /// <summary>
        /// Отключает автоматический запуск приложения посредством удаления созданного
        /// ранее ключа реестра.
        /// </summary>
        /// <param name="ValName">Имя значения в реестре</param>
        public static void Disable(string ValName)
        {
            RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(Path.Combine("Software", "Microsoft", "Windows", "CurrentVersion", "Run"), true);
            ResKey.DeleteValue(ValName, false);
            ResKey.Close();
        }
    }
}
