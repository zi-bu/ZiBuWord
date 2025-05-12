namespace UI;

public partial class Review : Form
{
    public Review()
    {
        InitializeComponent();
        FormClosing += FormHelper.CloseForm; // 绑定 FormClosing 事件
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void btnReturn_Click(object sender, EventArgs e)
    {
        var homePage = new HomePage();
        FormHelper.ShowNewForm(this, homePage);
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void Review_Load(object sender, EventArgs e)
    {
    }
}