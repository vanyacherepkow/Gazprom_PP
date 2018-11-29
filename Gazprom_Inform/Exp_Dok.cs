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

namespace Gazprom_Inform
{
    public partial class Exp_Dok : Form
    {
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

        }

        private void выходВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Menu = new Main_Menu();
            Menu.Show();
        }
    }
}
