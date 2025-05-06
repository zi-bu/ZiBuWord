using IBLLBridgeDAL;
using IUIBridgeBLL;
using static BLL.CollectionOperation.ColOperFunc;

namespace BLL.WordOrder;

public class ReciterTf : IReciterTf
{
    internal static int Index { set; get; }
    
    internal static List<IWord> _loopList = new List<IWord>();
    //用于背诵的循环列表
    private static List<bool> _loopListflag = new List<bool>()
    {
        false,//0
        false,//1
        false,//2
        false,//3
        false,//4
        false,//5
        false,//6
        false,//7
        false,//8
        false,//9
    };
    //每一个列表对应的标记
    public void InitializeList()
    {
        _loopList = GenerateTestList2().ToList();
    }
    //对于背诵序列的初始化
    
    public void ReleaseList()
    {
        _loopList.Clear();
        _loopListflag.Clear();
        Index = 0;
    }
    //对于背诵序列的释放

    public string GetWord()
    {
        return _loopList[Index].word;
    }
    public string GetWordTranslation()
    {
        return _loopList[Index].translation;
    }
    public string GetWordPos()
    {
        return _loopList[Index].pos;
    }
    public string GetWordPhrase()
    {
        return _loopList[Index].phrase;
    }
    public string GetWordPhraseTranslation()
    {
        return _loopList[Index].phraseTranslation;
    }
    //获取函数的实现

    public void IsRemove()
    {
        if (_loopListflag[Index])
        {
            //这里将会插入一个函数用于将已认识的函数塞入一个列表
            //用于后续存入到复习的数据表中
            _loopListflag.RemoveAt(Index);
            _loopList.RemoveAt(Index);
            
        }
    }
    //判断某个索引中是否应该移除
    public void IndexPlus(bool isKnow)
    {
        if (isKnow)
            _loopListflag[Index] = true;
        IsRemove();
        Index++;
        if (Index >= _loopList.Count)
            Index = 0;
    }
    //索引器递增 并且已经认识的单词将会被移除序列
        
}
    

