using System.Collections.Generic;

namespace IBLLBridgeDAL
{
    //专门用于单词查询的接口
    public interface IWordQuery
    {
        IWord? FindExactWord(string input);
        List<IWord> FindFuzzyWords(string input);
    }
}