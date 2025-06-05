using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL;

/// <summary>
///     枚举类型，用于表示单词表的编号。<br />
///     例如：CET4 表示四级单词表，CET6 表示六级单词表。
/// </summary>
public enum Formid
{
    CET4 = 1,
    CET6 = 2,
    MiddleSchool = 3,
    HighSchool = 4,
    KY = 5,
    TF = 6
}

/// <summary>
///     单词搬运工类，计划封装查询单词和获取单词的方法。<br />
///     新增了一个GetWords方法，用于随机获取一个单词。<br />
///     新增了一个FindTranslations方法，用于查找单词的释义。<br />
///     新增了一个FindPhrases方法，用于查找单词的短语。
/// </summary>
public static class WordMover
{
    private static readonly Random rd = new(); // 随机数生成器实例。

    /// <summary>
    ///     参数：一个formid枚举值，用于指定单词来源表。<br />
    ///     返回值：一个随机单词的字符串。<br />
    ///     功能：随机获取一个单词，来源于指定单词来源表。
    /// </summary>
    /// <param name="formid"></param>
    /// <returns></returns>
    public static string GetWord(Formid formid) //随机获取一个单词
    {
        using (var db = new SqlDataContext())
        {
            switch (formid)
            {
                case Formid.CET4:
                    {
                        var count = rd.Next(0, db.CET4.Count() - 1); //随机生成索引
                        var word = db.CET4.ElementAt(count); //跳过count个元素，获取第count+1个元素
                        return word.Word;
                    }
                case Formid.CET6:
                    {
                        var count = rd.Next(0, db.CET6.Count() - 1);
                        var word = db.CET6.ElementAt(count);
                        return word.Word;
                    }
                case Formid.MiddleSchool:
                    {
                        var count = rd.Next(0, db.MiddleSchool.Count() - 1);
                        var word = db.MiddleSchool.ElementAt(count);
                        return word.Word;
                    }

                case Formid.HighSchool:
                    {
                        var count = rd.Next(0, db.HighSchool.Count() - 1);
                        var word = db.HighSchool.ElementAt(count);
                        return word.Word;
                    }
                case Formid.KY:
                    {
                        var count = rd.Next(0, db.KY.Count() - 1);
                        var word = db.KY.ElementAt(count);
                        return word.Word;
                    }
                case Formid.TF:
                    {
                        var count = rd.Next(0, db.TF.Count() - 1);
                        var word = db.TF.ElementAt(count);
                        return word.Word;
                    }
                default:
                    {
                        throw new ArgumentException("未知单词来源表");
                    }
            }
        }
    }
    /// <summary>
    ///     参数：一个formid枚举值，用于指定单词来源表，一个int值，用于指定单词的id。<br />
    ///     返回值：一个单词的字符串。<br />
    ///     功能：获得精确id的单词。
    /// </summary>
    /// <param name="formid"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string GetWord(Formid formid, int id) //获得精确id的单词
    {
        using (var db = new SqlDataContext())
        {
            switch (formid)
            {
                case Formid.CET4:
                    {
                        var word = db.CET4.FirstOrDefault(s => s.Id == id)?.Word;
                        if (word == null) throw new ArgumentException("ID不存在");
                        return word;
                    }
                case Formid.CET6:
                    {
                        var word = db.CET6.FirstOrDefault(s => s.Id == id)?.Word;
                        if (word == null) throw new ArgumentException("ID不存在");
                        return word;
                    }
                case Formid.MiddleSchool:
                    {
                        var word = db.MiddleSchool.FirstOrDefault(s => s.Id == id)?.Word;
                        if (word == null) throw new ArgumentException("ID不存在");
                        return word;
                    }

                case Formid.HighSchool:
                    {
                        var word = db.HighSchool.FirstOrDefault(s => s.Id == id)?.Word;
                        if (word == null) throw new ArgumentException("ID不存在");
                        return word;
                    }
                case Formid.KY:
                    {
                        var word = db.KY.FirstOrDefault(s => s.Id == id)?.Word;
                        if (word == null) throw new ArgumentException("ID不存在");
                        return word;
                    }
                case Formid.TF:
                    {
                        var word = db.TF.FirstOrDefault(s => s.Id == id)?.Word;
                        if (word == null) throw new ArgumentException("ID不存在");
                        return word;
                    }
                default:
                    {
                        throw new ArgumentException("未知单词来源表");
                    }
            }
        }
    }

    /// <summary>
    ///     在对应表查找单词释义。
    ///     将释义和词性赋给到两个列表。
    /// </summary>
    /// <param name="word"></param>
    /// <param name="id"></param>
    /// <param name="translations"></param>
    /// <param name="pos"></param>
    public static void FindTranslations(string word, Formid id, ref List<string> translations, ref List<string> pos)
    {
        //因为翻译和词性没有空值情况，所以不做空处理
        using (var db = new SqlDataContext())
        {
            switch (id)
            {
                case Formid.CET4:
                    {
                        var TureForm = db.CET4.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }

                        break;
                    }
                case Formid.CET6:
                    {
                        var TureForm = db.CET6.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }

                        break;
                    }
                case Formid.MiddleSchool:
                    {
                        var TureForm = db.MiddleSchool.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }

                        break;
                    }

                case Formid.HighSchool:
                    {
                        var TureForm = db.HighSchool.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }

                        break;
                    }
                case Formid.KY:
                    {
                        var TureForm = db.KY.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }

                        break;
                    }
                case Formid.TF:
                    {
                        var TureForm = db.TF.Include(f => f.Translations).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else
                        {
                            translations = TureForm.Translations.Select(t => t.Translation).ToList();
                            pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                        }

                        break;
                    }
                default:
                    {
                        throw new ArgumentException("未知单词来源表");
                    }
            }
        }
    }

    /// <summary>
    ///     在对应表查找短语。
    ///     将短语和短语翻译赋给到两个列表。
    /// </summary>
    /// <param name="word"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static void FindPhrases(string word, Formid id, ref List<string>? phrases, ref List<string>? phraseTranslations) //在对应表查找单词短语
    {
        using (var db = new SqlDataContext())
        {
            switch (id)
            {
                case Formid.CET4:
                    {
                        var TureForm = db.CET4.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        } //数据库表存在没有短语的情况。
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }

                        break;
                    }
                case Formid.CET6:
                    {
                        var TureForm = db.CET6.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        }
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }

                        break;
                    }
                case Formid.MiddleSchool:
                    {
                        var TureForm = db.MiddleSchool.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        }
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }

                        break;
                    }

                case Formid.HighSchool:
                    {
                        var TureForm = db.HighSchool.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        }
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }

                        break;
                    }
                case Formid.KY:
                    {
                        var TureForm = db.KY.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        }
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }

                        break;
                    }
                case Formid.TF:
                    {
                        var TureForm = db.TF.Include(f => f.Phrases).FirstOrDefault(s => s.Word == word);
                        if (TureForm == null)
                        {
                        }
                        else if (TureForm?.Phrases == null)
                        {
                        }
                        else
                        {
                            phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                            phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                        }

                        break;
                    }
                default:
                    {
                        throw new ArgumentException("未知单词来源表");
                    }
            }
        }
    }

    /// <summary>
    ///     获取某单词在对应表里的ID
    /// </summary>
    /// <param name="word"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int GetWordId(string word, Formid id)
    {
        using (var db = new SqlDataContext())
        {
            switch (id)
            {
                case Formid.CET4:
                    {
                        return db.CET4.First(s => s.Word == word).Id;
                    }
                case Formid.CET6:
                    {
                        return db.CET6.First(s => s.Word == word).Id;
                    }
                case Formid.MiddleSchool:
                    {
                        return db.MiddleSchool.First(s => s.Word == word).Id;
                    }
                case Formid.HighSchool:
                    {
                        return db.HighSchool.First(s => s.Word == word).Id;
                    }
                case Formid.KY:
                    {
                        return db.KY.First(s => s.Word == word).Id;
                    }
                case Formid.TF:
                    {
                        return db.TF.First(s => s.Word == word).Id;
                    }
                default:
                    {
                        throw new ArgumentException("未知单词来源表");
                    }
            }
        }
    }
    public static List<string> FindWordsByEnglish(string input, Formid formid)
    {
        using (var db = new SqlDataContext())
        {
            List<string> fuzzyList = new();
            switch (formid)
            {
                case Formid.CET4:
                    foreach (var w in db.CET4.Where(w => EF.Functions.Like(w.Word, $"%{input}%")))
                    {
                        if (w.Word.Equals(input, StringComparison.OrdinalIgnoreCase))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.CET6:
                    foreach (var w in db.CET6.Where(w => EF.Functions.Like(w.Word, $"%{input}%")))
                    {
                        if (w.Word.Equals(input, StringComparison.OrdinalIgnoreCase))
                            return new List<string> { w.Word };
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.MiddleSchool:
                    foreach (var w in db.MiddleSchool.Where(w => EF.Functions.Like(w.Word, $"%{input}%")))
                    {
                        if (w.Word.Equals(input, StringComparison.OrdinalIgnoreCase))
                            return new List<string> { w.Word };
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.HighSchool:
                    foreach (var w in db.HighSchool.Where(w => EF.Functions.Like(w.Word, $"%{input}%")))
                    {
                        if (w.Word.Equals(input, StringComparison.OrdinalIgnoreCase))
                            return new List<string> { w.Word };
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.KY:
                    foreach (var w in db.KY.Where(w => EF.Functions.Like(w.Word, $"%{input}%")))
                    {
                        if (w.Word.Equals(input, StringComparison.OrdinalIgnoreCase))
                            return new List<string> { w.Word };
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.TF:
                    foreach (var w in db.TF.Where(w => EF.Functions.Like(w.Word, $"%{input}%")))
                    {
                        if (w.Word.Equals(input, StringComparison.OrdinalIgnoreCase))
                            return new List<string> { w.Word };
                        fuzzyList.Add(w.Word);
                    }
                    break;
                default:
                    throw new ArgumentException("未知单词来源表");
            }
            return fuzzyList;
        }
    }

    public static List<string> FindWordsByChinese(string chinese, Formid formid)
    {
        using (var db = new SqlDataContext())
        {
            List<string> fuzzyList = new();
            switch (formid)
            {
                case Formid.CET4:
                    foreach (var w in db.CET4.Include(f => f.Translations)
                        .Where(w => w.Translations.Any(t => EF.Functions.Like(t.Translation, $"%{chinese}%"))))
                    {
                        if (w.Translations.Any(t => t.Translation == chinese))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.CET6:
                    foreach (var w in db.CET6.Include(f => f.Translations)
                        .Where(w => w.Translations.Any(t => EF.Functions.Like(t.Translation, $"%{chinese}%"))))
                    {
                        Console.WriteLine(w.Word);
                        if (w.Translations.Any(t => t.Translation == chinese))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.MiddleSchool:
                    foreach (var w in db.MiddleSchool.Include(f => f.Translations)
                        .Where(w => w.Translations.Any(t => EF.Functions.Like(t.Translation, $"%{chinese}%"))))
                    {
                        if (w.Translations.Any(t => t.Translation == chinese))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.HighSchool:
                    foreach (var w in db.HighSchool.Include(f => f.Translations)
                        .Where(w => w.Translations.Any(t => EF.Functions.Like(t.Translation, $"%{chinese}%"))))
                    {
                        if (w.Translations.Any(t => t.Translation == chinese))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.KY:
                    foreach (var w in db.KY.Include(f => f.Translations)
                        .Where(w => w.Translations.Any(t => EF.Functions.Like(t.Translation, $"%{chinese}%"))))
                    {
                        if (w.Translations.Any(t => t.Translation == chinese))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;
                case Formid.TF:
                    foreach (var w in db.TF.Include(f => f.Translations)
                        .Where(w => w.Translations.Any(t => EF.Functions.Like(t.Translation, $"%{chinese}%"))))
                    {
                        if (w.Translations.Any(t => t.Translation == chinese))
                            return new List<string> { w.Word }; // 精确匹配，直接返回
                        fuzzyList.Add(w.Word);
                    }
                    break;

                default:
                    throw new ArgumentException("未知单词来源表");
            }
            return fuzzyList;
        }
    }
    
    /// <summary>
    /// 添加单词到复习表
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="word"></param>
    /// <param name="wordid"></param>
    /// <param name="formid"></param>
    public static void AddReviewWord(int userID, string word, int wordid, Formid formid)
    {
        using (var db = new UserContext())
        {
            if (db.ReviewUserWord.Any(w => w.UserID == userID && w.Word == word)) { return; }
            var UserReview = new UserReview
            {
                UserID = userID,
                Repetition = 1,
                Mistake = 0,
                Interval = 1,
                DueDate = DateTime.Now.Date,
                Word = word,
                WordID = wordid,
                Form = formid.ToString()
            };
            db.ReviewUserWord.Add(UserReview);
            db.SaveChanges();
        }
    }

    static int Reviewcount = 0;
    /// <summary>
    /// 获取指定日期的复习单词的ID和来源表
    /// </summary>
    /// <param name="user"></param>
    /// <param name="Form"></param>
    /// <param name="wordid"></param>
    public static void GetReviewWord(string user,DateTime time, ref string Form,ref int wordid)
    {
        using (var db = new UserContext())
        {
            var User = db.UserData.Include(u => u.UserReview).FirstOrDefault(u => u.UserName == user);//获取用户
            if (User!.UserReview == null||User.UserReview.Count() == 0) { throw new ArgumentException("已复习完当日所有单词"); }
            var ReviewWord = User.UserReview.Where(f => f.DueDate.Date <= time.Date);
            if (Reviewcount >= ReviewWord.Count() - 1) { Reviewcount = 0; }
            var word = ReviewWord.ElementAt(Reviewcount++);
            Form = word.Form;
            wordid = word.WordID;
        }
    }
    /// <summary>
    /// 获取指定用户的需要复习的单词数量
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int GetReviewWordCount(string user,DateTime time)
    {
        using (var db = new UserContext())
        {
            var User = db.UserData.Include(u => u.UserReview).FirstOrDefault(u => u.UserName == user);//获取用户
            if (User == null) { throw new ArgumentException("用户不存在"); }
            if (User.UserReview == null || User.UserReview.Count() == 0) { return 0; }
            var ReviewWord = User.UserReview.Where(f => f.DueDate.Date <= time.Date);
            return ReviewWord.Count();
        }
    }
    /// <summary>
    /// 复习完成，更新复习单词
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="word"></param>
    /// <exception cref="ArgumentException"></exception>
    public static void UpdateReviewWord(int userID, string word)
    {
        using (var db = new UserContext())
        {
            var review = db.ReviewUserWord.Where(w => w.UserID == userID && w.Word == word).FirstOrDefault();
            if (review == null) { throw new ArgumentException("该用户的背诵表中没有该单词"); }
            review.Repetition++;
            review.Interval *= 2;
            review.DueDate = DateTime.Now.Date.AddDays(review.Interval);
            db.SaveChanges();
        }
    }
}