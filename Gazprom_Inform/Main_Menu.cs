using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazprom_Inform
{
    public partial class Main_Menu : Form
    {
        Rabota_s_bazoi _RSB = new Rabota_s_bazoi();
        User_Settings _US = new User_Settings();
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            _RSB.viv_im_sotr();
            пользовательToolStripMenuItem.Text= "Пользователь - " + Program.NameSotr;
            _US.Select_Color_get();
            color_setting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Sotrudniki Form = new Sotrudniki();
            Form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Convert.ToString(DateTime.Now);
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.NameSotr = "";
            Program.Admin_access = 0; 
            Autorization Auto = new Autorization();
            Auto.Show();
        }

        private void тёмнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_dark();
            color_setting();
        }

        private void светлаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_light();
            color_setting();
        }
        public void color_setting()
        {
            int i;
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button1, button2, button3, button4 };
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
            сменитьПользователяToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            сменитьПользователяToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            тёмнаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            тёмнаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
            светлаяТемаToolStripMenuItem.BackColor = Color.FromName(Program.BackColor);
            светлаяТемаToolStripMenuItem.ForeColor = Color.FromName(Program.ForeColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Imp_Dok Form = new Imp_Dok();
            Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Exp_Dok Form = new Exp_Dok();
            Form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Otchet Form = new Otchet();
            Form.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
