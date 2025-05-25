using System.Collections.Generic;

namespace IBLLBridgeDAL
{
    //专门用于单词查询的接口
    public interface IWordQuery
    {
        List<IWord> FindWordsByEnglish(string input);
        List<IWord> FindWordsByChinese(string chinese);
    }
}