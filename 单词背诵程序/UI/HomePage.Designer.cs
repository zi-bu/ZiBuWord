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
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(229, 404);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(260, 182);
            button2.Margin = new Padding(6, 5, 6, 5);
            button2.Name = "button2";
            button2.Size = new Size(218, 98);
            button2.TabIndex = 1;
            button2.Text = "开始记忆";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(685, 182);
            button3.Margin = new Padding(6, 5, 6, 5);
            button3.Name = "button3";
            button3.Size = new Size(218, 98);
            button3.TabIndex = 2;
            button3.Text = "开始复习";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(478, 355);
            button4.Margin = new Padding(6, 5, 6, 5);
            button4.Name = "button4";
            button4.Size = new Size(218, 98);
            button4.TabIndex = 3;
            button4.Text = "选择词典";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(731, 563);
            button5.Margin = new Padding(6, 5, 6, 5);
            button5.Name = "button5";
            button5.Size = new Size(128, 42);
            button5.TabIndex = 4;
            button5.Text = "退出背词";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Exit;
            // 
            // button7
            // 
            button7.Location = new Point(280, 563);
            button7.Margin = new Padding(5);
            button7.Name = "button7";
            button7.Size = new Size(141, 42);
            button7.TabIndex = 6;
            button7.Text = "退出登录";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 797);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "HomePage";
            Text = "主页";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
    }
}