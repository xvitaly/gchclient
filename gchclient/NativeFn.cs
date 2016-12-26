/*
 * Модуль импорта native-функций приложения Garant Checker Offline.
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
using System.Runtime.InteropServices;

namespace gchclient
{
    public sealed class NativeFn
    {
        public enum ShowWindowCommand
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMIMIMZE = 11,
            SW_MAX = 11
        }

        [DllImport("user32")] public static extern IntPtr GetForegroundWindow();
        [DllImport("user32")] public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);
        [DllImport("user32")] public static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);
        [DllImport("user32")] public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")] public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32")] public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommand nCmdShow);

        public static void ActivateWindow(IntPtr hWnd)
        {
            IntPtr FGWndPntr = GetForegroundWindow();
            if (hWnd != FGWndPntr)
            {
                IntPtr FGThr = GetWindowThreadProcessId(FGWndPntr, IntPtr.Zero);
                IntPtr CThr = GetWindowThreadProcessId(hWnd, IntPtr.Zero);
                if (FGThr != CThr) { AttachThreadInput(FGThr, CThr, true); SetForegroundWindow(hWnd); AttachThreadInput(FGThr, CThr, false); } else { SetForegroundWindow(hWnd); }
                if (IsIconic(hWnd)) { ShowWindow(hWnd, ShowWindowCommand.SW_RESTORE); } else { ShowWindow(hWnd, ShowWindowCommand.SW_SHOW); }
            }
        }
    }
}
