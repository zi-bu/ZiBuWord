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
        dataGridViewFavorites.AutoGenerateColumns = false;
        LoadFavorites();
        dataGridViewFavorites.CellContentClick += DataGridViewFavorites_CellContentClick;
        dataGridViewFavorites.DataBindingComplete += DataGridViewFavorites_DataBindingComplete;
    }

    private void LoadFavorites()
    {
        var details = _favoriteService.GetFavoriteDetails(_userId);
        dataGridViewFavorites.DataSource = details;
    }

    // 处理“移除”按钮点击
    private void DataGridViewFavorites_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dataGridViewFavorites.Columns["colRemove"].Index && e.RowIndex >= 0)
        {
            var detail = (FavoriteWordDetail)dataGridViewFavorites.Rows[e.RowIndex].DataBoundItem;
            if (!string.IsNullOrEmpty(detail.DictionaryType))
            {
                _favoriteService.RemoveFavorite(_userId, detail.WordId, detail.DictionaryType);
                LoadFavorites();
            }
            else
            {
                MessageBox.Show("词典类型不能为空！");
            }
        }
    }

    private void DataGridViewFavorites_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (dataGridViewFavorites.Columns["Id"] != null)
            dataGridViewFavorites.Columns["Id"].Visible = false;
        if (dataGridViewFavorites.Columns["DictionaryType"] != null)
            dataGridViewFavorites.Columns["DictionaryType"].HeaderText = "词典";
        if (dataGridViewFavorites.Columns["Word"] != null)
            dataGridViewFavorites.Columns["Word"].HeaderText = "单词";
        if (dataGridViewFavorites.Columns["Translation"] != null)
            dataGridViewFavorites.Columns["Translation"].HeaderText = "释义";
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