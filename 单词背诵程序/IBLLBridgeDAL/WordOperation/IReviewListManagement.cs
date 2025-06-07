namespace IBLLBridgeDAL.WordOperation;

public interface IReviewListManagement
{
    IWord GetRandomWordForReview(); //随机获取复习列表中的单词
    void RemoveWordFromReview(IWord word); //从复习列表中删除单词

    int GetReviewListCount(); //获取需要复习的单词数量
}