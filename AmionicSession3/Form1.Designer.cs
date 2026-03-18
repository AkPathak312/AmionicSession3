namespace AmionicSession3
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(256, 33);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(388, 70);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(256, 33);
            comboBox2.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(747, 70);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(256, 33);
            comboBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 42);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 3;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(388, 42);
            label2.Name = "label2";
            label2.Size = new Size(34, 25);
            label2.TabIndex = 4;
            label2.Text = "To:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(747, 42);
            label3.Name = "label3";
            label3.Size = new Size(103, 25);
            label3.TabIndex = 5;
            label3.Text = "Cabin Type:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(37, 143);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(88, 29);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "Return";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(184, 143);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(109, 29);
            radioButton2.TabIndex = 7;
            radioButton2.TabStop = true;
            radioButton2.Text = "One Way";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(388, 160);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(256, 31);
            dateTimePicker1.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(747, 160);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(256, 31);
            dateTimePicker2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(388, 132);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 10;
            label4.Text = "Outbound";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(747, 132);
            label5.Name = "label5";
            label5.Size = new Size(67, 25);
            label5.TabIndex = 11;
            label5.Text = "Return:";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1044, 156);
            button1.Name = "button1";
            button1.Size = new Size(168, 42);
            button1.TabIndex = 12;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 258);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1176, 264);
            dataGridView1.TabIndex = 13;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(27, 589);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1176, 264);
            dataGridView2.TabIndex = 14;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 230);
            label6.Name = "label6";
            label6.Size = new Size(202, 25);
            label6.TabIndex = 15;
            label6.Text = "Outbound Flight Details";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 561);
            label7.Name = "label7";
            label7.Size = new Size(170, 25);
            label7.TabIndex = 16;
            label7.Text = "Return Flight Details";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(927, 223);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(272, 29);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Show 3 days after and before";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(927, 554);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(272, 29);
            checkBox2.TabIndex = 18;
            checkBox2.Text = "Show 3 days after and before";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1226, 967);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            ForeColor = Color.Snow;
            Name = "Form1";
            Text = "Search for Flights";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label4;
        private Label label5;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label6;
        private Label label7;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}
