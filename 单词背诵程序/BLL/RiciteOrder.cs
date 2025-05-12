using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;
namespace BLL;

public static class RiciteOrder
{
    public static int Index = 0;

    //导入一个随机的单词列表
    public static IWordManagement 接口实现占位 { get; } //实现接口注入

    public static List<IWord> WordList { get; private set; } = Enumerable
        .Range(0, 10)
        .Select(_ => 接口实现占位.GetRandomWordForReciter())
        .ToList();

    //创建一个单词列表的认识标记
    public static void CreateOrRefreshNewWordList()
    {
        WordList = Enumerable
            .Range(0, 10)
            .Select(_ => 接口实现占位.GetRandomWordForReciter())
            .ToList();
    }
}