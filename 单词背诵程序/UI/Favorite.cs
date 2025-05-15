using MaterialSkin.Controls;

namespace UI;

public partial class Favorite : MaterialForm
{
    public Favorite()
    {
        InitializeComponent();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void button4_Click(object sender, EventArgs e)
    {
        var homePage = new HomePage();
        homePage.StartPosition = FormStartPosition.Manual; //固定窗口位置
        homePage.Location = Location; //对齐窗口位置
        homePage.Show(); //显示主页面
        Hide();
    }
}