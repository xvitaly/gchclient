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

namespace gchclient
{
    /// <summary>
    /// Класс для взаимодействия с отдельным формами и расширениями.
    /// </summary>
    public static class WxManager
    {
        /// <summary>
        /// Отображает форму модуля сообщения о мошенничестве.
        /// </summary>
        /// <param name="SteamID">SteamID32 профиля</param>
        public static void ShowReportForm(string SteamID)
        {
            using (FrmRep FrmRep = new FrmRep(SteamID))
            {
                FrmRep.ShowDialog();
            }
        }

        /// <summary>
        /// Отображает форму с информацией об используемых токенах.
        /// </summary>
        public static void ShowTokenForm()
        {
            using (FrmTokenInfo FrmTInfo = new FrmTokenInfo())
            {
                FrmTInfo.ShowDialog();
            }
        }

        /// <summary>
        /// Отображает форму настроек программы.
        /// </summary>
        public static void ShowOptionsForm()
        {
            using (FrmOptions FRMOPT = new FrmOptions())
            {
                FRMOPT.ShowDialog();
            }
        }

        /// <summary>
        /// Отображает форму модуля проверки друзей пользователя.
        /// </summary>
        /// <param name="SteamID64">SteamID64 профиля</param>
        /// <param name="WinType">Включает / отключает блокировку главного окна</param>
        public static void ShowFriendChkForm(string SteamID64, bool WinType)
        {
            FrmFriChk frmChk = new FrmFriChk(SteamID64);
            if (WinType) { frmChk.ShowDialog(); } else { frmChk.Show(); }
        }

        /// <summary>
        /// Отображает форму модуля просмотра доказательств.
        /// </summary>
        /// <param name="URL">URL изображения</param>
        /// <param name="SteamID64">SteamID64 профиля</param>
        /// <param name="WinType">Включает / отключает блокировку главного окна</param>
        public static void ShowEvidenceViewForm(string URL, string SteamID64, bool WinType)
        {
            FrmEvView FView = new FrmEvView(URL, SteamID64);
            if (WinType) { FView.ShowDialog(); } else { FView.Show(); }
        }

        /// <summary>
        /// Отображает форму асинхронной загрузки файлов из Интернета.
        /// </summary>
        /// <param name="URL">URL файла для загрузки</param>
        /// <param name="FileName">Имя файла для сохранения</param>
        public static void ShowDownloadForm(string URL, string FileName)
        {
            using (FrmDnWrk FrmDnl = new FrmDnWrk(URL, FileName))
            {
                FrmDnl.ShowDialog();
            }
        }

        /// <summary>
        /// Отображает форму "О программе".
        /// </summary>
        public static void ShowAboutForm()
        {
            using (FrmAbout AbFrm = new FrmAbout())
            {
                AbFrm.ShowDialog();
            }
        }
    }
}
