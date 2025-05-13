using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

public class ReviewOrder
{
    public static int Index = 0;

    //导入一个随机的单词列表
    public static IReviewListManagement 接口实现占位 { get; } //实现接口注入

    public static List<IWord> WordList { get; private set; } = Enumerable
        .Range(0, 10)
        .Select(_ => 接口实现占位.GetRandomWordForReview())
        .ToList();

    //创建一个单词列表的认识标记
    public static void CreateOrRefreshNewWordList()
    {
        WordList = Enumerable
            .Range(0, 10)
            .Select(_ => 接口实现占位.GetRandomWordForReview())
            .ToList();
    }
    
    public static void ResetIndex()//索引回拨判别
    {
        Index++; //趋势递增
        if (!(Index < WordList.Count)) //序列索引回拨
            Index = 0;
    }
    
    public static bool CheckOutWordList()//检验是否完成当前队列的背诵
    {
        if (WordList.Count == 0) //检验是否完成当前队列的背诵
        {
            Index = 0; //回拨索引
            CreateOrRefreshNewWordList(); //创建新的列表
            return true;
        }

        return false;
    }
}