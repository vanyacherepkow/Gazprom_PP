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

namespace Gazprom_Inform
{
    public partial class Otchet : Form
    {
        int files;
        int author;
        int year;
        int paths;
        User_Settings _US = new User_Settings();
        Podkl_bazi _PB = new Podkl_bazi();
        Rabota_s_bazoi _RSB = new Rabota_s_bazoi();
        public Otchet()
        {
            InitializeComponent();
        }
        public void otchet_load()
        {
            _US.Select_Color_get();
            пользовательToolStripMenuItem.Text = "Пользователь - " + Program.NameSotr;
            _RSB.Otch_viv();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = Program.Otchet;
            _PB.Connection.Close();
            color_setting();
        }

        public void color_setting()
        {
            int i;
            statusStrip1.BackColor = Color.FromName(Program.BackColor);
            this.BackColor = Color.FromName(Program.BackColor);
            Button[] Buttons = new Button[] { button1, button2,button3, button4 };
            for (i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].BackColor = Color.FromName(Program.BackColor);
                Buttons[i].ForeColor = Color.FromName(Program.ForeColor);
            }
            menuStrip1.BackColor = Color.FromName(Program.BackColor);
            menuStrip1.ForeColor = Color.FromName(Program.ForeColor);
            radioButton1.BackColor = Color.FromName(Program.BackColor);
            radioButton1.ForeColor = Color.FromName(Program.ForeColor);
            radioButton2.BackColor = Color.FromName(Program.BackColor);
            radioButton2.ForeColor = Color.FromName(Program.ForeColor);
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
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            _PB.Set_Connection();
            _PB.Connection.Open();
            _RSB.Got_dok_viv();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Program.GotDok;
            dataGridView1.Columns[0].Visible = false;
            _PB.Connection.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            _PB.Set_Connection();
            _PB.Connection.Open();
            _RSB.Ish_dok_viv();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Program.IshDok;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            _PB.Connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Convert.ToString(DateTime.Now);
        }

        private void светлаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_light();
            color_setting();
        }

        private void вернутьсяВГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Menu Form = new Main_Menu();
            Form.Show();
        }

        private void тёмнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _US.Select_Color_set_dark();
            color_setting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                _PB.Set_Connection();
                _PB.Connection.Open();
                SqlCommand sum_dok = new SqlCommand("select count(Folder_dok_way) from [dbo].[Ish_dok] where Folder_dok_way='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'", _PB.Connection);
                SqlCommand auth_dok = new SqlCommand("select Sotr_id_v_ish_dok from [dbo].[Ish_dok] where Sotr_id_v_ish_dok ='" + dataGridView1.CurrentRow.Cells[6].Value.ToString() + "'", _PB.Connection);
                SqlCommand year_dok = new SqlCommand("select year_dok_do_obr from [dbo].[Ish_dok] where year_dok_do_obr ='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", _PB.Connection);
                author = Convert.ToInt32(auth_dok.ExecuteScalar().ToString());
                files = Convert.ToInt32(sum_dok.ExecuteScalar().ToString());
                year = Convert.ToInt32(year_dok.ExecuteScalar().ToString());
                MessageBox.Show("Количество страниц - " + files.ToString());
                _PB.Connection.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                _PB.Set_Connection();
                _PB.Connection.Open();
                SqlCommand sum_dok = new SqlCommand("select count(Got_File_way) from [dbo].[Got_dok] where Got_File_way='" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "'", _PB.Connection);
                paths = Convert.ToInt32(sum_dok.ExecuteScalar().ToString());
                MessageBox.Show("Количество файлов - " + paths.ToString());
                _PB.Connection.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
                _PB.Set_Connection();
                _PB.Connection.Open();
                SqlCommand otchet_add = new SqlCommand("otchet_add", _PB.Connection);
                otchet_add.CommandType = CommandType.StoredProcedure;
                otchet_add.Parameters.AddWithValue("@Year_dok", year);
                otchet_add.Parameters.AddWithValue("@Kol_vo_file", paths);
                otchet_add.Parameters.AddWithValue("@Kol_vo_dok", files);
                otchet_add.Parameters.AddWithValue("@Data_otchet", DateTime.Now);
                otchet_add.Parameters.AddWithValue("@Sotr_id_v_otch", author);
                otchet_add.ExecuteNonQuery();
                _PB.Connection.Close();
                _RSB.Otch_viv();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.DataSource = Program.Otchet;
                _PB.Connection.Close();
                files = 0;
                year = 0;
                author = 0;
                paths = 0;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга. 
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
           //Таблица. 
           ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                }
            }
            //Вызываем нашу созданную эксельку. 
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;*/
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application(); // Объявление переменной как эксель 
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook; // Объявление переменной как книга 
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet; // Объявление переменной как лист 

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value); //Создание книги 

            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1); //Создание лист 

            for (int i = 0; i < dataGridView2.Rows.Count; i++) // Условие пока количество строк в datagridview1 больше чем переменная i то выполняется действие 
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++) // Условие пока количество колонок в datagridview1 больше чем переменная j то выполняется действие 
                {
                    ExcelApp.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value; // Добавление ячеек в документе эксель 
                }
            }

            string name = String.Format("{0}.{1}.{2} {3}.{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute); // Объявление переменной даты и времени 

            ExcelApp.Visible = true; // Делаем видимым эксель 
            ExcelApp.DisplayAlerts = false; // Отключаем уведомление при закрытии 

            ExcelWorkSheet.Name = "Технические неисправности"; // Присвоение значения 
            ExcelApp.Cells[1, 1] = dataGridView2.Columns[0].HeaderCell.Value; // Присвоение значения 
            ExcelApp.Cells[1, 2] = dataGridView2.Columns[1].HeaderCell.Value; // Присвоение значения 
            ExcelApp.Cells[1, 3] = dataGridView2.Columns[2].HeaderCell.Value; ; // Присвоение значения 
            ExcelApp.Cells[1, 4] = dataGridView2.Columns[3].HeaderCell.Value; // Присвоение значения 
            ExcelApp.Cells[1, 5] = dataGridView2.Columns[4].HeaderCell.Value; ; // Присвоение значения 
            ExcelApp.Cells[1, 6] = dataGridView2.Columns[5].HeaderCell.Value; ; // Присвоение значения 
            ExcelWorkSheet.Rows.AutoFit(); // Выравнивание строк 
            ExcelWorkSheet.Columns.AutoFit(); // Выравнивание колонок 

            ExcelWorkSheet.Columns.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; // Выравниваем ячейки по горизонтали 
            ExcelWorkSheet.Columns.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; // Выравниваем ячейки по вертикали 

            for (int i = 0; i < dataGridView2.Rows.Count; i++) // Условие пока количество строк в datagridview1 больше чем переменная i то выполняется действие 
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++) // Условие пока количество колонок в datagridview1 больше чем переменная j то выполняется действие 
                {
                    ExcelWorkSheet.Cells[i + 1, j + 1].borders.linestyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; // создаём границы для таблицы 
                    ExcelWorkSheet.Cells[i + 1, j + 1].borders.weight = 3d; // выбираем ширину границы 
                }
            }

            ExcelApp.UserControl = true;

        // Даём доступ на использование эксель документа 

            ExcelApp.Application.ActiveWorkbook.SaveAs("C:\\Users\\ICher\\Desktop" + name + ".xlsx", // Путь сохранения файла 
            Type.Missing, // Формат файла 
            123, // Задаём пароль, который нужно ввести, если снова нужно будет открыть этот документ 
            123, // Задаём пароль, для разрешения на редактирование документа 
            true, // Создание сообщения рекомендации по открытию документа в режиме "Только для чтения" 
            Type.Missing, // Создание backup файла 
            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, // параметры документа 
            Type.Missing, // Параметры сохранения документа 
            Type.Missing, // Добавление книги в лист последних используемых файлов 
            Type.Missing, // Игнорирование всех языков в excel 
            Type.Missing, // Игнорирование всех языков в excel 
            Type.Missing // Параметры языка excel */
            );

        }

        private void Otchet_Load(object sender, EventArgs e)
        {
            otchet_load();
        }
    }
}
