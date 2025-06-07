using MaterialSkin.Controls;
using Timer = System.Windows.Forms.Timer;

namespace UI;

/// <summary>
///     这是用户界面层，用于与用户进行交互。业务逻辑层和数据访问层都在这里调用。
///     （已经引用了数据访问层的命名空间）
///     若要运行此项目，请右键运行旁边的齿轮图标更换为此项目。
///     <br />写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
/// </summary>
public partial class Login : MaterialForm
{
    BLL.HandleUserInput.UserData userData = new();
    /// <summary>
    ///     这是游客登录按钮的点击事件处理函数。
    ///     <br />这里由```子布```编写。
    ///     之后这段代码可能会被改写成一个函数（放入逻辑层），或者直接删除。
    /// </summary>
    public Login()
    {
        InitializeComponent();
        FormClosing += FormHelper.CloseForm;// 绑定 FormClosing 事件
        // 为文本框添加Enter事件处理
        textUserName.Enter += TextBox_Enter;
        textPassword.Enter += TextBox_Enter;
        textUserName.Leave += TextBox_Leave;
        textPassword.Leave += TextBox_Leave;
        // 为文本框添加TextChanged事件处理
        textUserName.TextChanged += TextUserName_TextChanged;
        textPassword.TextChanged += TextPassword_TextChanged;

        // 设置初始默认文本
        textUserName.Text = "用户名";
        textPassword.Text = "密码";
        textPassword.PasswordChar = '\0';
    }
    private void TextBox_Enter(object sender, EventArgs e)
    {
        // 当文本框获得焦点时清除其内容
        if (sender is TextBox textBox)
        {
            textBox.Clear();
            // 如果是密码框，确保它显示为密码字符
            if (textBox == textPassword)
            {
                textPassword.PasswordChar = '●'; // 设置密码掩码字符
            }
        }
    }
    private void TextBox_Leave(object sender, EventArgs e)
    {
        // 当文本框失去焦点时，如果为空则恢复默认文本
        if (sender is TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == textUserName)
                {
                    textBox.Text = "用户名";
                }
                else if (textBox == textPassword)
                {
                    textBox.Text = "密码";
                    textPassword.PasswordChar = '\0'; // 清除密码掩码字符
                }
            }
        }
    }
    private void btnVisitorLogin_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("真的要游客登录吗，你所有的数据将不会保存", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            
            FormHelper.ShowNewForm(this, Program.homePage); //显示新窗口
        }
    }

    private readonly string _usernamePattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,10}$"; // 用户名：字母开头，5-11位，只允许字母数字下划线
    private readonly string _passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d\W]{8,20}$"; // 密码：必须包含大小写字母和数字，8-20位

    private void TextUserName_TextChanged(object sender, EventArgs e)
    {
        // 只在非默认文本状态下验证
        if (textUserName.Text != "用户名" && !string.IsNullOrEmpty(textUserName.Text))
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(textUserName.Text, _usernamePattern);
            // 可以通过改变背景色或显示提示来反馈验证结果
            textUserName.BackColor = isValid ? Color.White : Color.LightPink;
        }
        else
        {
            textUserName.BackColor = Color.White;
        }
    }

    private void TextPassword_TextChanged(object sender, EventArgs e)
    {
        // 只在非默认文本状态下验证
        if (textPassword.Text != "密码" && !string.IsNullOrEmpty(textPassword.Text))
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(textPassword.Text, _passwordPattern);
            // 可以通过改变背景色或显示提示来反馈验证结果
            textPassword.BackColor = isValid ? Color.White : Color.LightPink;
        }
        else
        {
            textPassword.BackColor = Color.White;
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            // 添加输入验证
            if (string.IsNullOrWhiteSpace(textUserName.Text) || string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("用户名和密码不能为空", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int result = userData.UserRegister(textUserName.Text, textPassword.Text);
            //调用bll层的注册函数
            if (result == 10)
            {
                MessageBox.Show("注册失败：用户名已存在",
                              "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == 11)
            {
                MessageBox.Show("注册失败：用户名或密码格式不正确" +
                    "\n1.用户名长度在5-11之间，只能包含字母、数字和下划线" +
                    "\n2.密码必须包含大小写字母和数字的组合，可以使用特殊字符，不能包含汉字和其他非ASCII字符，长度在8-20之间", "注册失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == 1)
            {
                MessageBox.Show("注册成功", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BLL.HandleUserInput.UserStateDeliver.RememberUser(textUserName.Text);
                var homePage = new HomePage();
                FormHelper.ShowNewForm(this, homePage);
            }
            else if (result == -1)
            {
                MessageBox.Show("注册过程中发生错误，请稍后再试", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"发生未知错误: {ex.Message}", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            // 添加输入验证
            if (string.IsNullOrWhiteSpace(textUserName.Text) || string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("用户名和密码不能为空", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int result = userData.UserLogin(textUserName.Text, textPassword.Text);
            if (result == 0)
            {
                MessageBox.Show("用户名或密码错误，请重新输入", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == 1)
            {
                BLL.HandleUserInput.UserStateDeliver.RememberUser(textUserName.Text);
                // 直接进入主页，无需显示成功消息
                var homePage = new HomePage();
                FormHelper.ShowNewForm(this, homePage);
            }
            else if (result == -1)
            {
                MessageBox.Show("登录过程中发生错误，请稍后再试", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"发生未知错误: {ex.Message}", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Login_Load(object sender, EventArgs e)
    {

    }
}