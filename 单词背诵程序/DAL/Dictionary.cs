using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// 数据库表的实体类主表的基类。(一个模版的模板)
    /// 这个类对应数据库中的Words的结构，包含单词，释义和短语的集合。<br/>
    /// </summary>
    public abstract class WordForm
    {
        public int Id { get; set; } // 单词编号
        required public string Word { get; set; } // 单词

        required public List<TranslationForm> Translations { get; set; } // 释义列表
        public List<PhraseForm>? Phrases { get; set; } // 短语列表
    }
    /// <summary>
    /// 数据库表的实体类翻译表的基类。
    /// 这个类对应数据库中的Translations的结构，包含单词翻译，对应翻译的词性。<br/>
    /// </summary>
    public abstract class TranslationForm
    {
        public int Id { get; set; }

        required public string Translation { get; set; }

        required public string TyPe { get; set; }

        public int WordId { get; set; }
        
        required public WordForm WordForm { get; set; }
        
    }
    /// <summary>
    /// 数据库表的实体类短语表的基类。
    /// 这个类对应数据库中的Phrase的结构，包含短语，短语翻译。<br/>
    /// </summary>
    public abstract class PhraseForm
    {
        public int Id { get; set; }

        public string? Phrase { get; set; }

        public string? Translation { get; set; }

        public int WordId { get; set; }
        required public WordForm WordForm { get; set; }

    }

    public class CET4 : WordForm { }
    public class CET4T : TranslationForm { }
    public class CET4P : PhraseForm { }


    public class CET6 : WordForm { }
    public class CET6T : TranslationForm { }
    public class CET6P : PhraseForm { }


    public class HighSchool : WordForm { }
    public class HighSchoolT : TranslationForm { }
    public class HighSchoolP : PhraseForm { }


    public class MiddleSchool : WordForm { }
    public class MiddleSchoolT : TranslationForm { }
    public class MiddleSchoolP : PhraseForm { }


    public class KY : WordForm { }
    public class KYT : TranslationForm { }
    public class KYP : PhraseForm { }


    public class TF : WordForm { }
    public class TFT : TranslationForm { }
    public class TFP : PhraseForm { }

    /// <summary>
    /// 用户表的模型类。<br/>
    /// 这个类对应数据库中的用户表的结构，包含用户编号、用户名和密码等字段。<br/>
    /// 这个类用于存储用户的基本信息。<br/>
    /// 由***子布***创建。<br/>
    /// </summary>
    public class User
    {

        [Key] // 主键
        public int UserID { get; set; } // 用户编号
        [Required] // 必填字段
        public string? UserName { get; set; } // 用户名
        public string? UserPassword { get; set; } // 密码
    }
}
