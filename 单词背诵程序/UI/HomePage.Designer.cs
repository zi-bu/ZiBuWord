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
            MyFavorite = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnStartMemory
            // 
            btnStartMemory.Location = new Point(165, 129);
            btnStartMemory.Margin = new Padding(4, 4, 4, 4);
            btnStartMemory.Name = "btnStartMemory";
            btnStartMemory.Size = new Size(139, 69);
            btnStartMemory.TabIndex = 1;
            btnStartMemory.Text = "开始记忆";
            btnStartMemory.UseVisualStyleBackColor = true;
            btnStartMemory.Click += btnStartMemory_Click;
            // 
            // btnStartReview
            // 
            btnStartReview.Location = new Point(435, 129);
            btnStartReview.Margin = new Padding(4, 4, 4, 4);
            btnStartReview.Name = "btnStartReview";
            btnStartReview.Size = new Size(139, 69);
            btnStartReview.TabIndex = 2;
            btnStartReview.Text = "开始复习";
            btnStartReview.UseVisualStyleBackColor = true;
            btnStartReview.Click += btnStartReview_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(465, 399);
            btnExit.Margin = new Padding(4, 4, 4, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(81, 30);
            btnExit.TabIndex = 4;
            btnExit.Text = "退出背词";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += Exit;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(178, 399);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 30);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "退出登录";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // comboBoxSelectDict
            // 
            comboBoxSelectDict.FormattingEnabled = true;
            comboBoxSelectDict.Location = new Point(321, 245);
            comboBoxSelectDict.Margin = new Padding(1, 1, 1, 1);
            comboBoxSelectDict.Name = "comboBoxSelectDict";
            comboBoxSelectDict.Size = new Size(94, 25);
            comboBoxSelectDict.TabIndex = 7;
            comboBoxSelectDict.SelectedIndexChanged += comboBoxSelectDict_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(321, 318);
            button1.Name = "button1";
            button1.Size = new Size(92, 50);
            button1.TabIndex = 8;
            button1.Text = "搜索单词";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MyFavorite
            // 
            MyFavorite.Location = new Point(321, 399);
            MyFavorite.Margin = new Padding(2, 2, 2, 2);
            MyFavorite.Name = "MyFavorite";
            MyFavorite.Size = new Size(92, 50);
            MyFavorite.TabIndex = 9;
            MyFavorite.Text = "我的收藏";
            MyFavorite.UseVisualStyleBackColor = true;
            MyFavorite.Click += btnFavorite_Click;
            // 
            // button2
            // 
            button2.Location = new Point(595, 494);
            button2.Name = "button2";
            button2.Size = new Size(94, 38);
            button2.TabIndex = 10;
            button2.Text = "体验新版";
            button2.UseVisualStyleBackColor = true;
            button2.Click += test;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 565);
            Controls.Add(button2);
            Controls.Add(MyFavorite);
            Controls.Add(button1);
            Controls.Add(comboBoxSelectDict);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(btnStartReview);
            Controls.Add(btnStartMemory);
            Margin = new Padding(1, 1, 1, 1);
            Name = "HomePage";
            Padding = new Padding(1, 45, 1, 1);
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
        private Button MyFavorite;
        private Button button2;
    }
}