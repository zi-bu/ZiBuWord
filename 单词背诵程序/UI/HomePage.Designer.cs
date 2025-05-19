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
            button1 = new Button();
            SuspendLayout();
            // 
            // btnStartMemory
            // 
            btnStartMemory.Location = new Point(213, 152);
            btnStartMemory.Margin = new Padding(5, 4, 5, 4);
            btnStartMemory.Name = "btnStartMemory";
            btnStartMemory.Size = new Size(178, 82);
            btnStartMemory.TabIndex = 1;
            btnStartMemory.Text = "开始记忆";
            btnStartMemory.UseVisualStyleBackColor = true;
            btnStartMemory.Click += btnStartMemory_Click;
            // 
            // btnStartReview
            // 
            btnStartReview.Location = new Point(560, 152);
            btnStartReview.Margin = new Padding(5, 4, 5, 4);
            btnStartReview.Name = "btnStartReview";
            btnStartReview.Size = new Size(178, 82);
            btnStartReview.TabIndex = 2;
            btnStartReview.Text = "开始复习";
            btnStartReview.UseVisualStyleBackColor = true;
            btnStartReview.Click += btnStartReview_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(598, 469);
            btnExit.Margin = new Padding(5, 4, 5, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "退出背词";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += Exit;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(229, 469);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(115, 35);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "退出登录";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // comboBoxSelectDict
            // 
            comboBoxSelectDict.FormattingEnabled = true;
            comboBoxSelectDict.Location = new Point(412, 288);
            comboBoxSelectDict.Margin = new Padding(2, 2, 2, 2);
            comboBoxSelectDict.Name = "comboBoxSelectDict";
            comboBoxSelectDict.Size = new Size(119, 28);
            comboBoxSelectDict.TabIndex = 7;
            comboBoxSelectDict.SelectedIndexChanged += comboBoxSelectDict_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(412, 374);
            button1.Name = "button1";
            button1.Size = new Size(119, 59);
            button1.TabIndex = 8;
            button1.Text = "搜索单词";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 664);
            Controls.Add(button1);
            Controls.Add(comboBoxSelectDict);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(btnStartReview);
            Controls.Add(btnStartMemory);
            Margin = new Padding(2);
            Name = "HomePage";
            Padding = new Padding(2, 53, 2, 2);
            Text = "主页";
            Load += HomePage_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnStartMemory;
        private System.Windows.Forms.Button btnStartReview;
        private Button btnExit;
        private Button btnLogout;
        private ComboBox comboBoxSelectDict;
        private Button button1;
    }
}