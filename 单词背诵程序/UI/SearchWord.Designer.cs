﻿namespace UI
{
    partial class SearchWord
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
            button1 = new Button();
            中文搜索 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            panel2 = new Panel();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            listView1 = new ListView();
            单词 = new ColumnHeader();
            词性 = new ColumnHeader();
            释义 = new ColumnHeader();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(92, 74);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "确认搜索";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // 中文搜索
            // 
            中文搜索.AutoSize = true;
            中文搜索.Location = new Point(17, 29);
            中文搜索.Name = "中文搜索";
            中文搜索.Size = new Size(69, 20);
            中文搜索.TabIndex = 1;
            中文搜索.Text = "英文搜索";
            中文搜索.Click += 中文搜索_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(中文搜索);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(42, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 125);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(395, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(292, 125);
            panel2.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(99, 74);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "确认搜索";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(99, 29);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 33);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 0;
            label2.Text = "中文搜索";
            // 
            // panel3
            // 
            panel3.Controls.Add(listView1);
            panel3.Location = new Point(42, 165);
            panel3.Name = "panel3";
            panel3.Size = new Size(656, 177);
            panel3.TabIndex = 4;
            panel3.Paint += panel3_Paint;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { 单词, 词性, 释义 });
            listView1.Location = new Point(17, 21);
            listView1.Name = "listView1";
            listView1.Size = new Size(612, 142);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // button3
            // 
            button3.Location = new Point(605, 348);
            button3.Name = "button3";
            button3.Size = new Size(82, 29);
            button3.TabIndex = 5;
            button3.Text = "返回主页";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // SearchWord
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 389);
            Controls.Add(button3);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SearchWord";
            Text = "SearchWord";
            Load += SearchWord_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label 中文搜索;
        private Panel panel1;
        private TextBox textBox1;
        private Panel panel2;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private Panel panel3;
        private Button button3;
        private ListView listView1;
        private ColumnHeader 单词;
        private ColumnHeader 词性;
        private ColumnHeader 释义;
    }
}