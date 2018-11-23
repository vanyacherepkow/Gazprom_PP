using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Gazprom_Inform
{
    class Rabota_s_bazoi
    {
        Podkl_bazi _PB = new Podkl_bazi();
       // public string id_identificator = "select [dbo].[Sotr].[ID_Sotr] from [dbo].[Sotr] inner join [dbo].[Dolj] on [dbo].[Dolj].[id_Dolj]=[dbo].[Sotr].[Dolj_ID] inner join [dbo].[Access_level] on [dbo].[Sotr].[Access_id]=[dbo].[Access_level].[Id_access] where [Sotr].[Password_Sotr]='";

        public void id_ident()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand ID_IdentSQL= new SqlCommand ("select [dbo].[Sotr].[ID_Sotr] from [dbo].[Sotr] where [dbo].[Sotr].[Password_Sotr] ='", _PB.Connection);
            Program.identificator = Convert.ToInt32(ID_IdentSQL.ExecuteScalar().ToString());
            _PB.Connection.Close();
        }
        public void viv_im_sotr()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand NameSotrSQL= new SqlCommand ("select[dbo].[Sotr].[Im_Sotr] + ' ' + [dbo].[Sotr].[Otch_Sotr] from[dbo].[Sotr] where[Sotr].[ID_Sotr] = " + Program.login, _PB.Connection);
            Program.NameSotr = NameSotrSQL.ExecuteScalar().ToString();
            _PB.Connection.Close();
        }

       /* public void viv_sotr()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand NameSotrSQL = new SqlCommand("select[dbo].[Sotr].[Im_Sotr]as 'Имя сотрудника', [dbo].[Sotr].[Otch_Sotr] as 'Отчество сотрудника', [dbo].[Sotr].[Fam_Sotr] as 'Фамилия сотрудника',[dbo].[Dolj].[Nazv_Dolj] as 'Название должности', [dbo].[Sotr].[Login_Sotr] as 'Логин сотрудника',[dbo].[Sotr].[Password_Sotr] as 'Пароль сотрудника' from[dbo].[Sotr] inner join[dbo].[Dolj] on[dbo].[Dolj].[id_Dolj]=[dbo].[Sotr].[Dolj_id] ",_PB.Connection);
            SqlDataReader TableReader = NameSotrSQL.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.NameSotr = Table;
            _PB.Connection.Close();
        }*/
        public void accss_for_sotr()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand AccessAddSQL = new SqlCommand("select top 1 ID_access from Access_level  order by ID_access desc", _PB.Connection);
            Program.ID_Access = Convert.ToInt32(AccessAddSQL.ExecuteScalar().ToString());
            _PB.Connection.Close();
        }
    }
}
