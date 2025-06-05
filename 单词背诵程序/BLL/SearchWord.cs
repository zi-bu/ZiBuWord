using IBLLBridgeDAL;

namespace BLL;

public class SearchWordEnglish
{

    private readonly IWordQuery _wordQuery;

    public SearchWordEnglish(IWordQuery wordQuery)
    {
        _wordQuery = wordQuery;
    }

    //单词集合 依赖注入

    //调用_wordQuery接口的FindExactWord方法查找单词

    //如果输入为空，返回空列表
    /// <summary>
    ///  查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public List<IWord> SearchEnglish(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return new List<IWord>();
        //检查输入字符串 input 是否为空或仅包含空白字符如果是，则返回一个空的 IWord 列表 

        return _wordQuery.FindWordsByEnglish(input);
    }
}

public class SearchWordChinese
{
    private readonly IWordQuery _wordQuery;

    public SearchWordChinese(IWordQuery wordQuery)
    {
        _wordQuery = wordQuery;
    }

    public List<IWord> SearchChinese(string chinese)
    {
        if (string.IsNullOrWhiteSpace(chinese))
            return new List<IWord>();
        return _wordQuery.FindWordsByChinese(chinese);
    }
}