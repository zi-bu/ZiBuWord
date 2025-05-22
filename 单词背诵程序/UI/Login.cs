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
    }
    private void btnVisitorLogin_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("真的要游客登录吗，你所有的数据将不会保存", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            var homePage = new HomePage(); //创建一个新的主页窗口对象
            FormHelper.ShowNewForm(this, homePage); //显示新窗口
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


}