using MaterialSkin.Controls;
using BLL;

namespace UI;

public partial class Favorite : MaterialForm
{

    private readonly FavoriteWordService _favoriteService = new();

    public Favorite()
    {
        FormClosing += FormHelper.ReturnHomepage;//绑定返回主页事件
        InitializeComponent();
        dataGridViewFavorites.AutoGenerateColumns = false;
        LoadFavorites();
        dataGridViewFavorites.CellContentClick += DataGridViewFavorites_CellContentClick;
        dataGridViewFavorites.DataBindingComplete += DataGridViewFavorites_DataBindingComplete;
    }

    private void LoadFavorites()
    {
        // 调用BLL层获取当前用户收藏
        var details = _favoriteService.GetCurrentUserFavorites();
        dataGridViewFavorites.DataSource = details;
    }

    /// <summary>
    /// 处理移除收藏按钮的点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridViewFavorites_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dataGridViewFavorites.Columns["colRemove"].Index && e.RowIndex >= 0)
        {
            var detail = (FavoriteWordDetail)dataGridViewFavorites.Rows[e.RowIndex].DataBoundItem;
            if (!string.IsNullOrEmpty(detail.DictionaryType))
            {
                // 移除当前选中的收藏
                _favoriteService.RemoveFavorite(detail.WordId, detail.DictionaryType);
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
        Close();
    }
}