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
            SqlCommand NameSotrSQL= new SqlCommand ("select concat(Fam_Sotr,' ', Im_Sotr) from[dbo].[Sotr] where[Sotr].[ID_Sotr] = " + Program.login, _PB.Connection);
            Program.NameSotr = NameSotrSQL.ExecuteScalar().ToString();
            _PB.Connection.Close();
        }

        public void viv_sotr()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand NameSotrSQL = new SqlCommand("select [dbo].[Sotr].[ID_Sotr], [dbo].[Sotr].[Im_Sotr]as 'Имя сотрудника', [dbo].[Sotr].[Otch_Sotr] as 'Отчество сотрудника', [dbo].[Sotr].[Fam_Sotr] as 'Фамилия сотрудника', [dbo].[Sotr].[Login_Sotr] as 'Логин сотрудника',[dbo].[Sotr].[Password_Sotr] as 'Пароль сотрудника',[dbo].[Dolj].[Nazv_Dolj] as 'Название должности',[dbo].[Sotr].[Access_id] as 'Номер доступа' from[dbo].[Sotr] inner join[dbo].[Dolj] on[dbo].[Dolj].[id_Dolj]=[dbo].[Sotr].[Dolj_id] inner join [dbo].[Access_Level] on [dbo].[Access_Level].[ID_access]=[dbo].[Sotr].[Access_id] ", _PB.Connection);
            SqlDataReader TableReader = NameSotrSQL.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.SpisSotr = Table;
            _PB.Connection.Close();
        }
        public void accss_for_sotr()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand AccessAddSQL = new SqlCommand("select top 1 ID_access from Access_level  order by ID_access desc", _PB.Connection);
            Program.ID_Access = Convert.ToInt32(AccessAddSQL.ExecuteScalar().ToString());
            _PB.Connection.Close();
        }
        public void Ish_dok_viv()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand ish_dok = new SqlCommand("select ID_ish_dok, concat(Fam_Sotr,' ',Im_Sotr) as 'Сотрудник, котоырй отвечает за документ', Year_dok_do_obr as 'Год документа', Date_zagr_dok as 'Дата загрузки документа', Ish_file_way as 'Путь документа',Folder_dok_way as 'Папка документов', sotr_id_v_ish_dok   from Ish_dok inner join Sotr on Sotr_id_v_ish_dok=ID_Sotr", _PB.Connection);
            SqlDataReader TableReader = ish_dok.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.IshDok = Table;
            _PB.Connection.Close();
        }

        public void Got_dok_viv()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand got_dok = new SqlCommand("select  ID_got_dok ,Nazv_got_dok as 'Название документа',concat(Fam_Sotr,' ',Im_Sotr) as 'Фамилия и имя работника',Data_sozdan as 'Дата создание документа',Got_File_way as 'Путь документа'  from sotr inner join Got_dok on [sotr].[ID_Sotr]=Got_dok.Sotr_ID_v_got_dok", _PB.Connection);
            SqlDataReader TableReader = got_dok.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.GotDok = Table;
            _PB.Connection.Close();
        }
        public void Otch_viv()
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand otchet = new SqlCommand("select ID_Otchet as 'Номер документа', Year_dok as 'Год документа', Kol_vo_file as 'Количество страниц', Kol_vo_dok as 'Количество файлов', Data_otchet as 'Дата создания отчёта', concat(Fam_Sotr,' ',Im_Sotr)as 'Сотрудник' from Otchet inner join Sotr on ID_Sotr = Sotr_id_v_otch", _PB.Connection);
            SqlDataReader TableReader = otchet.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(TableReader);
            Program.Otchet = Table;
            _PB.Connection.Close();
        }
    }
}
