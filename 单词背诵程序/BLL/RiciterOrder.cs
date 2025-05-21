using DAL;
using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

public static class RiciterOrder
{
    public static int Index = 0;

    //导入一个随机的单词列表
    private static IWordManagement WordManagement { get; } = new WordManagement(); //实现接口注入

    public static List<IWord> WordList { get; private set; } = Enumerable
        .Range(0, 10)
        .Select(_ => WordManagement.GetRandomWordForReciter())
        .ToList();

    //创建一个单词列表的认识标记
    public static void RemoveWordFromRiciterList()
    {
        Console.WriteLine("即将删除单词" + WordList[Index].word + "的信息,索引为" + Index);
        WordList.RemoveAt(Index);
    }
    //从单词列表中删除单词
    public static void CreateOrRefreshNewWordList()
    {
        WordList = Enumerable
            .Range(0, 10)
            .Select(_ => WordManagement.GetRandomWordForReciter())
            .ToList();
    }
    public static void CheckBoundary()//检查边界
    {
        Console.WriteLine("现在的索引是" + Index);
        Console.WriteLine("现在的单词列表长度是" + WordList.Count);
        if (!(Index < WordList.Count)) //序列索引回拨
            Index = 0;
    }
    public static bool CheckEmpty()//检查是否为空
    {
        if (WordList.Count == 0)
        {
            Console.WriteLine("单词列表为空");
            Index = 0;
            return true;
        }
        return false;
    }
}