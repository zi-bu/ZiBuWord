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
        // 只需调用 BLL 层的“获取当前用户收藏”方法
        var details = _favoriteService.GetCurrentUserFavorites();
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
                // 只需传递单词ID和词典类型，用户ID由BLL自动获取
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
  
       
        //之后统一用Close()方法关闭子窗口，绑定ReturnHomepage事件，自动返回主界面
    }
}