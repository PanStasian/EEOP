namespace Collinear_Analysis
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.matr = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.analysisTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Collinear = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.Fishers_Tb = new System.Windows.Forms.TextBox();
            this.StudentAnalysisTb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Partial = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FisherTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.StudentTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Student = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.InverseMatrix = new System.Windows.Forms.DataGridView();
            this.CompareXi = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.XiTable_Tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Xi_Tb = new System.Windows.Forms.TextBox();
            this.Det_Tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.normDt = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.formula_Tb = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.CoefReg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.matr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Collinear.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Partial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InverseMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normDt)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoefReg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(357, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Кореляционная матрица";
            // 
            // matr
            // 
            this.matr.AllowUserToAddRows = false;
            this.matr.AllowUserToDeleteRows = false;
            this.matr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matr.Location = new System.Drawing.Point(8, 480);
            this.matr.MultiSelect = false;
            this.matr.Name = "matr";
            this.matr.ReadOnly = true;
            this.matr.RowTemplate.Height = 24;
            this.matr.Size = new System.Drawing.Size(908, 214);
            this.matr.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(1220, 677);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 26);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // analysisTb
            // 
            this.analysisTb.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisTb.Location = new System.Drawing.Point(953, 103);
            this.analysisTb.Multiline = true;
            this.analysisTb.Name = "analysisTb";
            this.analysisTb.Size = new System.Drawing.Size(411, 258);
            this.analysisTb.TabIndex = 8;
            this.analysisTb.TextChanged += new System.EventHandler(this.analysisTb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1140, 677);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "По шкале Чеддока";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1090, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Анализ данных";
            // 
            // dt
            // 
            this.dt.AllowUserToAddRows = false;
            this.dt.AllowUserToDeleteRows = false;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Location = new System.Drawing.Point(8, 39);
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.RowTemplate.Height = 24;
            this.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dt.ShowEditingIcon = false;
            this.dt.Size = new System.Drawing.Size(908, 400);
            this.dt.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 27);
            this.textBox1.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Collinear);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1390, 742);
            this.tabControl1.TabIndex = 14;
            // 
            // Collinear
            // 
            this.Collinear.BackgroundImage = global::Collinear_Analysis.Properties.Resources.blank_charts_computer_669619;
            this.Collinear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Collinear.Controls.Add(this.button5);
            this.Collinear.Controls.Add(this.dt);
            this.Collinear.Controls.Add(this.button2);
            this.Collinear.Controls.Add(this.label1);
            this.Collinear.Controls.Add(this.button1);
            this.Collinear.Controls.Add(this.matr);
            this.Collinear.Controls.Add(this.textBox1);
            this.Collinear.Controls.Add(this.textBox2);
            this.Collinear.Controls.Add(this.label2);
            this.Collinear.Controls.Add(this.analysisTb);
            this.Collinear.Controls.Add(this.label3);
            this.Collinear.Location = new System.Drawing.Point(4, 29);
            this.Collinear.Name = "Collinear";
            this.Collinear.Padding = new System.Windows.Forms.Padding(3);
            this.Collinear.Size = new System.Drawing.Size(1382, 709);
            this.Collinear.TabIndex = 0;
            this.Collinear.Text = "Коллинеарный анализ";
            this.Collinear.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.BackgroundImage = global::Collinear_Analysis.Properties.Resources.kisspng_computer_icons_floppy_disk_download_save_button_5acb8065243182_0758787915232861171483;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Cursor = System.Windows.Forms.Cursors.Default;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(8, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(36, 31);
            this.button5.TabIndex = 14;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::Collinear_Analysis.Properties.Resources.circled_play1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(361, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 41);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Collinear_Analysis.Properties.Resources.w256h2561372348486openfile256;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(50, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 32);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::Collinear_Analysis.Properties.Resources.blank_charts_computer_669619;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.Fishers_Tb);
            this.tabPage2.Controls.Add(this.StudentAnalysisTb);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.Partial);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.FisherTB);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.StudentTb);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.Student);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.InverseMatrix);
            this.tabPage2.Controls.Add(this.CompareXi);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.XiTable_Tb);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.Xi_Tb);
            this.tabPage2.Controls.Add(this.Det_Tb);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.normDt);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1382, 709);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мультиколлинеарный анализ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.BackgroundImage = global::Collinear_Analysis.Properties.Resources.kisspng_computer_icons_floppy_disk_download_save_button_5acb8065243182_0758787915232861171483;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Cursor = System.Windows.Forms.Cursors.Default;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(8, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 30);
            this.button7.TabIndex = 32;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Fishers_Tb
            // 
            this.Fishers_Tb.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fishers_Tb.Location = new System.Drawing.Point(982, 186);
            this.Fishers_Tb.Multiline = true;
            this.Fishers_Tb.Name = "Fishers_Tb";
            this.Fishers_Tb.Size = new System.Drawing.Size(380, 276);
            this.Fishers_Tb.TabIndex = 31;
            // 
            // StudentAnalysisTb
            // 
            this.StudentAnalysisTb.Location = new System.Drawing.Point(1372, 630);
            this.StudentAnalysisTb.Multiline = true;
            this.StudentAnalysisTb.Name = "StudentAnalysisTb";
            this.StudentAnalysisTb.Size = new System.Drawing.Size(14, 13);
            this.StudentAnalysisTb.TabIndex = 31;
            this.StudentAnalysisTb.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(507, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(407, 27);
            this.label13.TabIndex = 30;
            this.label13.Text = "Частичные коэффициенты корелляции";
            // 
            // Partial
            // 
            this.Partial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Partial.Location = new System.Drawing.Point(421, 266);
            this.Partial.Name = "Partial";
            this.Partial.RowTemplate.Height = 24;
            this.Partial.Size = new System.Drawing.Size(553, 178);
            this.Partial.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(977, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 27);
            this.label12.TabIndex = 28;
            this.label12.Text = "F-критерии";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(985, 465);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(341, 27);
            this.label11.TabIndex = 17;
            this.label11.Text = "Табличное значение F-критерия";
            // 
            // FisherTB
            // 
            this.FisherTB.Location = new System.Drawing.Point(990, 493);
            this.FisherTB.Name = "FisherTB";
            this.FisherTB.Size = new System.Drawing.Size(115, 27);
            this.FisherTB.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(980, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(337, 27);
            this.label10.TabIndex = 15;
            this.label10.Text = "Табличное значение t-критерия";
            // 
            // StudentTb
            // 
            this.StudentTb.Location = new System.Drawing.Point(990, 582);
            this.StudentTb.Name = "StudentTb";
            this.StudentTb.Size = new System.Drawing.Size(115, 27);
            this.StudentTb.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(607, 465);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 27);
            this.label9.TabIndex = 13;
            this.label9.Text = "Расчет t-критериев";
            // 
            // Student
            // 
            this.Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Student.Location = new System.Drawing.Point(421, 493);
            this.Student.Name = "Student";
            this.Student.RowTemplate.Height = 24;
            this.Student.Size = new System.Drawing.Size(553, 213);
            this.Student.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(607, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 27);
            this.label8.TabIndex = 11;
            this.label8.Text = "Обратная матрица";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // InverseMatrix
            // 
            this.InverseMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InverseMatrix.Location = new System.Drawing.Point(421, 39);
            this.InverseMatrix.Name = "InverseMatrix";
            this.InverseMatrix.RowTemplate.Height = 24;
            this.InverseMatrix.Size = new System.Drawing.Size(553, 178);
            this.InverseMatrix.TabIndex = 10;
            // 
            // CompareXi
            // 
            this.CompareXi.AutoSize = true;
            this.CompareXi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompareXi.Location = new System.Drawing.Point(749, 38);
            this.CompareXi.Name = "CompareXi";
            this.CompareXi.Size = new System.Drawing.Size(0, 25);
            this.CompareXi.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(984, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Табличное значениеXi";
            // 
            // XiTable_Tb
            // 
            this.XiTable_Tb.Location = new System.Drawing.Point(1262, 115);
            this.XiTable_Tb.Name = "XiTable_Tb";
            this.XiTable_Tb.Size = new System.Drawing.Size(100, 27);
            this.XiTable_Tb.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(984, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 27);
            this.label6.TabIndex = 6;
            this.label6.Text = "Вычисление критерия Xi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(967, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(409, 27);
            this.label5.TabIndex = 5;
            this.label5.Text = "Детерминант кореляционной матрицы";
            // 
            // Xi_Tb
            // 
            this.Xi_Tb.Location = new System.Drawing.Point(1262, 82);
            this.Xi_Tb.Name = "Xi_Tb";
            this.Xi_Tb.Size = new System.Drawing.Size(100, 27);
            this.Xi_Tb.TabIndex = 4;
            // 
            // Det_Tb
            // 
            this.Det_Tb.Location = new System.Drawing.Point(982, 39);
            this.Det_Tb.Name = "Det_Tb";
            this.Det_Tb.Size = new System.Drawing.Size(382, 27);
            this.Det_Tb.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(49, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Нормализованная матрица";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // normDt
            // 
            this.normDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.normDt.Location = new System.Drawing.Point(8, 35);
            this.normDt.Name = "normDt";
            this.normDt.RowTemplate.Height = 24;
            this.normDt.Size = new System.Drawing.Size(407, 670);
            this.normDt.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::Collinear_Analysis.Properties.Resources.circled_play;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(370, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 32);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::Collinear_Analysis.Properties.Resources.blank_charts_computer_669619;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.formula_Tb);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.CoefReg);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1382, 709);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Регресионный анализ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::Collinear_Analysis.Properties.Resources.kisspng_computer_icons_floppy_disk_download_save_button_5acb8065243182_0758787915232861171483;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Cursor = System.Windows.Forms.Cursors.Default;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(716, 27);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 44);
            this.button6.TabIndex = 15;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // formula_Tb
            // 
            this.formula_Tb.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formula_Tb.Location = new System.Drawing.Point(34, 390);
            this.formula_Tb.Multiline = true;
            this.formula_Tb.Name = "formula_Tb";
            this.formula_Tb.Size = new System.Drawing.Size(1298, 88);
            this.formula_Tb.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::Collinear_Analysis.Properties.Resources.circled_play1;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(605, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 44);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CoefReg
            // 
            this.CoefReg.BackgroundColor = System.Drawing.Color.MintCream;
            this.CoefReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoefReg.Location = new System.Drawing.Point(529, 77);
            this.CoefReg.Name = "CoefReg";
            this.CoefReg.RowTemplate.Height = 24;
            this.CoefReg.Size = new System.Drawing.Size(333, 250);
            this.CoefReg.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 742);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Multicol ";
            ((System.ComponentModel.ISupportInitialize)(this.matr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Collinear.ResumeLayout(false);
            this.Collinear.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Partial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InverseMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normDt)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoefReg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView matr;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox analysisTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Collinear;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView normDt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Xi_Tb;
        private System.Windows.Forms.TextBox Det_Tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox XiTable_Tb;
        private System.Windows.Forms.Label CompareXi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView InverseMatrix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView Student;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox FisherTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox StudentTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView Partial;
        private System.Windows.Forms.TextBox StudentAnalysisTb;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView CoefReg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Fishers_Tb;
        private System.Windows.Forms.TextBox formula_Tb;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

