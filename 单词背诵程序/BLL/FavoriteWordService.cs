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
        public List<FavoriteWordDetail> GetFavoriteDetails(int userId)
        {
            var favorites = _dal.GetFavorites(userId);
            var result = new List<FavoriteWordDetail>();
            using var db = new DAL.Context.SqlDataContext();
            foreach (var fav in favorites)
            {
                string word = "";
                string translation = "";
                switch (fav.DictionaryType)
                {
                    case "CET4":
                        var cet4 = db.CET4.FirstOrDefault(w => w.Id == fav.WordId);
                        if (cet4 != null)
                        {
                            word = cet4.Word;
                            translation = string.Join("; ", cet4.Translations.Select(t => t.Translation));
                        }
                        break;
                    case "CET6":
                        var cet6 = db.CET6.FirstOrDefault(w => w.Id == fav.WordId);
                        if (cet6 != null)
                        {
                            word = cet6.Word;
                            translation = string.Join("; ", cet6.Translations.Select(t => t.Translation));
                        }
                        break;
                }
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
    }
}