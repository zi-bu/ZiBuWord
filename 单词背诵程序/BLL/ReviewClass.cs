
using DAL.ReturnFunction;
using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

public class ReviewClass(IWord w1)
{
    private static IReviewListManagement ReviewListManagement { get; } = new ReviewListManagement(); //接口注入
    public IWord Word { get; } = w1; //用于背诵的单词对象导入

    public void RemoveWordReviewList()
    {
        
        
            ReviewOrder.WordList.RemoveAt(ReviewOrder.Index);
            ReviewListManagement.RemoveWordFromReview(Word);
        
    }

    public string OutPutWordInfo() //输出单词其他信息
    {
        return $"{HandleOtherInfo()}";
    }

    private string HandleOtherInfo()
    {
        string? information = null;
        for (var i = 0; i < Word.pos.Count; i++)
        {
            information += "." + Word.pos[i] +" " + Word.translations[i]+"\n";
        }

        if (Word.phrases != null)
            for (var i = 0; i < Word.phrases.Count; i++)
            {
                information += Word.phrases[i] + " " + Word.phraseTranslations?[i] + "\n";
            }

        if (information!=null)
        {
            return information;
        }
        return " ";
    }
}