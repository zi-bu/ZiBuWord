namespace UI;
using static BLL.SelectionOrder;

public partial class MemorizerSelection : Form
{
    public MemorizerSelection()
    {
        InitializeComponent();
        this.FormClosing += FormHelper.CloseForm;// 绑定 FormClosing 事件

    }
    private void btnReturn_Click(object sender, EventArgs e)
    {
        HomePage homePage = new HomePage();//创建一个新的主页对象
        homePage.StartPosition = FormStartPosition.Manual;
        homePage.Location = this.Location;
        homePage.Show();//显示主页窗口
        this.Hide();//隐藏当前窗口
    }
    private void MemorizerSelection_Load(object sender, EventArgs e)//窗体加载时的事件
    {

    }

}