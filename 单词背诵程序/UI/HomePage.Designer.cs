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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            menuStrip1 = new MenuStrip();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            更换账号ToolStripMenuItem = new ToolStripMenuItem();
            退出程序ToolStripMenuItem = new ToolStripMenuItem();
            词典ToolStripMenuItem = new ToolStripMenuItem();
            初中ToolStripMenuItem = new ToolStripMenuItem();
            高中ToolStripMenuItem = new ToolStripMenuItem();
            大学ToolStripMenuItem = new ToolStripMenuItem();
            四级ToolStripMenuItem = new ToolStripMenuItem();
            六级ToolStripMenuItem = new ToolStripMenuItem();
            托福ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(187, 337);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(213, 124);
            button2.Margin = new Padding(5, 4, 5, 4);
            button2.Name = "button2";
            button2.Size = new Size(178, 82);
            button2.TabIndex = 1;
            button2.Text = "开始记忆";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(561, 124);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(178, 82);
            button3.TabIndex = 2;
            button3.Text = "开始复习";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(213, 281);
            button4.Margin = new Padding(5, 4, 5, 4);
            button4.Name = "button4";
            button4.Size = new Size(178, 82);
            button4.TabIndex = 3;
            button4.Text = "选择词典";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(598, 469);
            button5.Margin = new Padding(5, 4, 5, 4);
            button5.Name = "button5";
            button5.Size = new Size(105, 35);
            button5.TabIndex = 4;
            button5.Text = "退出背词";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Exit;
            // 
            // button6
            // 
            button6.Location = new Point(561, 281);
            button6.Margin = new Padding(5, 4, 5, 4);
            button6.Name = "button6";
            button6.Size = new Size(178, 82);
            button6.TabIndex = 5;
            button6.Text = "单词收藏";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(229, 469);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(115, 35);
            button7.TabIndex = 6;
            button7.Text = "退出登录";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem, 词典ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(937, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 更换账号ToolStripMenuItem, 退出程序ToolStripMenuItem });
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(53, 24);
            设置ToolStripMenuItem.Text = "设置";
            // 
            // 更换账号ToolStripMenuItem
            // 
            更换账号ToolStripMenuItem.Name = "更换账号ToolStripMenuItem";
            更换账号ToolStripMenuItem.Size = new Size(224, 26);
            更换账号ToolStripMenuItem.Text = "更换账号";
            更换账号ToolStripMenuItem.Click += 更换账号ToolStripMenuItem_Click;
            // 
            // 退出程序ToolStripMenuItem
            // 
            退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            退出程序ToolStripMenuItem.Size = new Size(224, 26);
            退出程序ToolStripMenuItem.Text = "退出程序";
            退出程序ToolStripMenuItem.Click += 退出程序ToolStripMenuItem_Click;
            // 
            // 词典ToolStripMenuItem
            // 
            词典ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 初中ToolStripMenuItem, 高中ToolStripMenuItem, 大学ToolStripMenuItem });
            词典ToolStripMenuItem.Name = "词典ToolStripMenuItem";
            词典ToolStripMenuItem.Size = new Size(53, 24);
            词典ToolStripMenuItem.Text = "词典";
            // 
            // 初中ToolStripMenuItem
            // 
            初中ToolStripMenuItem.Name = "初中ToolStripMenuItem";
            初中ToolStripMenuItem.Size = new Size(224, 26);
            初中ToolStripMenuItem.Text = "初中";
            初中ToolStripMenuItem.Click += 初中ToolStripMenuItem_Click;
            // 
            // 高中ToolStripMenuItem
            // 
            高中ToolStripMenuItem.Name = "高中ToolStripMenuItem";
            高中ToolStripMenuItem.Size = new Size(224, 26);
            高中ToolStripMenuItem.Text = "高中";
            // 
            // 大学ToolStripMenuItem
            // 
            大学ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 四级ToolStripMenuItem, 六级ToolStripMenuItem, 托福ToolStripMenuItem });
            大学ToolStripMenuItem.Name = "大学ToolStripMenuItem";
            大学ToolStripMenuItem.Size = new Size(224, 26);
            大学ToolStripMenuItem.Text = "大学";
            // 
            // 四级ToolStripMenuItem
            // 
            四级ToolStripMenuItem.Name = "四级ToolStripMenuItem";
            四级ToolStripMenuItem.Size = new Size(122, 26);
            四级ToolStripMenuItem.Text = "四级";
            // 
            // 六级ToolStripMenuItem
            // 
            六级ToolStripMenuItem.Name = "六级ToolStripMenuItem";
            六级ToolStripMenuItem.Size = new Size(122, 26);
            六级ToolStripMenuItem.Text = "六级";
            // 
            // 托福ToolStripMenuItem
            // 
            托福ToolStripMenuItem.Name = "托福ToolStripMenuItem";
            托福ToolStripMenuItem.Size = new Size(122, 26);
            托福ToolStripMenuItem.Text = "托福";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 642);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(937, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 664);
            Controls.Add(statusStrip1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "HomePage";
            Text = "主页";
            Load += Form2_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 词典ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem 初中ToolStripMenuItem;
        private ToolStripMenuItem 高中ToolStripMenuItem;
        private ToolStripMenuItem 大学ToolStripMenuItem;
        private ToolStripMenuItem 四级ToolStripMenuItem;
        private ToolStripMenuItem 六级ToolStripMenuItem;
        private ToolStripMenuItem 托福ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 更换账号ToolStripMenuItem;
        private ToolStripMenuItem 退出程序ToolStripMenuItem;
    }
}