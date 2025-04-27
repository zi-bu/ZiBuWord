using DAL;
using System.Linq;

namespace BLL
{
    /// <summary>
    /// 这是业务逻辑层，用于处理业务逻辑，与数据访问层进行交互。
    /// （已经引用了数据访问层的命名空间）
    /// 若要单独运行此项目，请右键运行旁边的齿轮图标更换为此项目。
    /// <br/>写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
    /// </summary>
    class test_area
    {
        /// <summary>
        /// 测试的东西可以放在main函数这里，也可以打断点进行测试。
        /// 写函数时可以像这么写注释。这样只用把鼠标放在函数上就能看到注释了。
        /// <br/>(我不会XML语言)
        /// </summary>

        static List<string> list = new List<string>();

        static void Main(string[] args)
        {
            list.Add("a1");
            list.Add("aa2");
            list.Add("aaa3");
            list.Add("b1");
            list.Add("bb2");
            list.Add("c1");
            var linq2 = from s in list
                        where s.Length > 2
                        select s;
            var printaa = from s in list
                          where s.Contains("a")
                          select s;
            Console.WriteLine();
            foreach (var item in linq2)
            {
                Console.WriteLine(item);
            }
            foreach (var item in printaa)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("LINQ可以用");
            Console.WriteLine("Hello, World!");
            Console.ReadKey();

            //这是子布测试调用
            List<string> list1 = new List<string>();
            list1 = OldSqlOperation.ReadSqlData("CET4-顺序");
            Console.WriteLine(list1[1]);
        }
    }

}
