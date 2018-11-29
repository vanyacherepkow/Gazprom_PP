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
using System.IO;

namespace Gazprom_Inform
{
    public partial class Imp_Dok : Form
    {
        Rabota_s_bazoi _RSB = new Rabota_s_bazoi();
        Podkl_bazi _PB = new Podkl_bazi();
        User_Settings _US = new User_Settings();
        public Imp_Dok()
        {
            InitializeComponent();
        }

        private void Imp_Dok_Load(object sender, EventArgs e)
        {
            imp_dok_load();

        }
        public void imp_dok_load()
        {
            пользовательToolStripMenuItem.Text = "Пользователь - " + Program.NameSotr;
            _PB.Set_Connection();
            SqlCommand sss = new SqlCommand("select concat(Fam_Sotr,' ', Im_Sotr) from Sotr where Dolj_ID=2", _PB.Connection);
            _PB.Connection.Open();
            SqlDataReader dr = sss.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow r in dt.Rows)
            {
                comboBox1.Items.Add(r[0]);
            }
            _PB.Connection.Close();
            color_setting();
            _RSB.Ish_dok_viv();
            dataGridView1.DataSource = Program.IshDok;
            dataGridView1.Columns[0].Visible = false;
            _US.Select_Color_get();
        }
        public void color_setting()
        {
            int i;
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button1, button2, button3, button4};
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
            сменитьТемуToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            сменитьТемуToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            вернутьсяВГлавноеМенюToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            вернутьсяВГлавноеМенюToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            тёмнаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            тёмнаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            светлаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            светлаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            Label[] Labels = new Label[] { label1, label2, label3, label4, label5, label6, /*label7,*/ };
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

        private void вернутьсяВГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            Main_Menu Menu = new Main_Menu();
            Menu.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand Imp_dok_add = new SqlCommand("insert into [dbo].[Ish_Dok] (sotr_id_v_ish_dok, year_dok_do_obr, date_zagr_dok, ish_file_way) values (@sotr_id_v_ish_dok, @year_dok_do_obr, @date_zagr_dok, @ish_file_way)", _PB.Connection);
            Imp_dok_add.Parameters.AddWithValue("@sotr_id_v_ish_dok", (comboBox1.SelectedIndex+1));
            Imp_dok_add.Parameters.AddWithValue("@year_dok_do_obr", textBox1.Text);
            Imp_dok_add.Parameters.AddWithValue("@date_zagr_dok", dateTimePicker1.Value);
            Imp_dok_add.Parameters.AddWithValue("@ish_file_way", textBox2.Text);
            Imp_dok_add.ExecuteNonQuery();
            _PB.Connection.Close();
            MessageBox.Show("Документ успешно добавленн в базу");
            imp_dok_load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*var Directory = new DirectoryInfo();
            Directory.CreateDirectory();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                //textBox3.Text = path;
                //string[] files = Directory.GetFiles(path,"*.docx");
                //files = Directory.GetFiles(path);
                //listView1.Items.Add(Directory.GetFiles.(folderBrowserDialog1.,"*docx"));
            }
        }
    }
}
