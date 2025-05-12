using System.Collections;
namespace IBLLBridgeDAL.WordOperation;

public interface IWordManagement
{
    IWord GetRandomWord();//获取随机单词
    IWord GetWord(string word);//获取精确单词对象
    List<string> GetWordTrans(string word);//获取单词翻译列表
    void AddWordToReview(IWord word);//添加单词到复习列表
    void RemoveWordFromReview(IWord word);//从复习列表中删除单词
}