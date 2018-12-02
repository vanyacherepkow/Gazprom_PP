using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Gazprom_Inform
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Spis_Serv());
        }
        public static string login;
        public static string NameSotr;
        public static int identificator;
        public static int Admin_access;
        public static int ID_Access;
        public static string BackColor;
        public static string ForeColor;
        public static DataTable SpisSotr;
        public static string UserDolj;
        public static DataTable IshDok;
        public static DataTable GotDok;
    }
}
