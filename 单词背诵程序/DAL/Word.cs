using IBLLBridgeDAL;
namespace DAL
{
    /// <summary>
    /// 构造函数：输入formid枚举对应int值,即可获得指定单词表的随机单词;<br/>
    /// 实现 IWord 接口的类，用于封装单词对象;<br/>
    /// </summary>
    public class Word : IWord
    {
     
        //单词的各种属性
        
        public string word { get; private set; } // 单词
        public List<string> pos
        {
            get
            {
                return Pos;
            } 
            private set 
            {
                Pos = value;
            }
        } // 词性
        public List<string> translations
        {
            get
            {
                return Translations;
            }
            private set
            {
                translations = Translations;
            }
        }// 释义
        public List<string>? phrases
        {
            get
            {
                return Phrases;
            }
            private set
            {
                Phrases = value;
            }
        }// 短语
        public List<string>? phraseTranslations
        {
            get
            {
                return PhraseTranslations;
            }
            private set
            {
                PhraseTranslations = value;
            }
        }// 短语翻译



        //因为属性本质上是方法，而方法不能ref传入，所以为了传值，这里列出了字段；
        private List<string> Pos = new List<string>();
        private List<string> Translations = new List<string>();
        private List<string>? Phrases = new List<string>();
        private List<string>? PhraseTranslations = new List<string>();

        private Formid tableid; // 单词来源的枚举编号。

        /// <summary>
        /// 构造函数：通过枚举编号指定单词来源;
        /// </summary>
        public Word(int id)
        {
            tableid = (Formid)id;
            word = WordMover.GetWord(tableid);
            WordMover.FindTranslations(word, tableid,ref Translations,ref Pos);
            WordMover.FindPhrases(word, tableid, ref Phrases, ref PhraseTranslations);
        }
    }
}

