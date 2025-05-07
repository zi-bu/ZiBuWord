namespace DAL
{
    /// <summary>
    /// 枚举类型，用于表示单词表的编号。<br/>
    /// 例如：CET4 表示四级单词表，CET6 表示六级单词表。
    /// </summary>
    public enum Formid
    {
        CET4 = 1,
        CET6 = 2,
        初中 = 3,
        高中 = 4,
        考研 = 5,
        托福 = 6,
    }
    /// <summary>
    /// 单词搬运工类，计划封装查询单词和获取单词的方法（目前未完全实现）。<br/>
    /// 新增了一个GetWords方法，用于随机获取一个单词。<br/>
    /// 新增了一个FindTranslations方法，用于查找单词的释义。<br/>
    /// 新增了一个FindPhrases方法，用于查找单词的短语。
    /// </summary>
    public static class WordMover
    {
        static Random rd = new Random();// 随机数生成器实例。
        /// <summary>
        /// 参数：一个formid枚举值，用于指定单词来源表。<br/>
        /// 返回值：一个随机单词的字符串。<br/>
        /// 功能：随机获取一个单词，来源于指定单词来源表。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string? GetWord(Formid id)//随机获取一个单词
        {

            using (var db = new SqlDataContext())
            {
                switch (id)
                {
                    case Formid.CET4:
                        {
                            int count = rd.Next(0, db.CET4.Count() - 1);//随机生成索引
                            var word = db.CET4.ElementAt(count);//跳过count个元素，获取第count+1个元素
                            return word.word;
                        }
                    case Formid.CET6:
                        {
                            int count = rd.Next(0, db.CET6.Count() - 1);
                            var word = db.CET6.ElementAt(count);
                            return word.word;
                        }
                    case Formid.初中:
                        {
                            int count = rd.Next(0, db.初中.Count() - 1);
                            var word = db.初中.ElementAt(count);
                            return word.word;
                        }

                    case Formid.高中:
                        {
                            int count = rd.Next(0, db.高中.Count() - 1);
                            var word = db.高中.ElementAt(count);
                            return word.word;
                        }
                    case Formid.考研:
                        {
                            int count = rd.Next(0, db.CET4.Count() - 1);
                            var word = db.CET4.ElementAt(count);
                            return word.word;
                        }
                    case Formid.托福:
                        {
                            int count = rd.Next(0, db.托福.Count() - 1);
                            var word = db.托福.ElementAt(count);
                            return word.word;
                        }
                    default:
                        return null;
                }
            }
        }

        public static string? FindTranslations(string word, Formid id)//在对应表查找单词翻译
        {
            using (var db = new SqlDataContext())
            {
                switch (id)
                {
                    case Formid.CET4:
                        {
                            return db.CET4.Where(s => s.word == word).First().translations;
                        }
                    case Formid.CET6:
                        {
                            return db.CET6.Where(s => s.word == word).First().translations;
                        }
                    case Formid.初中:
                        {
                            return db.初中.Where(s => s.word == word).First().translations;
                        }

                    case Formid.高中:
                        {
                            return db.高中.Where(s => s.word == word).First().translations;
                        }
                    case Formid.考研:
                        {
                            return db.考研.Where(s => s.word == word).First().translations;
                        }
                    case Formid.托福:
                        {
                            return db.托福.Where(s => s.word == word).First().translations;
                        }
                    default:
                        return null;
                }
            }
        }

        public static string? FindPhrases(string word, Formid id)//在对应表查找单词短语
        {
            using (var db = new SqlDataContext())
            {
                switch (id)
                {
                    case Formid.CET4:
                        {
                            return db.CET4.Where(s => s.word == word).First().phrases;
                        }
                    case Formid.CET6:
                        {
                            return db.CET6.Where(s => s.word == word).First().phrases;
                        }
                    case Formid.初中:
                        {
                            return db.初中.Where(s => s.word == word).First().phrases;
                        }

                    case Formid.高中:
                        {
                            return db.高中.Where(s => s.word == word).First().phrases;
                        }
                    case Formid.考研:
                        {
                            return db.考研.Where(s => s.word == word).First().phrases;
                        }
                    case Formid.托福:
                        {
                            return db.托福.Where(s => s.word == word).First().phrases;
                        }
                    default:
                        return null;
                }
            }
        }
    }
}

