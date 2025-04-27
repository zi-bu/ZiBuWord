using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class Form2 : Form
    {
        private Label lblWord;
        private Label lblTranslation;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnExit;
        private Button btnSettings;
        private Panel pnlWordDisplay;
        private MenuStrip mainMenu;

        public Form2()
        {
            InitializeComponent();
            InitializeCustomComponents();
            ApplyStyling();
            this.FormClosing += Form2_FormClosing;
        }

        private void InitializeCustomComponents()
        {
            // 设置窗体属性
            this.Text = "单词背诵 - 主界面";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 创建主菜单
            mainMenu = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("文件(&F)");
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("帮助(&H)");
            
            fileMenu.DropDownItems.Add("导入单词表", null, ImportWordList);
            fileMenu.DropDownItems.Add("导出学习记录", null, ExportProgress);
            fileMenu.DropDownItems.Add("-");
            fileMenu.DropDownItems.Add("退出", null, Exit);
            
            helpMenu.DropDownItems.Add("使用说明", null, ShowHelp);
            helpMenu.DropDownItems.Add("关于", null, ShowAbout);
            
            mainMenu.Items.Add(fileMenu);
            mainMenu.Items.Add(helpMenu);
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;

            // 单词显示面板
            pnlWordDisplay = new Panel
            {
                Size = new Size(800, 300),
                Location = new Point(100, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // 单词标签
            lblWord = new Label
            {
                Text = "Word",
                Font = new Font("微软雅黑", 36, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(300, 100)
            };

            // 翻译标签
            lblTranslation = new Label
            {
                Text = "Translation",
                Font = new Font("微软雅黑", 24),
                AutoSize = true,
                Location = new Point(300, 200)
            };

            // 控制按钮
            btnPrevious = new Button
            {
                Text = "上一个",
                Size = new Size(100, 40),
                Location = new Point(300, 400)
            };
            btnPrevious.Click += BtnPrevious_Click;

            btnNext = new Button
            {
                Text = "下一个",
                Size = new Size(100, 40),
                Location = new Point(500, 400)
            };
            btnNext.Click += BtnNext_Click;

            btnSettings = new Button
            {
                Text = "设置",
                Size = new Size(80, 30),
                Location = new Point(900, 50)
            };
            btnSettings.Click += BtnSettings_Click;

            // 添加控件到面板
            pnlWordDisplay.Controls.Add(lblWord);
            pnlWordDisplay.Controls.Add(lblTranslation);

            // 添加控件到窗体
            this.Controls.AddRange(new Control[] { pnlWordDisplay, btnPrevious, btnNext, btnSettings });
        }

        private void ApplyStyling()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(0, 120, 215);
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Cursor = Cursors.Hand;
                }
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            // TODO: 实现上一个单词的功能
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            // TODO: 实现下一个单词的功能
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // TODO: 打开设置窗口
        }

        private void ImportWordList(object sender, EventArgs e)
        {
            // TODO: 实现导入单词表功能
        }

        private void ExportProgress(object sender, EventArgs e)
        {
            // TODO: 实现导出学习记录功能
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            MessageBox.Show("使用说明：\n1. 点击"下一个"按钮学习新单词\n2. 点击"上一个"按钮复习已学单词\n3. 在设置中可以调整学习参数", 
                "使用说明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            MessageBox.Show("单词背诵程序 v1.0\n\n开发团队：一般路过大一学生C#小组", 
                "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Exit(object sender, EventArgs e)
        {
            Form2_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？未保存的进度将会丢失！", "警告", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
