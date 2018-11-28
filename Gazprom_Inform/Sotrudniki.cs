﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Gazprom_Inform
{
    public partial class Sotrudniki : Form
    { 
        Rabota_s_bazoi _RSB = new Rabota_s_bazoi();
        Podkl_bazi _PB = new Podkl_bazi();
        User_Settings _US = new User_Settings();
        int Ish_dok;
        int Got_dok;
        int Otch_dok;
        int Spis_Sotr;
        int Admin;
        public Sotrudniki()
        {
            InitializeComponent();
        }
        public void sotrudniki_load()
        {
            _US.Select_Color_get();
            toolStripStatusLabel1.Text = Convert.ToString(DateTime.Now);
            try
            {
                _PB.Set_Connection();
                SqlCommand sss = new SqlCommand("select [nazv_Dolj] from [dbo].[Dolj]", _PB.Connection);
                _PB.Connection.Open();
                SqlDataReader dr = sss.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                foreach (DataRow r in dt.Rows)
                {
                    comboBox1.Items.Add(r[0]);
                }
                _PB.Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Program.Admin_access == 1)
            {
                _PB.Set_Connection();
                _PB.Connection.Open();
                _RSB.viv_sotr();
                dataGridView1.DataSource = Program.SpisSotr;
                groupBox1.Visible = true;
                _PB.Connection.Close();

            }
            else
            {
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
        }

        private void Sotrudniki_Load(object sender, EventArgs e)
        {
            sotrudniki_load();
            color_setting();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _RSB.accss_for_sotr();
            if (checkBox1.Checked)
            {
                Ish_dok = 1;
            }
            else
            {
                Ish_dok = 0;
            }
            if (checkBox2.Checked)
            {
                Got_dok = 1;
            }
            else
            {
                Got_dok = 0;
            }
            if (checkBox3.Checked)
            {
                Otch_dok = 1;
            }
            else
            {
                Otch_dok = 0;
            }
            if (checkBox4.Checked)
            {
                Spis_Sotr = 1;
            }
            else
            {
                Spis_Sotr = 0;
            }
            if (checkBox5.Checked)
            {
                Admin = 1;
            }
            else
            {
                Admin = 0;
            }
            dostup(Ish_dok, Got_dok, Otch_dok, Spis_Sotr, Admin);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            _PB.Connection.Close();
            MessageBox.Show("Права досутпа для пользователя созданы, номер доступ - "+(Program.ID_Access+1).ToString());
        }

        public void registration(string Fam_Sotr, string Im_Sotr, string Otch_Sotr, string Login_Sotr, string Password_Sotr, int Dolj_id, int Access_ID)
        {
            
        }

        public void dostup (int Ish_dok_access ,int Got_dok_access, int Otch_dok_access,int Spis_Sotr_access , int Admin_Access)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            _RSB.accss_for_sotr();
            SqlCommand access_add = new SqlCommand("access_add", _PB.Connection);
            access_add.CommandType = CommandType.StoredProcedure;
            access_add.Parameters.AddWithValue("@Ish_dok_access", Ish_dok_access);
            access_add.Parameters.AddWithValue("@Got_dok_access", Got_dok_access);
            access_add.Parameters.AddWithValue("@Otch_dok_access",Otch_dok_access);
            access_add.Parameters.AddWithValue("@Spis_Sotr_access", Spis_Sotr_access);
            access_add.Parameters.AddWithValue("@Admin_Access", Admin_Access);
            access_add.ExecuteNonQuery();
            _PB.Connection.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox5.Text == textBox6.Text)
            {
                _PB.Set_Connection();
                _PB.Connection.Open();
                SqlCommand reg_add = new SqlCommand("Sotr_add", _PB.Connection);
                reg_add.CommandType = CommandType.StoredProcedure;
                reg_add.Parameters.AddWithValue("@Fam_Sotr", textBox1.Text);
                reg_add.Parameters.AddWithValue("@Im_Sotr", textBox2.Text);
                reg_add.Parameters.AddWithValue("@Otch_Sotr", textBox3.Text);
                reg_add.Parameters.AddWithValue("@Login_Sotr", textBox4.Text);
                reg_add.Parameters.AddWithValue("@Password", textBox5.Text);
                reg_add.Parameters.AddWithValue("@Dolj_ID", (comboBox1.SelectedIndex+1));
                reg_add.Parameters.AddWithValue("@Access_id", (Program.ID_Access+1));
                reg_add.ExecuteNonQuery();
                _PB.Connection.Close();
                Program.ID_Access = 0;
                MessageBox.Show("Пользователь успешно добавлен");
                sotrudniki_load();
            }
            else
            {
                MessageBox.Show("Введённые пароли не совпадают");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void тёмнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_dark();
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
        }

        private void светлаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_light();
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
        }

        private void вернутьсяВГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Menu = new Main_Menu();
            Menu.Show();
        }
        public void color_setting()
        {
            int i;
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button1, button2, button3};
            for (i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].BackColor = Color.FromName(Program.BackColor);
                Buttons[i].ForeColor = Color.FromName(Program.ForeColor);
            }
            menuStrip1.BackColor = Color.FromName(Program.BackColor);
            menuStrip1.ForeColor = Color.FromName(Program.ForeColor);
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            statusStrip1.ForeColor = Color.FromName(Program.ForeColor);
            пользовательToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            пользовательToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            вернутьсяВГлавноеМенюToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            вернутьсяВГлавноеМенюToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            сменитьТемуToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            сменитьТемуToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            тёмнаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            тёмнаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            светлаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            светлаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            groupBox1.BackColor = Color.FromName(Program.BackColor);
            groupBox1.ForeColor = Color.FromName(Program.ForeColor);
            Label[] Labels = new Label[] { label1, label2, label3, label4, label5, label6, label7, };
            for (i = 0; i < Labels.Length; i++)
            {
                Labels[i].BackColor = Color.FromName(Program.BackColor);
                Labels[i].ForeColor = Color.FromName(Program.ForeColor);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //_PB.Set_Connection();
            //_PB.Connection.Open();
            //SqlCommand add_dolj = new SqlCommand("Select nazv_dolj from dolj where nazv_dolj='", _PB.Connection);
            //add_dolj.ExecuteScalar().ToString();
            //if (add_dolj.ToString()=textBox7.Text)
            //    {
            //    MessageBox.Show("Данная должность уже присутствует");
            //}
            //else
            //{
            //    SqlCommand Dolj_add = new SqlCommand("insert into [dbo].[dolj]([nazv_dolj]) values (@Nazv_Dolj)", _PB.Connection);
            //    Dolj_add.Parameters.AddWithValue("Nazv_Dolj", textBox7.Text);
            //    Dolj_add.ExecuteNonQuery();
            //    _PB.Connection.Close();
            //    MessageBox.Show("Должность добавлена");
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand Dolj_add = new SqlCommand("insert into [dbo].[dolj]([nazv_dolj]) values (@Nazv_Dolj)", _PB.Connection);
            Dolj_add.Parameters.AddWithValue("Nazv_Dolj", textBox7.Text);
            Dolj_add.ExecuteNonQuery();
            _PB.Connection.Close();
            MessageBox.Show("Должность добавлена");
                //}
            }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
