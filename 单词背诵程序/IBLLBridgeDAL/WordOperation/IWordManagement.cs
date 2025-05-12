namespace IBLLBridgeDAL.WordOperation;

public interface IWordManagement
{
    IWord GetRandomWordForReciter(); //获取随机单词
    void RemoveWordFromeLearningList(string word);//将该单词从学习列表中删除
    void AddWordToReview(IWord word); //添加单词到复习列表 这个时候
}
