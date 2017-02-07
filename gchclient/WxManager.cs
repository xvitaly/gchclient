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
    }
}
