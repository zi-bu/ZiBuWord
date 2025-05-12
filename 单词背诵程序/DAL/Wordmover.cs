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
        MiddleSchool = 3,
        Highschool = 4,
        KY = 5,
        TF = 6,
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
        public static string GetWord(Formid id)//随机获取一个单词
        {

            using (var db = new Context.SqlDataContext())
            {
                switch (id)
                {
                    case Formid.CET4:
                        {
                            int count = rd.Next(0, db.CET4.Count() - 1);//随机生成索引
                            var word = db.CET4.ElementAt(count);//跳过count个元素，获取第count+1个元素
                            return word.Word;
                        }
                    case Formid.CET6:
                        {
                            int count = rd.Next(0, db.CET6.Count() - 1);
                            var word = db.CET6.ElementAt(count);
                            return word.Word;
                        }
                    case Formid.MiddleSchool:
                        {
                            int count = rd.Next(0, db.MiddleSchool.Count() - 1);
                            var word = db.MiddleSchool.ElementAt(count);
                            return word.Word;
                        }

                    case Formid.Highschool:
                        {
                            int count = rd.Next(0, db.Highschool.Count() - 1);
                            var word = db.Highschool.ElementAt(count);
                            return word.Word;
                        }
                    case Formid.KY:
                        {
                            int count = rd.Next(0, db.KY.Count() - 1);
                            var word = db.KY.ElementAt(count);
                            return word.Word;
                        }
                    case Formid.TF:
                        {
                            int count = rd.Next(0, db.TF.Count() - 1);
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
        /// 在对应表查找单词释义。
        /// 将释义和词性赋给到两个列表。
        /// </summary>
        /// <param name="word"></param>
        /// <param name="id"></param>
        /// <param name="translations"></param>
        /// <param name="pos"></param>
        public static void FindTranslations(string word, Formid id, ref List<string> translations, ref List<string> pos)
        {
            //因为翻译和词性没有空值情况，所以不做空处理
            using (var db = new Context.SqlDataContext())
            {
                switch (id)
                {
                    case Formid.CET4:
                        {
                            var TureForm = db.CET4.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { }
                            else
                            {
                                translations = TureForm.Translations.Select(t => t.Translation).ToList();
                                pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                            }
                            break;
                        }
                    case Formid.CET6:
                        {
                            var TureForm = db.CET6.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { }
                            else
                            {
                                translations = TureForm.Translations.Select(t => t.Translation).ToList();
                                pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                            }
                            break;
                        }
                    case Formid.MiddleSchool:
                        {
                            var TureForm = db.MiddleSchool.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { }
                            else
                            {
                                translations = TureForm.Translations.Select(t => t.Translation).ToList();
                                pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                            }
                            break;
                        }

                    case Formid.Highschool:
                        {
                            var TureForm = db.Highschool.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { }
                            else
                            {
                                translations = TureForm.Translations.Select(t => t.Translation).ToList();
                                pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                            }
                            break;
                        }
                    case Formid.KY:
                        {
                            var TureForm = db.KY.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { }
                            else
                            {
                                translations = TureForm.Translations.Select(t => t.Translation).ToList();
                                pos = TureForm.Translations.Select(t => t.TyPe).ToList();
                            }
                            break;
                        }
                    case Formid.TF:
                        {
                            var TureForm = db.TF.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { }
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
        /// 在对应表查找短语。
        /// 将短语和短语翻译赋给到两个列表。
        /// </summary>
        /// <param name="word"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void FindPhrases(string word, Formid id, ref List<string>? phrases, ref List<string>? phraseTranslations)//在对应表查找单词短语
        {
            using (var db = new Context.SqlDataContext())
            {

                switch (id)
                {
                    case Formid.CET4:
                        {
                            var TureForm = db.CET4.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { return; }
                            else if (TureForm?.Phrases == null) { return; }//数据库表存在没有短语的情况。
                            else
                            {
                                phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                                phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                            }
                            break;
                        }
                    case Formid.CET6:
                        {
                            var TureForm = db.CET6.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { return; }
                            else if (TureForm?.Phrases == null) { return; }
                            else
                            {
                                phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                                phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                            }
                            break;
                        }
                    case Formid.MiddleSchool:
                        {
                            var TureForm = db.MiddleSchool.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { return; }
                            else if (TureForm?.Phrases == null) { return; }
                            else
                            {
                                phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                                phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                            }
                            break;
                        }

                    case Formid.Highschool:
                        {
                            var TureForm = db.Highschool.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { return; }
                            else if (TureForm?.Phrases == null) { return; }
                            else
                            {
                                phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                                phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                            }
                            break;
                        }
                    case Formid.KY:
                        {
                            var TureForm = db.KY.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { return; }
                            else if (TureForm?.Phrases == null) { return; }
                            else
                            {
                                phrases = TureForm.Phrases.Select(t => t.Phrase).ToList();
                                phraseTranslations = TureForm.Phrases.Select(t => t.Translation).ToList();
                            }
                            break;
                        }
                    case Formid.TF:
                        {
                            var TureForm = db.TF.FirstOrDefault(s => s.Word == word);
                            if (TureForm == null) { return; }
                            else if (TureForm?.Phrases == null) { return; }
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
    }
}

