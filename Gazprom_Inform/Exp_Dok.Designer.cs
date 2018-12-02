namespace Gazprom_Inform
{
    partial class Exp_Dok
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьТемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светлаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тёмнаяТемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходВМенюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(507, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(545, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить информацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(607, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Выбрать путь";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Путь файла";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(545, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(231, 20);
            this.textBox2.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Название документа";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(545, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(231, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Сотрудник, который провёл работу";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(545, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пользовательToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пользовательToolStripMenuItem
            // 
            this.пользовательToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменитьТемуToolStripMenuItem,
            this.выходВМенюToolStripMenuItem});
            this.пользовательToolStripMenuItem.Name = "пользовательToolStripMenuItem";
            this.пользовательToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.пользовательToolStripMenuItem.Text = "Пользователь";
            // 
            // сменитьТемуToolStripMenuItem
            // 
            this.сменитьТемуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.светлаяТемаToolStripMenuItem,
            this.тёмнаяТемаToolStripMenuItem});
            this.сменитьТемуToolStripMenuItem.Name = "сменитьТемуToolStripMenuItem";
            this.сменитьТемуToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.сменитьТемуToolStripMenuItem.Text = "Сменить тему";
            // 
            // светлаяТемаToolStripMenuItem
            // 
            this.светлаяТемаToolStripMenuItem.Name = "светлаяТемаToolStripMenuItem";
            this.светлаяТемаToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.светлаяТемаToolStripMenuItem.Text = "Светлая тема";
            // 
            // тёмнаяТемаToolStripMenuItem
            // 
            this.тёмнаяТемаToolStripMenuItem.Name = "тёмнаяТемаToolStripMenuItem";
            this.тёмнаяТемаToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.тёмнаяТемаToolStripMenuItem.Text = "Тёмная тема";
            // 
            // выходВМенюToolStripMenuItem
            // 
            this.выходВМенюToolStripMenuItem.Name = "выходВМенюToolStripMenuItem";
            this.выходВМенюToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.выходВМенюToolStripMenuItem.Text = "Вернуться в главное меню";
            this.выходВМенюToolStripMenuItem.Click += new System.EventHandler(this.выходВМенюToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Exp_Dok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Exp_Dok";
            this.Text = "Экспорт документов";
            this.Load += new System.EventHandler(this.Exp_Dok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьТемуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светлаяТемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тёмнаяТемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходВМенюToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}