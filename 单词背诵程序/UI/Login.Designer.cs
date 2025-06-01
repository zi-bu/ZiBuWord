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
            btnLogin.Location = new Point(101, 419);
            btnLogin.Margin = new Padding(2, 2, 2, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(249, 41);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(101, 465);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(249, 41);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "注册";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(101, 382);
            textPassword.Margin = new Padding(2, 2, 2, 2);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(251, 23);
            textPassword.TabIndex = 2;
            textPassword.Text = "密码";
            // 
            // textUserName
            // 
            textUserName.Location = new Point(101, 346);
            textUserName.Margin = new Padding(2, 2, 2, 2);
            textUserName.Name = "textUserName";
            textUserName.Size = new Size(251, 23);
            textUserName.TabIndex = 3;
            textUserName.Text = "用户名";
            // 
            // btnVisitorLogin
            // 
            btnVisitorLogin.Location = new Point(101, 561);
            btnVisitorLogin.Name = "btnVisitorLogin";
            btnVisitorLogin.Size = new Size(249, 39);
            btnVisitorLogin.TabIndex = 4;
            btnVisitorLogin.Text = "游客登录";
            btnVisitorLogin.UseVisualStyleBackColor = true;
            btnVisitorLogin.Click += btnVisitorLogin_Click;
            // 
            // button1
            // 
            button1.Location = new Point(354, 617);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 5;
            button1.Text = "体验新版";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(470, 681);
            Controls.Add(button1);
            Controls.Add(btnVisitorLogin);
            Controls.Add(textUserName);
            Controls.Add(textPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Login";
            Padding = new Padding(10, 10, 10, 10);
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
