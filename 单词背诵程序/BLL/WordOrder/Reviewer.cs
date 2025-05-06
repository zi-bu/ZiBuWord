using IUIBridgeBLL;

namespace BLL.WordOrder;

public class Reviewer:ReciterTf, IReviewer
{
    internal static List<int> NumOfTure = new List<int>()
    {
        0,//0
        0,//1
        0,//2
        0,//3
        0,//4
        0,//5
        0,//6
        0,//7
        0,//8
        0,//9
    }; //用于记录每个单词复习的次数
    

    public new void IsRemove()
    {
        if (NumOfTure[Index] >= 3)
        {
            //这里将会插入一个函数用于将已认识的函数塞入一个列表
            //用于后续存入到复习的数据表中
            NumOfTure.RemoveAt(Index);
            _loopList.RemoveAt(Index);
        }
    }
    //对复习器中的移表进行重载
    
    public new void IndexPlus(bool isKnow)
    {
        if (isKnow)
            NumOfTure[Index]++;
        IsRemove();
        Index++;
        if (Index >= _loopList.Count)
            Index = 0;
    }
    //对于选择认识 or 不认识的方法重载
    
    public void IfInsertToDal()
    {
        
    }
}