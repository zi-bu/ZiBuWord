using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.ReturnFunction;
using IBLLBridgeDAL;

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
        /// <param name="userId">用户ID</param>
        public List<FavoriteWordDetail> GetFavoriteDetails(int userId)
        {
            var favorites = _dal.GetFavorites(userId); // 获取用户的收藏列表
            var result = new List<FavoriteWordDetail>(); // 创建一个新的列表来存储结果
            foreach (var fav in favorites) // 遍历每个收藏
            {
                // 获取单词原文、词性和释义
                var (word, posList, translationsList) = _detailDal.GetWordDetail(fav.DictionaryType, fav.WordId);
                // 把词性和释义拼接成字符串
                var translation = string.Join("; ", translationsList.Zip(posList, (tran, p) => $"{p}. {tran}"));
                result.Add(new FavoriteWordDetail // 创建一个新的 FavoriteWordDetail 对象
                {
                    Id = fav.Id, // 收藏ID
                    DictionaryType = fav.DictionaryType, // 词典类型
                    WordId = fav.WordId, // 单词ID
                    Word = word, // 单词原文
                    Translation = translation // 词性+释义
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