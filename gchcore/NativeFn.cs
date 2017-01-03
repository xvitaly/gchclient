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

namespace gchcore
{
    /// <summary>
    /// Класс импорта native-функций приложения.
    /// </summary>
    public sealed class NativeFn
    {
        /// <summary>
        /// Enum с кодами, используемыми native-функциями API.
        /// </summary>
        private enum ShowWindowCommand
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

        /// <summary>
        /// Возвращает handle окна, находящегося в фокусе.
        /// </summary>
        [DllImport("user32")] private static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Возвращает handle потока, создавшего окно с указанным handle.
        /// </summary>
        /// <param name="hWnd">Handle окна</param>
        /// <param name="lpdwProcessId">Указатель на идентификатор процесса</param>
        [DllImport("user32")] private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);

        /// <summary>
        /// Подключает поток ввода к другому потоку выполнения.
        /// </summary>
        /// <param name="idAttach">Handle потока, который нужно присоединить</param>
        /// <param name="idAttachTo">Handle пока, к которому нужно присоединить</param>
        /// <param name="fAttach">Булево присоединения: true - присоединить; false - отсоединить.</param>
        /// <returns>Возвращает булево результата операции</returns>
        [DllImport("user32")] private static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);

        /// <summary>
        /// Устанавливает фокус на указанное окно.
        /// </summary>
        /// <param name="hWnd">Handle окна</param>
        /// <returns>Возвращает булево результата операции</returns>
        [DllImport("user32")] private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Проверяет свёрнуто ли окно.
        /// </summary>
        /// <param name="hWnd">Handle окна</param>
        /// <returns>Возвращает результат проверки</returns>
        [DllImport("user32")] private static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Задаёт параметры указанного окна.
        /// </summary>
        /// <param name="hWnd">Handle окна</param>
        /// <returns>Возвращает булево результата операции</returns>
        [DllImport("user32")] private static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommand nCmdShow);

        /// <summary>
        /// Работает с окном непосредственно: разворачивает / сворачивает.
        /// </summary>
        /// <param name="hWnd">Handle окна</param>
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
