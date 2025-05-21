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
        public List<FavoriteWordDetail> GetFavoriteDetails(int userId)
        {
            var favorites = _dal.GetFavorites(userId);
            var result = new List<FavoriteWordDetail>();
            using var db = new DAL.Context.SqlDataContext();
            foreach (var fav in favorites)
            {
                string word = "";
                string translation = "";

                // 1. 先查出单词原文
                switch (fav.DictionaryType)
                {
                    case "CET4":
                        var cet4 = db.CET4.FirstOrDefault(w => w.Id == fav.WordId);
                        if (cet4 != null)
                        {
                            word = cet4.Word;
                        }
                        break;
                    case "CET6":
                        var cet6 = db.CET6.FirstOrDefault(w => w.Id == fav.WordId);
                        if (cet6 != null)
                        {
                            word = cet6.Word;
                        }
                        break;
                    case "HighSchool":
                        var hs = db.HighSchool.FirstOrDefault(w => w.Id == fav.WordId);
                        if (hs != null)
                        {
                            word = hs.Word;
                        }
                        break;
                    case "MiddleSchool":
                        var ms = db.MiddleSchool.FirstOrDefault(w => w.Id == fav.WordId);
                        if (ms != null)
                        {
                            word = ms.Word;
                        }
                        break;
                    case "KY":
                        var ky = db.KY.FirstOrDefault(w => w.Id == fav.WordId);
                        if (ky != null)
                        {
                            word = ky.Word;
                        }
                        break;
                    case "TF":
                        var tf = db.TF.FirstOrDefault(w => w.Id == fav.WordId);
                        if (tf != null)
                        {
                            word = tf.Word;
                        }
                        break;
                    case "SAT":
                        var sat = db.SAT.FirstOrDefault(w => w.Id == fav.WordId);
                        if (sat != null)
                        {
                            word = sat.Word;
                        }
                        break;
                }

                // 2. 获取 Formid
                Formid formid = fav.DictionaryType switch
                {
                    "CET4" => Formid.CET4,
                    "CET6" => Formid.CET6,
                    "HighSchool" => Formid.HighSchool,
                    "MiddleSchool" => Formid.MiddleSchool,
                    "KY" => Formid.KY,
                    "TF" => Formid.TF,
                    _ => throw new Exception("未知词典类型")
                };

                // 3. 用 Word 类查释义和词性
                string pos = "";
                if (!string.IsNullOrEmpty(word))
                {
                    var wordObj = new DAL.Word(word, formid);
                    var pairs = wordObj.translations.Zip(wordObj.pos, (tran, p) => $"{p}. {tran}");
                    translation = string.Join("; ", pairs);
                }

                result.Add(new FavoriteWordDetail
                {
                    Id = fav.Id,
                    DictionaryType = fav.DictionaryType,
                    WordId = fav.WordId,
                    Word = word,
                    Translation = translation,
                    Pos = pos
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