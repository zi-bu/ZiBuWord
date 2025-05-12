namespace UI
{
    partial class HomePage
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
            btnStartMemory = new Button();
            btnStartReview = new Button();
            btnExit = new Button();
            btnLogout = new Button();
            comboBoxSelectDict = new ComboBox();
            SuspendLayout();
            // 
            // btnStartMemory
            // 
            btnStartMemory.Location = new Point(260, 182);
            btnStartMemory.Margin = new Padding(6, 5, 6, 5);
            btnStartMemory.Name = "btnStartMemory";
            btnStartMemory.Size = new Size(218, 98);
            btnStartMemory.TabIndex = 1;
            btnStartMemory.Text = "开始记忆";
            btnStartMemory.UseVisualStyleBackColor = true;
            // 
            // btnStartReview
            // 
            btnStartReview.Location = new Point(685, 182);
            btnStartReview.Margin = new Padding(6, 5, 6, 5);
            btnStartReview.Name = "btnStartReview";
            btnStartReview.Size = new Size(218, 98);
            btnStartReview.TabIndex = 2;
            btnStartReview.Text = "开始复习";
            btnStartReview.UseVisualStyleBackColor = true;
            btnStartReview.Click += btnStartReview_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(731, 563);
            btnExit.Margin = new Padding(6, 5, 6, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(128, 42);
            btnExit.TabIndex = 4;
            btnExit.Text = "退出背词";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += Exit;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(280, 563);
            btnLogout.Margin = new Padding(5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(141, 42);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "退出登录";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // comboBoxSelectDict
            // 
            comboBoxSelectDict.FormattingEnabled = true;
            comboBoxSelectDict.Location = new Point(503, 345);
            comboBoxSelectDict.Name = "comboBoxSelectDict";
            comboBoxSelectDict.Size = new Size(144, 32);
            comboBoxSelectDict.TabIndex = 7;
            
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 797);
            Controls.Add(comboBoxSelectDict);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(btnStartReview);
            Controls.Add(btnStartMemory);
            Margin = new Padding(2);
            Name = "HomePage";
            Text = "主页";
            
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnStartMemory;
        private Button btnStartReview;
        private Button btnExit;
        private Button btnLogout;
        private ComboBox comboBoxSelectDict;
    }
}