/*
 * Модуль авторизации и расчёта аппаратных ID приложения Garant Checker Offline.
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
