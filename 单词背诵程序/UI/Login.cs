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
    BLL.UserData userData = new();
    /// <summary>
    ///     这是游客登录按钮的点击事件处理函数。
    ///     <br />这里由```子布```编写。
    ///     之后这段代码可能会被改写成一个函数（放入逻辑层），或者直接删除。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        int result = userData.UserRegister(textUserName.Text, textPassword.Text);
        if (result == 0)
        {
            MessageBox.Show("用户名已存在或密码不符合要求，请重新输入", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else if (result == 1)
        {
            MessageBox.Show("注册成功", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var homePage = new HomePage(); //创建一个新的主页窗口对象
            FormHelper.ShowNewForm(this, homePage); //显示新窗口
        }
        else if (result == -1)
        {
            MessageBox.Show("注册失败，请稍后再试", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine("你怎么抛出异常了喵？");
        }
    }
    private void btnLogin_Click(object sender, EventArgs e)
    {
        int result = userData.UserLogin(textUserName.Text, textPassword.Text);
        if (result == 0)
        {
            MessageBox.Show("用户名或密码错误，请重新输入", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else if (result == 1)
        {
            var homePage = new HomePage(); //创建一个新的主页窗口对象
            FormHelper.ShowNewForm(this, homePage); //显示新窗口
        }
    }
}