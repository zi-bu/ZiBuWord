using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    /// 收藏单词详情查询类
    /// 提供根据词典类型和单词ID获取单词原文、词性和释义的方法
    /// </summary>
    public class FavoriteWordDetailQueryDAL
    {
        /// <summary>
        /// 根据 词典类型和单词ID 获取 单词原文、词性、释义
        /// </summary>
        /// <param name="dictType">词典类型</param>
        /// <param name="wordId">单词ID</param>
        /// <returns>返回一个元组，包含单词原文、词性、释义</returns>
        public (string Word, List<string> Pos, List<string> Translations) GetWordDetail(string dictType, int wordId)
        {
            using var db = new SqlDataContext();
            switch (dictType)
            {
                case "CET4":
                    return GetDetailFromTable(db.CET4.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                case "CET6":
                    return GetDetailFromTable(db.CET6.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                case "HighSchool":
                    return GetDetailFromTable(db.HighSchool.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                case "MiddleSchool":
                    return GetDetailFromTable(db.MiddleSchool.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                case "KY":
                    return GetDetailFromTable(db.KY.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                case "TF":
                    return GetDetailFromTable(db.TF.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                case "SAT":
                    return GetDetailFromTable(db.SAT.Include(w => w.Translations).FirstOrDefault(w => w.Id == wordId));
                default:
                    return ("", new List<string>(), new List<string>());
            }
        }

        /// <summary>
        /// 从指定的单词对象中获取单词原文、词性和释义
        /// </summary>
        /// <param name="wordObj">dynamic动态类型，表示单词对象，可以传null</param>
        /// <returns></returns>
        private (string Word, List<string> Pos, List<string> Translations) GetDetailFromTable(dynamic? wordObj)
        {
            if (wordObj != null)
            {
                var translations = ((IEnumerable<dynamic>)wordObj.Translations)
                    .Select(t => (string)t.Translation).ToList();
                var pos = ((IEnumerable<dynamic>)wordObj.Translations)
                    .Select(t => (string)t.TyPe).ToList();
                return (wordObj.Word, pos, translations);
            }
            return ("", new List<string>(), new List<string>());
        }
    }
}
