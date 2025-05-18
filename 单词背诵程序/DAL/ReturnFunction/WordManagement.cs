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
    ///     获取随机单词的IWord实例
    /// </summary>
    /// <returns></returns>
    public IWord GetRandomWordForReciter()
    {
        return new Word(DictionarySelect.userDictionarySelect);
    }

    /// <summary>
    ///     移除学习列表中的单词（事实上不需要）
    /// </summary>
    /// <param name="word"></param>
    public void RemoveWordFromeLearningList(string word)
    {
    }

    /// <summary>
    ///     把单词添加到复习列表中<br />
    /// </summary>
    /// <param name="word"></param>
    public void AddWordToReview(IWord word)
    {
        //未实现
    }

}