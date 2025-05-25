using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace DAL;

/// <summary>
///     实现IWordManagement接口<br />
///     本类用于管理单词
/// </summary>
public class WordManagement : IWordManagement
{
    /// <summary>
    /// 获取随机单词的IWord实例(按照进度获取单词，游客除外)
    /// </summary>
    /// <returns></returns>
    public IWord GetRandomWordForReciter()
    {
        if (UserDataNow.NowUser == null) return new Word(1);//游客模式
        
        return new Word(UserDataNow.Progress++,UserDataNow.userDictionarySelect);//创建单词，将临时进度加一
    }

    /// <summary>
    /// 移除学习列表中的单词
    /// </summary>
    /// <param name="word"></param>
    public void RemoveWordFromeLearningList(string word)
    {
    }

    /// <summary>
    /// 把单词添加到复习列表中<br />
    /// </summary>
    /// <param name="word"></param>
    public void AddWordToReview(IWord word)
    {
        if(UserDataNow.NowUser == null) return;
        WordMover.AddReviewWord(UserDataMover.GetUserId(UserDataNow.NowUser),
                                word.word,
                                WordMover.GetWordId(word.word,UserDataNow.userDictionarySelect),
                                UserDataNow.userDictionarySelect);
    }

}