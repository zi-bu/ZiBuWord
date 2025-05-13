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
            btnLogin = new Button();
            btnRegister = new Button();
            textPassword = new TextBox();
            textUserName = new TextBox();
            btnVisitorLogin = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(158, 592);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(392, 58);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(158, 657);
            btnRegister.Margin = new Padding(5, 4, 5, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(392, 58);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "注册";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(158, 539);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(392, 30);
            textPassword.TabIndex = 2;
            textPassword.Text = "密码";
            // 
            // textUserName
            // 
            textUserName.Location = new Point(158, 489);
            textUserName.Name = "textUserName";
            textUserName.Size = new Size(392, 30);
            textUserName.TabIndex = 3;
            textUserName.Text = "用户名";
            // 
            // btnVisitorLogin
            // 
            btnVisitorLogin.Location = new Point(158, 792);
            btnVisitorLogin.Margin = new Padding(5, 4, 5, 4);
            btnVisitorLogin.Name = "btnVisitorLogin";
            btnVisitorLogin.Size = new Size(392, 55);
            btnVisitorLogin.TabIndex = 4;
            btnVisitorLogin.Text = "游客登录";
            btnVisitorLogin.UseVisualStyleBackColor = true;
            btnVisitorLogin.Click += btnVisitorLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(738, 961);
            Controls.Add(btnVisitorLogin);
            Controls.Add(textUserName);
            Controls.Add(textPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Name = "Login";
            Padding = new Padding(16, 14, 16, 14);
            Text = " 登录";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnRegister;
        private TextBox textPassword;
        private TextBox textUserName;
        private Button btnVisitorLogin;
        private Label? label1;
        private PictureBox pictureBox1;
    }
}
