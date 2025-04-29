using DAL;

namespace BLL
{
    /// <summary>
    /// 这是业务逻辑层，用于处理业务逻辑，与数据访问层进行交互。
    /// （已经引用了数据访问层的命名空间）
    /// 若要单独运行此项目，请右键运行旁边的齿轮图标更换为此项目。
    /// <br/>写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
    /// </summary>

    #region ConsoleLogicTest

    class TestArea
    {
        /// <summary>
        /// 测试的东西可以放在main函数这里，也可以打断点进行测试。
        /// 写函数时可以像这么写注释。这样只用把鼠标放在函数上就能看到注释了。
        /// <br/>(我不会XML语言)
        /// </summary>
        static void Main(string[] args)
        {
        }
    }

    #endregion


    //以下内容待测试
    public interface IWordList
    {
        /// <summary>
        /// 实现单词队列的接口范式,抽象了单词列公有的行为
        /// </summary>
        List<Word> WordList { get; set; }
        public void RemoveWord(int index); //移除 也许 会改造为移至一个临时队列入库
    }


    public class ReactionList : IWordList//背诵列表
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
        public int CorrectlyMarked = 0;//规定 正确答案一定放在进入列表的第一位 其余三个为模糊项
        public List<Word> WordList { get; set; }
        public List<string> TempSelectionList { get; set; }

        

        //利用键值对，完成对正确选项的标记
        public SelectionList(List<Word> tempWordList) //构选意单元的方法
        {
            WordList = tempWordList.ToList();
            //临时列表进入
            TempSelectionList = new List<string>();
            //实例化选项临时列表
            TempSelectionList = WordList.Select(w => w.translation).ToList();
            //选项临时列表数据导入，Linq表达式调取临时对象w的translation属性
            //后续应该要改为 pos属性+translation属性才对

            //洗牌算法待完善 不能直接用List的Shuffle，这对原来的标记不存在记忆性s
        }
        
        public void RemoveWord(int index) //默认的删除实现，不一定会用得上
        {
            WordList.RemoveAt(index);
        }
        
        
    }
    //以上内容待测试
}