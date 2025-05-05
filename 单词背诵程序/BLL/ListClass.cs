namespace BLL;
using static Console;
using DAL;

public class ListClass
{
}

public interface IWordList
{
    /// <summary>
    /// 实现单词队列的接口范式,抽象了单词列公有的行为
    /// </summary>
    List<Word> WordList { get; set; }

    public void RemoveWord(int index); //移除 也许 会改造为移至一个临时队列入库
}

public class ReactionList : IWordList //背诵列表
{
    public List<Word> WordList { get; set; }

    public ReactionList(List<Word> tempWordList) //构造背诵单元的方法
    {
        WordList = tempWordList.ToList();
    }

    public void RemoveWord(int index) //预期在成功释意两次后执行
    {
        WordList.RemoveAt(index);
    }
    //如果仅是实现功能来说，其实直接写成逻辑语句也未尝不可，但是先以类的方式出来理清思路
    //一个问题只有真正着手的时候，才会凸显出设计的作用
}

public class SelectionList : IWordList
{
   
    public List<Word> WordList { get; set; }//单词列模板 初项应该为正确答案
    public List<string> LSelectionList { get; set; }//作为选项的列表模块
    public List<string> LSelectionStringList { get; set; }//作为选项的列表模块只剩翻译的部分，用来做和原模板的元素作为判别


    public SelectionList(List<Word> tempWordList) //构选意单元的方法
    {
        WordList = new List<Word>();

        for (int i = 0; i < 4; i++)
        {
            WordList.Add(tempWordList[i]);//构建WordList模板
        }

        //临时列表进入
        LSelectionList = new List<string>();
        LSelectionStringList = new List<string>();
        //实际的选项列表实例化

        List<string> PosList = new List<string>();
        List<string> TransList = new List<string>();

        PosList = WordList.Select(w1 => w1.pos).ToList();//分别从单词模板提取词性元素
        TransList = WordList.Select(w2 => w2.translation).ToList();//还有翻译元素用于后面的相加

        for (int i = 0; i < 4; i++)
        {
            LSelectionList.Add(PosList[i] + TransList[i]);//生成选项初表 每个元素都是 pos + translation 的串
        }
        
        CollectionOperation.Shuffle(LSelectionList);
        //对生成出的初表进行洗牌
        //此时已经随机排序，选项表LSelectionList已经生成，只需要访问对象用下标[0][1][2][3]访问即可

        LSelectionStringList = LSelectionList.Select(item => item.Split('.').Length > 1 ? item.Split('.')[1] : item).ToList();
        //对生成出的选项表提取其中词性.后面的翻译元素作为列表，以此用来后续判断答案是否正确
    }

    public void RemoveWord(int index) //默认的删除实现，不一定会用得上
    {
        WordList.RemoveAt(index);
    }

    public void ShowTestList()
    {
        foreach (var item in LSelectionList)
        {
            WriteLine(item);
        }

        foreach (var VARIABLE in LSelectionStringList)
        {
            WriteLine(VARIABLE);
        }
    }
    
    public static List<Word> GenerateTestList()
    {
        //生成测试列表
        Word w1 = new Word();
        Word w2 = new Word();
        Word w3 = new Word();
        Word w4 = new Word();
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
        List<Word> tW = new List<Word>();
        tW.Add(w1);
        tW.Add(w2);
        tW.Add(w3);
        tW.Add(w4);
            
        SelectionList sl = new SelectionList(tW);
        sl.ShowTestList();
        return tW;
    }
    
    public bool CheckAnswer(int answerIdx)//待测试
    {
        //检查答案是否正确
        if (LSelectionStringList[answerIdx] == WordList[0].translation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
