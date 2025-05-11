using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// 数据库表的实体类主表的基类。(一个模版的模板)
    /// 这个类对应数据库中的Words的结构，包含单词，释义和短语的集合。<br/>
    /// </summary>
    public abstract class WordForm<T,P>
    {
        public int Id { get; set; } // 单词编号
        required public string Word { get; set; } // 单词

        required public List<T> Translations { get; set; } // 释义列表
        public List<P>? Phrases { get; set; } // 短语列表
    }
    /// <summary>
    /// 数据库表的实体类翻译表的基类。
    /// 这个类对应数据库中的Translations的结构，包含单词翻译，对应翻译的词性。<br/>
    /// </summary>
    public abstract class TranslationForm<M>
    {
        public int Id { get; set; }

        required public string Translation { get; set; }

        required public string TyPe { get; set; }

        public int WordId { get; set; }
        
        required public M WordForm { get; set; }
        
    }
    /// <summary>
    /// 数据库表的实体类短语表的基类。
    /// 这个类对应数据库中的Phrase的结构，包含短语，短语翻译。<br/>
    /// </summary>
    public abstract class PhraseForm<M>
    {
        public int Id { get; set; }

        public string? Phrase { get; set; }

        public string? Translation { get; set; }

        public int WordId { get; set; }
        required public M WordForm { get; set; }

    }

    public class CET4 : WordForm<CET4T, CET4P> { }
    public class CET4T : TranslationForm<CET4> { }
    public class CET4P : PhraseForm<CET4> { }


    public class CET6 : WordForm<CET6T, CET6P> { }
    public class CET6T : TranslationForm<CET6> { }
    public class CET6P : PhraseForm<CET6> { }


    public class HighSchool : WordForm<HighSchoolT, HighSchoolP> { }
    public class HighSchoolT : TranslationForm<HighSchool> { }
    public class HighSchoolP : PhraseForm<HighSchool> { }


    public class MiddleSchool : WordForm<MiddleSchoolT, MiddleSchoolP> { }
    public class MiddleSchoolT : TranslationForm<MiddleSchool> { }
    public class MiddleSchoolP : PhraseForm<MiddleSchool> { }


    public class KY : WordForm<KYT, KYP> { }
    public class KYT : TranslationForm<KY> { }
    public class KYP : PhraseForm<KY> { }


    public class TF : WordForm<TFT, TFP> { }
    public class TFT : TranslationForm<TF> { }
    public class TFP : PhraseForm<TF> { }

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
