using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;
using System.Data;

namespace DAL.ReturnFunction;

/// <summary>
///     实现IReviewListManagement接口<br />
///     本类用于管理复习单词<br />
/// </summary>
public class ReviewListManagement : IReviewListManagement
{
    /// <summary>
    /// 获取随机单词进行复习<br />
    /// </summary>
    /// <returns></returns>
    public IWord GetRandomWordForReview()
    {
        if (UserDataNow.NowUser == null) { return new Word(UserDataNow.userDictionarySelect); }
        int userId = 0;
        string Form = null!;
        DateTime date = new DateTime(2025,5,25);
        WordMover.GetReviewWord(UserDataNow.NowUser, date, ref Form, ref userId);
        Formid wordform = (Formid)Enum.Parse(typeof(Formid), Form);
        return (new Word(userId,wordform)  as IWord);
    }

    /// <summary>
    /// 从复习单词列表中移除单词<br />
    /// 实际上是背完单词的处理
    /// </summary>
    /// <param name="word"></param>
    public void RemoveWordFromReview(IWord word)
    {
        if(UserDataNow.NowUser == null) { return; }
        WordMover.UpdateReviewWord(UserDataMover.GetUserId(UserDataNow.NowUser),word.word);
    }
}