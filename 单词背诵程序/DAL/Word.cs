using IBLLBridgeDAL;

namespace DAL;

/// <summary>
///     构造函数：输入formid枚举对应int值,即可获得指定单词表的随机单词;<br />
///     实现 IWord 接口的类，用于封装单词对象;<br />
/// </summary>
public class Word : IWord
{


    //因为属性本质上是方法，而方法不能ref传入，所以为了传值，这里列出了字段；
    private List<string>? Phrases = new();
    private List<string>? PhraseTranslations = new();
    private List<string> Pos = new();
    private readonly Formid tableid; // 单词来源的枚举编号。
    private readonly List<string> Translations = new();

    //接口需要的属性
    public string word { get; } // 单词

    public List<string> pos
    {
        get => Pos;
        private set => Pos = value;
    } // 词性

    public List<string> translations
    {
        get => Translations;
        private set => translations = Translations;
    } // 释义

    public List<string>? phrases
    {
        get => Phrases;
        private set => Phrases = value;
    } // 短语

    public List<string>? phraseTranslations
    {
        get => PhraseTranslations;
        private set => PhraseTranslations = value;
    } // 短语翻译

    /// <summary>
    ///  构造某表的一个随机单词
    /// </summary>
    public Word(int id)
    {
        tableid = (Formid)id;
        word = WordMover.GetWord(tableid);
        WordMover.FindTranslations(word, tableid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, tableid, ref Phrases, ref PhraseTranslations);
    }
    /// <summary>
    ///  构造某表的一个随机单词
    /// </summary>
    public Word(Formid id)
    {
        tableid = id;
        word = WordMover.GetWord(tableid);
        WordMover.FindTranslations(word, tableid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, tableid, ref Phrases, ref PhraseTranslations);
    }

    /// <summary>
    ///  构造某表的一个精确单词<br/>
    ///  专门用于模糊查询的构造函数
    /// </summary>
    public Word(string word, Formid formid)
    {
        this.word = word;
        tableid = formid;
        WordMover.FindTranslations(word, formid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, formid, ref Phrases, ref PhraseTranslations);
    }
    /// <summary>
    /// 按照单词id和来源构造单词对象
    /// </summary>
    /// <param name="wordid"></param>
    /// <param name="formid"></param>
    public Word(int wordid, Formid formid)
    {
        tableid = formid;
        word = WordMover.GetWord(formid,wordid);
        WordMover.FindTranslations(word, formid, ref Translations, ref Pos);
        WordMover.FindPhrases(word, formid, ref Phrases, ref PhraseTranslations);
    }
}