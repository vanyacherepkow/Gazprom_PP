using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Crypt;

namespace Gazprom_Inform
{
    public partial class Autorization : Form
    {
        public Crypt_Class Crpt = new Crypt_Class();
        Podkl_bazi _PB = new Podkl_bazi();
        User_Settings _US = new User_Settings();
        public string Admin_access = "select[dbo].[Access_level].[Admin_access] from[dbo].[Access_level] inner join [dbo].[Sotr] on[dbo].[Sotr].[access_id]=[dbo].[Access_level].[Id_access] where [Sotr].[id_Sotr]=";

        public Autorization()
        {
            InitializeComponent();
        }

        public void auto( string Login_BD, string Password_BD)
        {
            try
            {
                
                _PB.Set_Connection();
                SqlCommand get_login =  new SqlCommand("select id_Sotr from Sotr where Login_Sotr ='" + Crpt.code_text(textBox1.Text) + "'and Password_Sotr = '" + Crpt.code_text(textBox2.Text) + "'", _PB.Connection);
                _PB.Connection.Open();
                SqlDataReader read_login = get_login.ExecuteReader();
                if (read_login.HasRows == true)
                {
                    read_login.Close();
                    MessageBox.Show("Вы успешно вошли в систему", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.login = get_login.ExecuteScalar().ToString();
                    SqlCommand AdminAccessCmd = new SqlCommand(Admin_access + Program.login, _PB.Connection);
                    Program.Admin_access = Convert.ToInt32(AdminAccessCmd.ExecuteScalar().ToString());
                    _PB.Connection.Close();
                    Main_Menu main_form = new Main_Menu();
                    this.Close();
                    main_form.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь с такими данными не найден в системе.\nПовторите попытку ввода.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
             _PB.Set_Connection();
             auto(textBox1.Text,textBox2.Text);
             _PB.Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string Crypt;
            _PB.Set_Connection();
            SqlCommand Crypt = new SqlCommand("select "+Crpt.de_code_text("Login_Sotr")+" from Sotr where ID_Sotr = 8", _PB.Connection);
           _PB.Connection.Open();
            SqlDataReader read_login = Crypt.ExecuteReader();
            //Crypt=Crpt.ExecuteScalar().ToString();
            _PB.Connection.Close();
            MessageBox.Show(read_login.ToString());
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            _US.Select_Color_get();
            color_setting();
        }
        public void color_setting()
        {
            int i;
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            statusStrip1.ForeColor = Color.FromName(Program.ForeColor);
            Button[] Buttons = new Button[] { button1, button2, };
            for (i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].BackColor = Color.FromName(Program.BackColor);
                Buttons[i].ForeColor = Color.FromName(Program.ForeColor);
            }
            Label[] Labels = new Label[] { label1, label2, label3,  };
            for (i = 0; i < Labels.Length; i++)
            {
                Labels[i].BackColor = Color.FromName(Program.BackColor);
                Labels[i].ForeColor = Color.FromName(Program.ForeColor);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Convert.ToString(DateTime.Now);
        }
    }   
    }

