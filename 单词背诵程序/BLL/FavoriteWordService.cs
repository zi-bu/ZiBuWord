using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.ReturnFunction;

namespace BLL
{
    /// <summary>
    /// 收藏单词业务逻辑层
    /// </summary>
    public class FavoriteWordService
    {
        private readonly FavoriteWordsManagement _dal = new FavoriteWordsManagement();

        /// <summary>
        /// 添加收藏
        /// </summary>
        public void AddFavorite(int userId, int wordId, string dictType)
        {
            _dal.AddFavorite(userId, wordId, dictType);
        }

        /// <summary>
        /// 移除收藏
        /// </summary>
        public void RemoveFavorite(int userId, int wordId, string dictType)
        {
            _dal.RemoveFavorite(userId, wordId, dictType);
        }

        /// <summary>
        /// 获取用户所有收藏
        /// </summary>
        public List<FavoriteWord> GetFavorites(int userId)
        {
            return _dal.GetFavorites(userId);
        }
    }
}