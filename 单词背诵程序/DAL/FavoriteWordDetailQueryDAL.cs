using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;

namespace DAL
{
    public class FavoriteWordDetailQueryDAL
    {
        /// <summary>
        /// 根据词典类型和单词ID获取单词原文、词性、释义
        /// </summary>
        public (string Word, List<string> Pos, List<string> Translations) GetWordDetail(string dictType, int wordId)
        {
            using var db = new SqlDataContext();
            switch (dictType)
            {
                case "CET4":
                    var cet4 = db.CET4.FirstOrDefault(w => w.Id == wordId);
                    if (cet4 != null)
                    {
                        var translations = cet4.Translations.Select(t => t.Translation).ToList();
                        var pos = cet4.Translations.Select(t => t.TyPe).ToList();
                        return (cet4.Word, pos, translations);
                    }
                    break;
                case "CET6":
                    var cet6 = db.CET6.FirstOrDefault(w => w.Id == wordId);
                    if (cet6 != null)
                    {
                        var translations = cet6.Translations.Select(t => t.Translation).ToList();
                        var pos = cet6.Translations.Select(t => t.TyPe).ToList();
                        return (cet6.Word, pos, translations);
                    }
                    break;
                case "HighSchool":
                    var hs = db.HighSchool.FirstOrDefault(w => w.Id == wordId);
                    if (hs != null)
                    {
                        var translations = hs.Translations.Select(t => t.Translation).ToList();
                        var pos = hs.Translations.Select(t => t.TyPe).ToList();
                        return (hs.Word, pos, translations);
                    }
                    break;
                case "MiddleSchool":
                    var ms = db.MiddleSchool.FirstOrDefault(w => w.Id == wordId);
                    if (ms != null)
                    {
                        var translations = ms.Translations.Select(t => t.Translation).ToList();
                        var pos = ms.Translations.Select(t => t.TyPe).ToList();
                        return (ms.Word, pos, translations);
                    }
                    break;
                case "KY":
                    var ky = db.KY.FirstOrDefault(w => w.Id == wordId);
                    if (ky != null)
                    {
                        var translations = ky.Translations.Select(t => t.Translation).ToList();
                        var pos = ky.Translations.Select(t => t.TyPe).ToList();
                        return (ky.Word, pos, translations);
                    }
                    break;
                case "TF":
                    var tf = db.TF.FirstOrDefault(w => w.Id == wordId);
                    if (tf != null)
                    {
                        var translations = tf.Translations.Select(t => t.Translation).ToList();
                        var pos = tf.Translations.Select(t => t.TyPe).ToList();
                        return (tf.Word, pos, translations);
                    }
                    break;
                case "SAT":
                    var sat = db.SAT.FirstOrDefault(w => w.Id == wordId);
                    if (sat != null)
                    {
                        var translations = sat.Translations.Select(t => t.Translation).ToList();
                        var pos = sat.Translations.Select(t => t.TyPe).ToList();
                        return (sat.Word, pos, translations);
                    }
                    break;
            }
            return ("", new List<string>(), new List<string>());
        }
    }
}
