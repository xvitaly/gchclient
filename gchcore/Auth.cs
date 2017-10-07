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
using System.Management;

namespace gchcore
{
    /// <summary>
    /// Класс авторизации и расчёта аппаратных ID приложения.
    /// </summary>
    public static class Auth
    {
        /// <summary>
        /// Хранит и возвращает аппаратный ID, сгенерированный приложением.
        /// </summary>
        public static string HardwareID { get; set; }

        /// <summary>
        /// Получает аппаратный ID посредством MMC.
        /// </summary>
        /// <returns>Аппаратный ID</returns>
        public static string GenerateHWID()
        {
            string Result = String.Empty;
            ManagementObjectSearcher WMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            ManagementObjectCollection MOCollection = WMISearcher.Get();
            foreach (ManagementObject MObject in MOCollection)
            {
                if (MObject["SerialNumber"] != null)
                {
                    Result = MObject["SerialNumber"].ToString();
                    break;
                }
            }
            return CoreLib.md5hash(Result);
        }
    }
}
