using System.Security.Cryptography;
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
        }
    }

    #endregion




}