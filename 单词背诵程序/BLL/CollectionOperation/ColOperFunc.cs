using DAL;
using IBLLBridgeDAL;


namespace BLL.CollectionOperation;

public static class ColOperFunc
{
    public static void ListShuffle<T>(List<T> list)
    {
        var rng = new Random();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }

    }
    
    //字符串列表加法的定义 a1+b1 a2+b2
    public static List<string> StringListAddition(List<string> a, List<string> b)
    {
        if (a == null || b == null)
        {
            var message = "参数不能为空";
            throw new ArgumentNullException(message);
        }
        var count = Math.Min(a.Count, b.Count);
        return Enumerable
            .Range(0, count)
            .Select(i => a[i] + b[i])
            .ToList();
    }
    
    //以下是两种测试列表函数 
    public static List<IWord> GenerateTestList(int numOfWords)
    {
        return Enumerable
            .Range(0, numOfWords)
            .Select(i => new Word()
            {
                word = "test" + i,
                pos = "n" + i,
                translation = "测试" + i,
                phrase = "测试一下" + i
            } as IWord).ToList();
    }
}


