using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

/// <summary>
///     数据库表的实体类主表的基类。(一个模版的模板)
///     这个类对应数据库中的Words的结构，包含单词，释义和短语的集合。<br />
/// </summary>
public abstract class WordForm<T, P>
{
    public int Id { get; set; } // 单词编号
    public string Word { get; set; } = null!; // 单词
    public required List<T> Translations { get; set; } // 释义列表
    public List<P>? Phrases { get; set; } // 短语列表
}

/// <summary>
///     数据库表的实体类翻译表的基类。
///     这个类对应数据库中的Translations的结构，包含单词翻译，对应翻译的词性。<br />
/// </summary>
public abstract class TranslationForm<M>
{
    public int Id { get; set; }

    public string Translation { get; set; } = null!;

    public string TyPe { get; set; } = null!;

    public int WordId { get; set; }

    public required M WordForm { get; set; }
}

/// <summary>
///     数据库表的实体类短语表的基类。
///     这个类对应数据库中的Phrase的结构，包含短语，短语翻译。<br />
/// </summary>
public abstract class PhraseForm<M>
{
    public int Id { get; set; }

    public string Phrase { get; set; } = null!;

    public string Translation { get; set; } = null!;

    public int WordId { get; set; }
    public required M WordForm { get; set; }
}

public class CET4 : WordForm<CET4T, CET4P>
{
}

public class CET4T : TranslationForm<CET4>
{
}

public class CET4P : PhraseForm<CET4>
{
}

public class CET6 : WordForm<CET6T, CET6P>
{
}

public class CET6T : TranslationForm<CET6>
{
}

public class CET6P : PhraseForm<CET6>
{
}

public class HighSchool : WordForm<HighSchoolT, HighSchoolP>
{
}

public class HighSchoolT : TranslationForm<HighSchool>
{
}

public class HighSchoolP : PhraseForm<HighSchool>
{
}

public class MiddleSchool : WordForm<MiddleSchoolT, MiddleSchoolP>
{
}

public class MiddleSchoolT : TranslationForm<MiddleSchool>
{
}

public class MiddleSchoolP : PhraseForm<MiddleSchool>
{
}

public class KY : WordForm<KYT, KYP>
{
}

public class KYT : TranslationForm<KY>
{
}

public class KYP : PhraseForm<KY>
{
}

public class TF : WordForm<TFT, TFP> { }

public class TFT : TranslationForm<TF> { }

public class TFP : PhraseForm<TF> { }


public class SAT : WordForm<SATT, SATP> { }
public class SATT : TranslationForm<SAT> { }
public class SATP : PhraseForm<SAT> { }

/// <summary>
///     用户表的模型类。<br />
///     这个类对应数据库中的用户表的结构，包含用户编号、用户名和密码等字段。<br />
///     这个类用于存储用户的基本信息。<br />
///     由***子布***创建。<br />
/// </summary>
public class User
{
    [Key] // 主键
    public int UserID { get; set; } // 用户编号

    [Required] // 必填字段
    public string? UserName { get; set; } // 用户名

    public string? UserPassword { get; set; } // 密码

    // 添加导航属性
    public virtual UserWord? UserWord { get; set; }

    public List<UserReview>? UserReview { get; set; }
}
public class UserWord
{
    [Key] // 主键
    public int ID { get; set; }
    // 定义外键关系
    [ForeignKey("User")]
    public int UserID { get; set; }
    [Required] // 必填字段
    public int MiddleSchool { get; set; }
    public int HighSchool { get; set; }
    public int CET4 { get; set; }
    public int CET6 { get; set; }
    public int KY { get; set; }
    public int TF { get; set; }
    public int SAT { get; set; }

    // 导航属性 - 指向与此词汇记录关联的单个用户
    public virtual User? User { get; set; }
    //保证一个用户对应一个用户ID  
}

/// <summary>
///     用户收藏的单词表的模型类。<br />
///     这个类对应数据库中的用户收藏的单词表的结构，包含用户编号、单词和词典类型等字段。<br />
///     这个类用于存储用户收藏的单词信息。<br />
/// </summary>
public class FavoriteWord
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int WordId { get; set; } // 单词编号
    public string DictionaryType { get; set; } = null!;// 词典类型
}

public class UserReview
{
    public int ID { get; set; }

    public int UserID { get; set; }

    public int Repetition { get; set; }// 复习次数

    public int Mistake { get; set; }// 错误次数

    public int Interval { get; set; }// 间隔

    public DateTime DueDate { get; set; }// 下次复习日期

    public string Word { get; set; } = null!;

    public int WordID { get; set; } // 单词编号

    public string Form { get; set; } = null!; // 来源单词表
    //此处的问题在于如果多个表都有一个单词，但翻译的详尽不同。暂时假设我们的单词表只有单词不同，没有翻译短语的区别。

    // 导航属性
    public virtual User? User { get; set; }
}