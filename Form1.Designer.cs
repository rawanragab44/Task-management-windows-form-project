namespace EvaluationProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            richTextBox2 = new RichTextBox();
            comboBox6 = new ComboBox();
            button1 = new Button();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox6 = new TextBox();
            richTextBox1 = new RichTextBox();
            groupBox2 = new GroupBox();
            label8 = new Label();
            button2 = new Button();
            textBox4 = new TextBox();
            textBox7 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            groupBox3 = new GroupBox();
            button3 = new Button();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            dateTimePicker2 = new DateTimePicker();
            button4 = new Button();
            comboBox5 = new ComboBox();
            button5 = new Button();
            label13 = new Label();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button9 = new Button();
            button10 = new Button();
            groupBox6 = new GroupBox();
            textBox3 = new TextBox();
            button11 = new Button();
            label6 = new Label();
            button12 = new Button();
            comboBox7 = new ComboBox();
            label19 = new Label();
            label20 = new Label();
            button13 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button14 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.InactiveCaption;
            dataGridView1.Location = new Point(489, 530);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1347, 351);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox2);
            groupBox1.Controls.Add(comboBox6);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(16, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(451, 506);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Adding Task";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(182, 75);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(220, 120);
            richTextBox2.TabIndex = 18;
            richTextBox2.Text = "";
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(182, 207);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(220, 33);
            comboBox6.TabIndex = 17;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(148, 395);
            button1.Name = "button1";
            button1.Size = new Size(151, 51);
            button1.TabIndex = 15;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 209);
            label7.Name = "label7";
            label7.Size = new Size(81, 25);
            label7.TabIndex = 16;
            label7.Text = "category";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 330);
            label5.Name = "label5";
            label5.Size = new Size(60, 25);
            label5.TabIndex = 14;
            label5.Text = "Status";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 292);
            label4.Name = "label4";
            label4.Size = new Size(68, 25);
            label4.TabIndex = 13;
            label4.Text = "Priority";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(182, 247);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(220, 31);
            dateTimePicker1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 247);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 12;
            label3.Text = "Due Date";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 83);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 11;
            label2.Text = "Description";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 41);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 10;
            label1.Text = "Title";
            label1.Click += label1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(182, 327);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(220, 33);
            comboBox2.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(182, 288);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 33);
            comboBox1.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(182, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(164, 58);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(220, 31);
            textBox6.TabIndex = 7;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(501, 380);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(425, 45);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Location = new Point(1000, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(441, 189);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete Task";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(67, 61);
            label8.Name = "label8";
            label8.Size = new Size(44, 25);
            label8.TabIndex = 9;
            label8.Text = "Title";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(145, 113);
            button2.Name = "button2";
            button2.Size = new Size(143, 51);
            button2.TabIndex = 8;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(172, 41);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(220, 31);
            textBox4.TabIndex = 18;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(172, 83);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(220, 31);
            textBox7.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(49, 41);
            label9.Name = "label9";
            label9.Size = new Size(0, 25);
            label9.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(49, 50);
            label10.Name = "label10";
            label10.Size = new Size(78, 25);
            label10.TabIndex = 24;
            label10.Text = "Old Title";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(49, 91);
            label11.Name = "label11";
            label11.Size = new Size(84, 25);
            label11.TabIndex = 25;
            label11.Text = "New Title";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(49, 124);
            label12.Name = "label12";
            label12.Size = new Size(0, 25);
            label12.TabIndex = 26;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(comboBox4);
            groupBox3.Controls.Add(comboBox3);
            groupBox3.Controls.Add(dateTimePicker2);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(textBox7);
            groupBox3.Location = new Point(1471, 79);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(441, 361);
            groupBox3.TabIndex = 29;
            groupBox3.TabStop = false;
            groupBox3.Text = "Edit Task";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(169, 276);
            button3.Name = "button3";
            button3.Size = new Size(144, 51);
            button3.TabIndex = 30;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(49, 217);
            label18.Name = "label18";
            label18.Size = new Size(60, 25);
            label18.TabIndex = 35;
            label18.Text = "Status";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(49, 175);
            label17.Name = "label17";
            label17.Size = new Size(68, 25);
            label17.TabIndex = 34;
            label17.Text = "Priority";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(48, 133);
            label16.Name = "label16";
            label16.Size = new Size(87, 25);
            label16.TabIndex = 33;
            label16.Text = "New date";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(172, 208);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(220, 33);
            comboBox4.TabIndex = 31;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(172, 165);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(220, 33);
            comboBox3.TabIndex = 30;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(172, 124);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(220, 31);
            dateTimePicker2.TabIndex = 29;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(970, 376);
            button4.Name = "button4";
            button4.Size = new Size(138, 57);
            button4.TabIndex = 30;
            button4.Text = "Search";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(1087, 453);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(187, 33);
            comboBox5.TabIndex = 31;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.SteelBlue;
            button5.Location = new Point(1134, 379);
            button5.Name = "button5";
            button5.Size = new Size(138, 51);
            button5.TabIndex = 32;
            button5.Text = "clear";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.SteelBlue;
            label13.Location = new Point(501, 140);
            label13.Name = "label13";
            label13.Size = new Size(448, 62);
            label13.TabIndex = 33;
            label13.Text = "Management Tasks";
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.SteelBlue;
            button6.Location = new Point(924, 923);
            button6.Name = "button6";
            button6.Size = new Size(135, 51);
            button6.TabIndex = 34;
            button6.Text = "prev";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ActiveCaption;
            button7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ButtonHighlight;
            button7.Location = new Point(1119, 920);
            button7.Name = "button7";
            button7.Size = new Size(129, 56);
            button7.TabIndex = 35;
            button7.Text = "next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Khaki;
            button8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(1297, 442);
            button8.Name = "button8";
            button8.Size = new Size(144, 48);
            button8.TabIndex = 1;
            button8.Text = "show overDue";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.IndianRed;
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(1223, 293);
            button9.Name = "button9";
            button9.Size = new Size(177, 68);
            button9.TabIndex = 37;
            button9.Text = "Report";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.ForestGreen;
            button10.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = SystemColors.ButtonHighlight;
            button10.Location = new Point(848, 301);
            button10.Name = "button10";
            button10.Size = new Size(177, 51);
            button10.TabIndex = 38;
            button10.Text = "Completion time";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(textBox3);
            groupBox6.Controls.Add(button11);
            groupBox6.Controls.Add(label6);
            groupBox6.Location = new Point(16, 574);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(451, 251);
            groupBox6.TabIndex = 42;
            groupBox6.TabStop = false;
            groupBox6.Text = "Add category";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(182, 83);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(220, 31);
            textBox3.TabIndex = 2;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // button11
            // 
            button11.BackColor = SystemColors.ActiveCaption;
            button11.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.Location = new Point(148, 155);
            button11.Name = "button11";
            button11.Size = new Size(151, 50);
            button11.TabIndex = 1;
            button11.Text = "Add";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 86);
            label6.Name = "label6";
            label6.Size = new Size(84, 25);
            label6.TabIndex = 0;
            label6.Text = "Category";
            // 
            // button12
            // 
            button12.BackColor = Color.AliceBlue;
            button12.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button12.ForeColor = Color.SteelBlue;
            button12.Location = new Point(1292, 380);
            button12.Name = "button12";
            button12.Size = new Size(108, 49);
            button12.TabIndex = 43;
            button12.Text = "Due Date";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(739, 453);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(187, 33);
            comboBox7.TabIndex = 44;
            comboBox7.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.SteelBlue;
            label19.Location = new Point(604, 459);
            label19.Name = "label19";
            label19.Size = new Size(116, 20);
            label19.TabIndex = 45;
            label19.Text = "Filter by priorty";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.SteelBlue;
            label20.Location = new Point(960, 459);
            label20.Name = "label20";
            label20.Size = new Size(108, 20);
            label20.TabIndex = 46;
            label20.Text = "Filter by status";
            // 
            // button13
            // 
            button13.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button13.ForeColor = Color.Brown;
            button13.Location = new Point(1047, 298);
            button13.Name = "button13";
            button13.Size = new Size(170, 63);
            button13.TabIndex = 47;
            button13.Text = "back";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick_1;
            // 
            // button14
            // 
            button14.BackColor = Color.IndianRed;
            button14.ForeColor = Color.White;
            button14.Location = new Point(1813, 24);
            button14.Name = "button14";
            button14.Size = new Size(89, 40);
            button14.TabIndex = 48;
            button14.Text = "Log out";
            button14.UseVisualStyleBackColor = false;
            button14.Click += button14_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button10);
            Controls.Add(button8);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(comboBox7);
            Controls.Add(button12);
            Controls.Add(groupBox6);
            Controls.Add(button9);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label13);
            Controls.Add(button5);
            Controls.Add(comboBox5);
            Controls.Add(button4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(richTextBox1);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private TextBox textBox6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private RichTextBox richTextBox1;
        private Label label7;
        private GroupBox groupBox2;
        private Label label8;
        private Button button2;
        private TextBox textBox4;
        private TextBox textBox7;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private GroupBox groupBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private DateTimePicker dateTimePicker2;
        private Label label18;
        private Label label17;
        private Label label16;
        private Button button3;
        private Button button4;
        private ComboBox comboBox5;
        private Button button5;
        private Label label13;
        private Button button6;
        private Button button7;
        private Button button8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button9;
        private Button button10;
        private ComboBox comboBox6;
        private GroupBox groupBox6;
        private TextBox textBox3;
        private Button button11;
        private Label label6;
        private Button button12;
        private ComboBox comboBox7;
        private Label label19;
        private Label label20;
        private Button button13;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox richTextBox2;
        private Button button14;
    }
}
