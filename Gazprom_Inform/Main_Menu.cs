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
            int i;
            _US.Select_Color_set_dark();
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button1, button2, button3 };
            for (i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].BackColor = Color.FromName(Program.BackColor);
                Buttons[i].ForeColor = Color.FromName(Program.ForeColor);
            }
            menuStrip1.BackColor = Color.FromName(Program.BackColor);
            menuStrip1.ForeColor = Color.FromName(Program.ForeColor);
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            statusStrip1.ForeColor = Color.FromName(Program.ForeColor);
        }

        private void светлаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            _US.Select_Color_set_light();
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button1, button2, button3 };
            for (i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].BackColor = Color.FromName(Program.BackColor);
                Buttons[i].ForeColor = Color.FromName(Program.ForeColor);
            }
            menuStrip1.BackColor = Color.FromName(Program.BackColor);
            menuStrip1.ForeColor = Color.FromName(Program.ForeColor);
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            statusStrip1.ForeColor = Color.FromName(Program.ForeColor);
        }
    }
}
