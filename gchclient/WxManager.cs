/*
 * Класс для взаимодействия с отдельным формами Garant Checker Offline.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gchclient
{
    public static class WxManager
    {
        public static void ShowReportForm(string SteamID)
        {
            frmReportU FrmRep = new frmReportU(SteamID);
            FrmRep.ShowDialog();
        }

        public static void ShowTokenForm()
        {
            frmTokenInfo FrmTInfo = new frmTokenInfo();
            FrmTInfo.ShowDialog();
        }

        public static void ShowOptionsForm()
        {
            frmOptions FRMOPT = new frmOptions();
            FRMOPT.ShowDialog();
        }

        public static void ShowFriendChkForm(string SteamID64, bool WinType)
        {
            frmFrChk frmChk = new frmFrChk(SteamID64);
            if (WinType) { frmChk.ShowDialog(); } else { frmChk.Show(); }
        }

        public static void ShowEvidenceViewForm(string URL, string SteamID64, bool WinType)
        {
            frmViewer FView = new frmViewer(URL, SteamID64);
            if (WinType) { FView.ShowDialog(); } else { FView.Show(); }
        }

        public static void ShowDownloadForm(string URL, string FileName)
        {
            using (FrmDnWrk FrmDnl = new FrmDnWrk(URL, FileName))
            {
                FrmDnl.ShowDialog();
            }
        }
    }
}
