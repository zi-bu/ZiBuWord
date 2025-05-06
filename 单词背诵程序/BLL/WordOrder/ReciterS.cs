using GlobalIterface;

using IUIBridgeBLL;
using static BLL.CollectionOperation.ColOperFunc;

namespace BLL.WordOrder;


public class ReciterS:IBetweenUiAndBll
{
    static string? correctword;
    static string? correctwordtrans;
    static List<string> selectionlisttrans = new List<string>();
    static List<string> selectionlist = new List<string>();
    //字段部分：
    //正确答案的单词
    //正确答案的翻译 
    //已打乱单词序列 长度为4 词性+翻译
    //已打乱单词序列 长度为4 翻译

   
    
    public void InitializeList(List<IWord> tempWordList)
    {
        correctword = tempWordList[0].word;
        correctwordtrans = tempWordList[0].translation;
        //正确答案初始化完成
        
        List<IWord> oringnallist = new List<IWord>();
        oringnallist = tempWordList.ToList();
        ListShuffle(oringnallist);
        //完成对原始列表的洗牌
        
        List<string> tempPoS = new List<string>();
        tempPoS = oringnallist.Select(w => w.pos).ToList();
        selectionlisttrans = oringnallist.Select(w => w.translation).ToList();
        selectionlist = (StringListAddition(tempPoS, selectionlisttrans)).ToList();
        //洗牌后的结果 做成词性和翻译的拆分 依次被赋予至字段上
        
    }

    public void ReleaseList()
    {
        correctword = null;
        correctwordtrans = null;
        selectionlisttrans.Clear();
        selectionlist.Clear();
        //释放列表
    }

    //方法部分：
    //1.初始化选择器
    //2.释放选择器


}