using MaterialSkin.Controls;
using BLL;

namespace UI;

public partial class Favorite : MaterialForm
{
    private readonly FavoriteWordService _favoriteService = new();
    private int _userId = 1; // 这里替换为实际用户ID获取方式
    public Favorite()
    {
        InitializeComponent();
        LoadFavorites();
        dataGridViewFavorites.CellContentClick += DataGridViewFavorites_CellContentClick;
    }
    private void LoadFavorites()
    {
        var details = _favoriteService.GetFavoriteDetails(_userId);
        dataGridViewFavorites.DataSource = details;
        // 可选：设置只读、列宽等属性
        dataGridViewFavorites.Columns["Id"].Visible = false; // 隐藏内部ID
        dataGridViewFavorites.Columns["DictionaryType"].HeaderText = "词典";
        dataGridViewFavorites.Columns["Word"].HeaderText = "单词";
        dataGridViewFavorites.Columns["Translation"].HeaderText = "释义";
    }

    // 处理“移除”按钮点击
    private void DataGridViewFavorites_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dataGridViewFavorites.Columns["colRemove"].Index && e.RowIndex >= 0)
        {
            var detail = (FavoriteWordDetail)dataGridViewFavorites.Rows[e.RowIndex].DataBoundItem;
            _favoriteService.RemoveFavorite(_userId, detail.WordId, detail.DictionaryType);
            LoadFavorites();
        }
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