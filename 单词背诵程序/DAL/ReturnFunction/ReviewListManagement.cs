using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace DAL.ReturnFunction;

/// <summary>
///     实现IReviewListManagement接口<br />
///     本类用于管理复习单词<br />
/// </summary>
public class ReviewListManagement : IReviewListManagement
{
    /// <summary>
    ///     获取随机单词进行复习<br />
    /// </summary>
    /// <returns></returns>
    public IWord GetRandomWordForReview()
    {
        return new Word(DictionarySelect.userDictionarySelect);
    }

    /// <summary>
    ///     添加单词到复习列表<br />
    /// </summary>
    /// <param name="word"></param>
    public void RemoveWordFromReview(IWord word)
    {
        //先挂着
    }
}