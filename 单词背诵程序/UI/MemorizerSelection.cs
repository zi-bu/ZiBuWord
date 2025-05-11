



namespace UI;

public partial class MemorizerSelection : Form
{
    public MemorizerSelection()
    {
        InitializeComponent();
        this.FormClosing += FormHelper.CloseForm;// 绑定 FormClosing 事件

    }

    private void button1_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        //生成测试列表





    }

    private void button1_Click_1(object sender, EventArgs e)
    {


    }

    private void btnReturn_Click(object sender, EventArgs e)
    {
        HomePage homePage = new HomePage();//创建一个新的主页对象
        homePage.StartPosition = FormStartPosition.Manual;
        homePage.Location = this.Location;
        homePage.Show();//显示主页窗口
        this.Hide();//隐藏当前窗口
    }

    private void button3_Click(object sender, EventArgs e)
    {

    }

    private void MemorizerSelection_Load(object sender, EventArgs e)
    {

    }
}