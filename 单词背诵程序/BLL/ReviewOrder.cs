using DAL.ReturnFunction;
using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

public static class ReviewOrder
{
    public static int Index;

    //导入一个随机的单词列表
    private static IReviewListManagement ReviewListManagement { get; } = new ReviewListManagement();

    public static List<IWord> WordList { get; private set; } = Enumerable
        .Range(0, 10)
        .Select(_ => ReviewListManagement.GetRandomWordForReview())
        .ToList();

    //创建一个单词列表的认识标记
    private static void CreateOrRefreshNewWordList()
    {
        WordList = Enumerable
            .Range(0, 10)
            .Select(_ => ReviewListManagement.GetRandomWordForReview())
            .ToList();
    }

    public static void ResetIndex() //索引回拨判别
    {
        Index++; //趋势递增
        Console.WriteLine($"这里递增了,Index为{Index},剩余元素{WordList.Count()}");
        if (!(Index < WordList.Count)) //序列索引回拨
            Index = 0;
    }

    public static bool CheckOutWordList() //检验是否完成当前队列的背诵
    {
        if (WordList.Count != 0) return false; //检验是否完成当前队列的背诵
        Index = 0; //回拨索引
        Console.WriteLine("队列已经完成了");
        CreateOrRefreshNewWordList(); //创建新的列表
        return true;
    }
}