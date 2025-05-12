using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;


namespace BLL;

public class Order
{
    public static IWordManagement 接口实现占位 { get;  }//实现接口注入
    List<IWord> WordList {get;} = Enumerable
        .Range(0, 10)
        .Select(_=>接口实现占位.GetRandomWordForReciter())
        .ToList();
    //导入一个随机的单词列表
}