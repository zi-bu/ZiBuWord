using IBLLBridgeDAL;

namespace BLL;

public class SelectionOrder(IWord w1,IWord w2, IWord w3, IWord w4)
{
    public IWord AccurateWord { get; private set; } = w1; //正确的
    public List<IWord> Selection { get; private set; } = ShuffleList<IWord>([w1, w2, w3, w4]);
    //打乱传入元素作为将被显示的对象的对象

    private static List<T> ShuffleList<T>(List<T> inputList)//洗牌算法
    {
        var random = new Random();
        for (var i = inputList.Count - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (inputList[i], inputList[j]) = (inputList[j], inputList[i]);
        }
        return inputList;
    }
    
    
}