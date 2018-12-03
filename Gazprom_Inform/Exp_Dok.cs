using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Gazprom_Inform
{
    public partial class Exp_Dok : Form
    {
        User_Settings _US = new User_Settings();
        Podkl_bazi _PB = new Podkl_bazi();
        Rabota_s_bazoi _RSB = new Rabota_s_bazoi();
        public Exp_Dok()
        {
            InitializeComponent();
        }


        public void spis_dok()
        {
            //string[] files = Directory.GetFiles();
            //files = Directory.GetFiles(dirName, @".\docx$");
        }
        private void Exp_Dok_Load(object sender, EventArgs e)
        {
            exp_dok_load();
        }

        public void exp_dok_load()
        {
            _US.Select_Color_get();
            color_setting();
            пользовательToolStripMenuItem.Text = "Пользователь - " + Program.NameSotr;
            _PB.Set_Connection();
            SqlCommand sss = new SqlCommand("select concat(Fam_Sotr,' ', Im_Sotr) from Sotr", _PB.Connection);
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
            _RSB.Got_dok_viv();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Program.GotDok;
            dataGridView1.Columns[0].Visible = false;
        }

        public void color_setting()
        {
            int i;
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button2, button1 };
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
            выходВМенюToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            выходВМенюToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            тёмнаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            тёмнаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            светлаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            светлаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            Label[] Labels = new Label[] { label1, label2, label4 };
            for (i = 0; i < Labels.Length; i++)
            {
                Labels[i].BackColor = Color.FromName(Program.BackColor);
                Labels[i].ForeColor = Color.FromName(Program.ForeColor);
            }
        }

        private void выходВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Menu = new Main_Menu();
            Menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _PB.Set_Connection();
            _PB.Connection.Open();
            SqlCommand Got_dok_add = new SqlCommand("insert into [dbo].[Got_dok] (sotr_id_v_got_dok, Data_sozdan, Nazv_got_dok, Got_File_way) values (@sotr_id_v_got_dok, @Data_sozdan, @Nazv_got_dok, @Got_File_way)", _PB.Connection);
            Got_dok_add.Parameters.AddWithValue("@sotr_id_v_got_dok", (comboBox1.SelectedIndex+1));
            Got_dok_add.Parameters.AddWithValue("@Data_Sozdan", DateTime.Now );
            Got_dok_add.Parameters.AddWithValue("@Nazv_got_dok", textBox1.Text);
            Got_dok_add.Parameters.AddWithValue("@Got_file_way", textBox2.Text);
            Got_dok_add.ExecuteNonQuery();
            _PB.Connection.Close();
            exp_dok_load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
                textBox2.Text = dialog.FileName;
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Convert.ToString(DateTime.Now);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Otchet Form = new Otchet();
            Form.Show();
        }

        private void светлаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_light();
            color_setting();
        }

        private void тёмнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
