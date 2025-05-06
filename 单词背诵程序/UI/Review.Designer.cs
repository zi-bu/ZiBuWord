namespace UI
{
    partial class Review
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
            button2 = new Button();
            textBox1 = new TextBox();
            panel1 = new Panel();
            button4 = new Button();
            label2 = new Label();
            button3 = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(98, 290);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(115, 35);
            button1.TabIndex = 0;
            button1.Text = "认识";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(474, 290);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(115, 35);
            button2.TabIndex = 2;
            button2.Text = "不认识";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(123, 125);
            textBox1.Margin = new Padding(4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(429, 40);
            textBox1.TabIndex = 3;
            textBox1.Text = "词义";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(136, 55);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(673, 410);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // button4
            // 
            button4.Location = new Point(581, 34);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(61, 35);
            button4.TabIndex = 8;
            button4.Text = "首页";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 44);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 7;
            label2.Text = "词库";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(280, 290);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(115, 35);
            button3.TabIndex = 6;
            button3.Text = "收藏";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(123, 187);
            textBox2.Margin = new Padding(4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(429, 62);
            textBox2.TabIndex = 5;
            textBox2.Text = "例句";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(309, 74);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 4;
            label1.Text = "单词";
            label1.Click += label1_Click;
            // 
            // Review
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 540);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "Review";
            Text = "复习";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Panel panel1;
        private Label label1;
        private Button button4;
        private Label label2;
        private Button button3;
        private TextBox textBox2;
    }
}