﻿using MaterialSkin.Controls;
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
    }

    private void LoadFavorites()
    {
        //获取当前用户收藏
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

    private void button4_Click(object sender, EventArgs e)
    {
        Close();
    }
}