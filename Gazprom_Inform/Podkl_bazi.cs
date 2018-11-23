using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Gazprom_Inform
{
    class Podkl_bazi
    {
        public event Action<DataSet> List_Dbs;
        public event Action<bool> Status;
        public event Action<DataTable> List_Server;
        public static string DS;
        public static string IC;
        public static string UN;
        public static string UP;
        //Подключение базы 
        public SqlConnection Connection = new SqlConnection("Data Source=Empty; Initial Catalog = Empty;Persist Security Info=True; User ID=Empty; password =\"Empty\"");
        public void Register_get()
        {
            try
            {
                RegistryKey Gazprom_Option = Registry.CurrentConfig;
                RegistryKey Gazprom = Gazprom_Option.CreateSubKey("Gazprom");
                DS = Gazprom.GetValue("DS").ToString();
                IC = Gazprom.GetValue("IC").ToString();
                UN = Gazprom.GetValue("UN").ToString();
                UP = Gazprom.GetValue("UP").ToString();
                Set_Connection();
            }
            catch
            {
                RegistryKey Gazprom_Option = Registry.CurrentConfig;
                RegistryKey Gazprom = Gazprom_Option.CreateSubKey("Gazprom");
                Gazprom.SetValue("DS", "Empty");
                Gazprom.SetValue("IC", "Empty");
                Gazprom.SetValue("UN", "Empty");
                Gazprom.SetValue("UP", "Empty");
            }
        }
        public void Register_set(string DSvalue, string ICvalue, string UNvalue, string UPvalue)
        {
            RegistryKey Gazprom_Option = Registry.CurrentConfig;
            RegistryKey Gazprom = Gazprom_Option.CreateSubKey("Gazprom");
            Gazprom.SetValue("DS",DSvalue);
            Gazprom.SetValue("IC", ICvalue);
            Gazprom.SetValue("UN",UNvalue);
            Gazprom.SetValue("UP",UPvalue);
            Register_get();
        }

        public void Set_Connection()
        {
            Connection.ConnectionString = "Data Source=" + DS + ";Initial Catalog=" + IC + ";Persist Security Info=True; User ID=" + UN + ";Password=\"" + UP + "\"";
        }
        public void Connection_State()
        {
            Register_get();
            try
            {
                Connection.Open();
                Status(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Status(false);
            }
        }//Проверка данных в реестре
        public void Get_Base_List()
        {
            try
            {
                SqlConnection GDtBsLstCn = new SqlConnection("Data Source=" + DS + ";Initial Catalog = master; Persist Security Info=True;User ID=" + UN + ";Password=\"" + UP + "\"");
                GDtBsLstCn.Open();
                SqlDataAdapter BsAdpt = new SqlDataAdapter("exec sp_helpdb", GDtBsLstCn);
                DataSet CPst = new DataSet();
                BsAdpt.Fill(CPst, "db");
                List_Dbs(CPst);
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Получить список баз
        }
        public void poluchit_spis_serverov()
        {
            SqlDataSourceEnumerator ServersCheck = SqlDataSourceEnumerator.Instance;
            DataTable ServersTable = ServersCheck.GetDataSources();
            List_Server(ServersTable);
        }//Получение списка серверов
    
}
}
