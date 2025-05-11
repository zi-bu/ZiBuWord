namespace IBLLBridgeDAL.WordOperation;

public interface IWordManagement
{
    IWord GetWord();
    void AddWordToReview(IWord word);
    void RemoveWordFromReview(IWord word);
}