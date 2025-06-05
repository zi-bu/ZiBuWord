using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;

namespace DAL.ReturnFunction
{
    /// <summary>
    /// 收藏单词管理类，提供增删查收藏单词的方法
    /// </summary>
    public class FavoriteWordsManagement
    {
        /// <summary>
        /// 添加收藏单词
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="wordId">单词ID</param>
        /// <param name="dictType">词典类型</param>
        public void AddFavorite(int userId, int wordId, string dictType)
        {
            using var db = new UserContext();
            // 检查是否已经收藏某单词，如果没有收藏，则添加该单词
            if (!db.FavoriteWords.Any( // 判断收藏单词表中是否有满足下面条件的单词，然后取反
                f => f.UserId == userId && 
                     f.WordId == wordId &&
                     f.DictionaryType == dictType))
            {
                // 添加收藏单词
                db.FavoriteWords.Add(new FavoriteWord // 创建新的收藏单词对象
                {
                    UserId = userId,
                    WordId = wordId,
                    DictionaryType = dictType
                });
                db.SaveChanges(); // 保存更改
            }
        }
        /// <summary>
        /// 删除收藏单词
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="wordId">单词ID</param>
        /// <param name="dictType">词典类型</param>
        public void RemoveFavorite(int userId, int wordId, string dictType)
        {
            using var db = new UserContext();
            // 查找已有的收藏记录
            var fav = db.FavoriteWords.FirstOrDefault( // 查找第一个满足下面条件的单词
                f => f.UserId == userId &&
                     f.WordId == wordId &&
                     f.DictionaryType == dictType);
            if (fav != null)
            {
                db.FavoriteWords.Remove(fav); // 删除找到的收藏单词
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取用户的收藏单词列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>收藏单词列表</returns>
        public List<FavoriteWord> GetFavorites(int userId)
        {
            using var db = new UserContext();
            // 获取用户的所有收藏单词
            return db.FavoriteWords.Where(f => f.UserId == userId).ToList();
        }
    }
}
