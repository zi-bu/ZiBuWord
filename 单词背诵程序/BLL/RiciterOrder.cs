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
    public static void CreateOrRefreshNewWordList()
    {
        WordList = Enumerable
            .Range(0, 10)
            .Select(_ => WordManagement.GetRandomWordForReciter())
            .ToList();
    }
}