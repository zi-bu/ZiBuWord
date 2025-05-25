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
            button1 = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(130, 493);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(320, 48);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(130, 547);
            btnRegister.Margin = new Padding(4, 4, 4, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(320, 48);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "注册";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(130, 449);
            textPassword.Margin = new Padding(3, 2, 3, 2);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(322, 27);
            textPassword.TabIndex = 2;
            textPassword.Text = "密码";
            // 
            // textUserName
            // 
            textUserName.Location = new Point(130, 407);
            textUserName.Margin = new Padding(3, 2, 3, 2);
            textUserName.Name = "textUserName";
            textUserName.Size = new Size(322, 27);
            textUserName.TabIndex = 3;
            textUserName.Text = "用户名";
            // 
            // btnVisitorLogin
            // 
            btnVisitorLogin.Location = new Point(130, 660);
            btnVisitorLogin.Margin = new Padding(4, 4, 4, 4);
            btnVisitorLogin.Name = "btnVisitorLogin";
            btnVisitorLogin.Size = new Size(320, 46);
            btnVisitorLogin.TabIndex = 4;
            btnVisitorLogin.Text = "游客登录";
            btnVisitorLogin.UseVisualStyleBackColor = true;
            btnVisitorLogin.Click += btnVisitorLogin_Click;
            // 
            // button1
            // 
            button1.Location = new Point(130, 202);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(320, 46);
            button1.TabIndex = 5;
            button1.Text = "测试";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(604, 801);
            Controls.Add(button1);
            Controls.Add(btnVisitorLogin);
            Controls.Add(textUserName);
            Controls.Add(textPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Padding = new Padding(13, 12, 13, 12);
            Text = " 登录";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnRegister;
        private TextBox textPassword;
        private TextBox textUserName;
        private Button btnVisitorLogin;
        private Button button1;
    }
}
