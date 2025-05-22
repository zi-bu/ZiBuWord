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
        private readonly FavoriteWordDetailQueryDAL _detailDal = new FavoriteWordDetailQueryDAL();

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
            if (string.IsNullOrEmpty(dictType))
                throw new ArgumentNullException(nameof(dictType), "词典类型不能为空");

            _dal.RemoveFavorite(userId, wordId, dictType);
        }

        /// <summary>
        /// 获取用户所有收藏
        /// </summary>
        public List<FavoriteWordDetail> GetFavoriteDetails(int userId)
        {
            var favorites = _dal.GetFavorites(userId);
            var result = new List<FavoriteWordDetail>();
            foreach (var fav in favorites)
            {
                var (word, posList, translationsList) = _detailDal.GetWordDetail(fav.DictionaryType, fav.WordId);
                var translation = string.Join("; ", translationsList.Zip(posList, (tran, p) => $"{p}. {tran}"));
                result.Add(new FavoriteWordDetail
                {
                    Id = fav.Id,
                    DictionaryType = fav.DictionaryType,
                    WordId = fav.WordId,
                    Word = word,
                    Translation = translation
                });
            }
            return result;
        }
    }

    public class FavoriteWordDetail
    {
        public int Id { get; set; }
        public string? DictionaryType { get; set; }
        public int WordId { get; set; }
        public string? Word { get; set; }
        public string? Translation { get; set; }
        public string? Pos { get; set; }
    }
}