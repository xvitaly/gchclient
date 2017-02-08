/*
 * Форма "О программе" приложения Garant Checker Offline.
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
