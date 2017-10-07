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
using System.Reflection;
using System.Windows.Forms;

namespace gchclient
{
    /// <summary>
    /// Класс формы "О программе".
    /// </summary>
    public partial class FrmAbout : Form
    {
        /// <summary>
        /// Возвращает название продукта (из ресурса сборки).
        /// </summary>
        private string AppProduct { get { object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false); return Attribs.Length != 0 ? ((AssemblyProductAttribute)Attribs[0]).Product : String.Empty; } }

        /// <summary>
        /// Возвращает версию приложения ((из ресурса сборки).
        /// </summary>
        private string AppVersion { get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        /// <summary>
        /// Возвращает название компании-разработчика (из ресурса сборки).
        /// </summary>
        private string AppCompany { get { object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false); return Attribs.Length != 0 ? ((AssemblyCompanyAttribute)Attribs[0]).Company : String.Empty; } }

        /// <summary>
        /// Возвращает копирайты приложения (из ресурса сборки).
        /// </summary>
        private string AppCopyright { get { object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false); return Attribs.Length != 0 ? ((AssemblyCopyrightAttribute)Attribs[0]).Copyright : String.Empty; } }

        /// <summary>
        /// Конструктор класса формы "О программе".
        /// </summary>
        public FrmAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, срабатывающий создании формы.
        /// </summary>
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            // Заполняем информацию о версии, копирайте...
            Text = AppProduct;
            labelProductName.Text = AppProduct;
            labelVersion.Text = String.Format("Version: {0}", AppVersion);
            labelCopyright.Text = AppCopyright;
            labelCompanyName.Text = AppCompany;
        }

        /// <summary>
        /// Метод, срабатывающий при нажатии на кнопку "OK".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
