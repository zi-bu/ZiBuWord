using System.Collections.Generic;

namespace IBLLBridgeDAL
{
    //专门用于单词查询的接口
    public interface IWordQuery
    {
        IWord? FindExactWordByEnglish(string input);
        List<IWord> FindFuzzyWordsByEnglish(string input);

        IWord? FindExactWordByChinese(string chinese);
        List<IWord> FindFuzzyWordsByChinese(string chinese);
    }
}