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
using System.Management;

namespace gchclient
{
    public static class Auth
    {
        public static string HardwareID { get; set; }
        public static string GenerateHWID()
        {
            string Result = "";
            ManagementObjectSearcher WMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            ManagementObjectCollection MOCollection = WMISearcher.Get();
            foreach (ManagementObject MObject in MOCollection) { Result = MObject["SerialNumber"].ToString(); }
            return CoreLib.md5hash(Result);
        }
    }
}
