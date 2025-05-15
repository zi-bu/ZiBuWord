namespace IBLLBridgeDAL.WordOperation;

public interface IReviewListManagement
{
    IWord GetRandomWordForReview(); //随机获取复习列表中的单词
    void RemoveWordFromReview(IWord word); //从复习列表中删除单词
}