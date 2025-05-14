using DAL.ReturnFunction;
using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

public class ReviewClass(IWord w1)
{
    private static IReviewListManagement ReviewListManagement { get; } = new ReviewListManagement();//接口注入
    public IWord Word { get; } = w1;//用于背诵的单词对象导入

    public void RemoveWordReviewList()
    {
        ReviewOrder.WordList.RemoveAt(ReviewOrder.Index);
        ReviewListManagement.RemoveWordFromReview(Word);
    }
    
    public string OutPutWordInfo()//输出单词其他信息
    {
        return
            "上一个单词的信息有:\n" +
            $"{Word.word}" +
            $".{HandleOtherInfo(Word.pos)}" +
            $"{HandleOtherInfo(Word.translations)}" +
            $"{HandleOtherInfo(Word.phrases)}" +
            $"{HandleOtherInfo(Word.phraseTranslations)}";
    }

    private string HandleOtherInfo(List<string>? info)
    {
        if (info == null || info.Count == 0)
            return string.Empty;

        var sb = new System.Text.StringBuilder();
        foreach (var str in info)
        {
            sb.AppendLine(str);
        }
        return sb.ToString();
    }
}