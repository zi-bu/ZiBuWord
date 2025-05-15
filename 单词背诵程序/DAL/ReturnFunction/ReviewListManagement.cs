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
        var random = new Random();
        return new Word(random.Next(1, 6));
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