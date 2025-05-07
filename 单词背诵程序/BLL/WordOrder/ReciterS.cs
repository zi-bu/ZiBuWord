

using IBLLBridgeDAL;
using IUIBridgeBLL;
using static BLL.CollectionOperation.ColOperFunc;


namespace BLL.WordOrder;

//这是一页选择器，一页就只执行一次背诵，
//核心在于 通过背诵页面初始化InitializeList()启动 和 按钮触发CheckAnswer()来结束
//设计上为10个单词为一次背诵序列
public class ReciterS : IReciterS
{
    private static int _numofloop;
    private static string? _correctword;
    private static string? _correctwordtrans;
    private static List<string> _selectionlisttrans = new List<string>();
    private static List<string> _selectionlist = new List<string>();
    //字段部分：
    //正确答案的单词
    //正确答案的翻译 
    //已打乱单词序列 长度为4 词性+翻译
    //已打乱单词序列 长度为4 翻译


    public void InitializeList()
    {
        InitializeList(GenerateTestList(4));
    }//之后将会把参数换为由 索引0为正确单词 索引123为混淆单词的单词对象列表

    
    private void InitializeList(List<IWord> tempWordList)
    {
        
        _correctword = tempWordList[0].word;
        _correctwordtrans = tempWordList[0].translation;
        //正确答案初始化完成
        
        List<IWord> oringnallist = new List<IWord>();
        oringnallist = tempWordList.ToList();
        ListShuffle(oringnallist);
        //完成对原始列表的洗牌
        
        List<string> tempPoS = new List<string>();
        tempPoS = oringnallist.Select(w => w.pos).ToList();
        _selectionlisttrans = oringnallist.Select(w => w.translation).ToList();
        _selectionlist = (StringListAddition(tempPoS, _selectionlisttrans)).ToList();
        //洗牌后的结果 做成词性和翻译的拆分 依次被赋予至字段上
    }

    public void ReleaseList()
    {
        _correctword = null;
        _correctwordtrans = null;
        _selectionlisttrans.Clear();
        _selectionlist.Clear();
        //释放列表
    }

    public List<string> GetList()
    {
        return _selectionlisttrans;
    }
    //向UI层发送展示列表

    public bool CheckAnswer(string answer)
    {
        _numofloop = _numofloop + 1;
        if (_correctwordtrans == _selectionlisttrans[_selectionlist.IndexOf(answer)])
            return true;
        ReleaseList();
        return false;
    }
    //答案检查 真为对 假为错
    
    public bool IsTimeNext()
    {
        if(_numofloop == 10)
        {
            _numofloop = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    //判断是否可以进入下一个界面
    //如果可以则会返回为真 并且清空计数器
    
    //方法部分：
    //1.初始化选择器
    //2.释放选择器


}