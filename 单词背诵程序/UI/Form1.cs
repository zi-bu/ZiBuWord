using BLL;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// 这是用户界面层，用于与用户进行交互。业务逻辑层和数据访问层都在这里调用。
    /// （已经引用了数据访问层的命名空间）
    /// 若要运行此项目，请右键运行旁边的齿轮图标更换为此项目。
    /// <br/>写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
    /// </summary>
    public partial class Form1 : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnVisitor;
        private Label lblTitle;
        private PictureBox picLogo;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            ApplyStyling();
        }

        private void InitializeCustomComponents()
        {
            // 设置窗体属性
            this.Text = "单词背诵程序";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 标题标签
            lblTitle = new Label
            {
                Text = "欢迎使用单词背诵程序",
                Font = new Font("微软雅黑", 24, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(200, 50)
            };

            // 用户名输入框
            txtUsername = new TextBox
            {
                PlaceholderText = "请输入用户名",
                Size = new Size(300, 30),
                Location = new Point(250, 150),
                Font = new Font("微软雅黑", 12)
            };

            // 密码输入框
            txtPassword = new TextBox
            {
                PlaceholderText = "请输入密码",
                Size = new Size(300, 30),
                Location = new Point(250, 200),
                Font = new Font("微软雅黑", 12),
                PasswordChar = '*'
            };

            // 登录按钮
            btnLogin = new Button
            {
                Text = "登录",
                Size = new Size(120, 40),
                Location = new Point(250, 250),
                Font = new Font("微软雅黑", 12)
            };
            btnLogin.Click += BtnLogin_Click;

            // 游客登录按钮
            btnVisitor = new Button
            {
                Text = "游客登录",
                Size = new Size(120, 40),
                Location = new Point(430, 250),
                Font = new Font("微软雅黑", 12)
            };
            btnVisitor.Click += VisitorLogin;

            // 添加控件到窗体
            this.Controls.AddRange(new Control[] { lblTitle, txtUsername, txtPassword, btnLogin, btnVisitor });
        }

        private void ApplyStyling()
        {
            // 设置背景色
            this.BackColor = Color.White;

            // 设置按钮样式
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("请输入用户名和密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: 调用BLL层的登录验证
            // 如果验证成功，打开主窗体
            Form2 mainForm = new Form2();
            mainForm.Show();
            this.Hide();
        }

        private void VisitorLogin(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要游客登录吗？您的学习进度将不会被保存。", "提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form2 mainForm = new Form2();
                mainForm.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("恭喜你发现了彩蛋，关注子布喵喵喵");
        }
    }
}
