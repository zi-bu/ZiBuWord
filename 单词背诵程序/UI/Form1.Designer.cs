namespace UI
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(158, 430);
            button1.Name = "button1";
            button1.Size = new Size(114, 58);
            button1.TabIndex = 0;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(471, 607);
            button2.Margin = new Padding(5, 4, 5, 4);
            button2.Name = "button2";
            button2.Size = new Size(114, 58);
            button2.TabIndex = 1;
            button2.Text = "注册";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(158, 325);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(392, 30);
            textBox1.TabIndex = 2;
            textBox1.Text = "密码";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(158, 253);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(392, 30);
            textBox2.TabIndex = 3;
            textBox2.Text = "用户名";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(329, 870);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 4;
            label1.Text = "游客登陆";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.favicon_3_;
            pictureBox1.Location = new Point(238, 158);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(259, 250);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_2;
            // 
            // button3
            // 
            button3.Location = new Point(683, 607);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(179, 82);
            button3.TabIndex = 4;
            button3.Text = "游客登录";
            button3.UseVisualStyleBackColor = true;
            button3.Click += VisitorLogin;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1483, 961);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Padding = new Padding(16, 14, 16, 14);
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
    }
}
