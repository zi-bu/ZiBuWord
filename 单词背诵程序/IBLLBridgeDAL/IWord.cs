namespace IBLLBridgeDAL
{
    /// <summary>
    /// 单词对象的接口定义，规范单词对象的字段和访问方式。
    /// </summary>
    public interface IWord
    {
        string word { get; } // 单词
        string pos { get; } // 词性 (Part of Speech)
        string translation { get; } // 释义
        string phrase { get; } // 短语

        // 索引器：通过下标访问单词的不同属性。
        string this[int index] { get; }
    }
}
