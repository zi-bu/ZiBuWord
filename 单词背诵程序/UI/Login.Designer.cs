namespace UI
{
    partial class Login
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
            button1.Location = new Point(158, 592);
            button1.Name = "button1";
            button1.Size = new Size(392, 58);
            button1.TabIndex = 0;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(158, 657);
            button2.Margin = new Padding(5, 4, 5, 4);
            button2.Name = "button2";
            button2.Size = new Size(392, 58);
            button2.TabIndex = 1;
            button2.Text = "注册";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(158, 539);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(392, 30);
            textBox1.TabIndex = 2;
            textBox1.Text = "密码";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(158, 489);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(392, 30);
            textBox2.TabIndex = 3;
            textBox2.Text = "用户名";
            // 
            // button3
            // 
            button3.Location = new Point(158, 792);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(392, 55);
            button3.TabIndex = 4;
            button3.Text = "游客登录";
            button3.UseVisualStyleBackColor = true;
            button3.Click += VisitorLogin;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(738, 961);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Login";
            Padding = new Padding(16, 14, 16, 14);
            Text = " 登录";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private Label? label1;
        private PictureBox pictureBox1;
    }
}
