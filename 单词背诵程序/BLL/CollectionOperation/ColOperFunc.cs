using DAL;



namespace BLL.CollectionOperation;

public class ColOperFunc
{
    public static void ListShuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

    }
    
    //字符串列表加法的定义 a1+b1 a2+b2
    public static List<string> StringListAddition(List<string> a, List<string> b)
    {
        if(a == null || b == null)
            throw new ArgumentNullException("List cannot be null");
        int count = Math.Min(a.Count, b.Count);
        List<string> result = new List<string>();
        for (int i = 0; i < count; i++)
        {
            result.Add(a[i] + b[i]);
        }
        return result;
    }

    
    
    
    
    
    
    public static List<IWord> GenerateTestList()
    {
        //生成测试列表
        IWord w1 = new Word();
        IWord w2 = new Word();
        IWord w3 = new Word();
        IWord w4 = new Word();
        w1.word = "test";
        w1.pos = "n1.";
        w1.translation = "测试1";
        w1.phrase = "测试一下";
        w2.word = "test";
        w2.pos = "n2.";
        w2.translation = "测试2";
        w2.phrase = "测试一下";
        w3.word = "test";   
        w3.pos = "n3.";
        w3.translation = "测试3";
        w3.phrase = "测试一下";
        w4.word = "test";
        w4.pos = "n4.";
        w4.translation = "测试4";
        w4.phrase = "测试一下";
        List<IWord> tW = new List<IWord>();
        tW.Add(w1);
        tW.Add(w2);
        tW.Add(w3);
        tW.Add(w4);
        return tW;
    }
}


