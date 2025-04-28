using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//注意这里引用的是Microsoft.Data.SqlClient而不是System.Data.SqlClient(高版本.NET框架已经迁移到Microsoft.Data.SqlClient)
namespace DAL
{
    /// <summary>
    /// 这是数据访问层，用于与数据库进行交互。
    /// 若要单独运行此项目，请右键运行旁边的齿轮图标更换为此项目。
    /// <br/>写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
    /// </summary>
    class Program
    {
        /// <summary>
        /// 测试的东西可以放在main函数这里，也可以打断点进行测试。
        /// 写函数时可以像这么写注释。这样只用把鼠标放在函数上就能看到注释了。
        /// <br/>(我不会XML语言)
        /// 此处代码是``子布``用来测试数据库连接的。
        /// </summary>
        static void Main(string[] args)
        {
            #region "过时的测试代码"
            //List<string> list = new List<string>();
            //list = OldSqlOperation.ReadSqlData("CET4-顺序");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            using (var db = new SqlDataContext())
            {
                var students = db.CET4.ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.word},{s.phrase},{s.translations}");
                }
            }
        }
    }
    /// <summary>
    /// mouse:枚举类型，用于表示单词表的编号,BLL层可来查表，不要修改
    /// </summary>

    public enum formid
    {
        CET4 = 1,
        CET6 = 2,
        初中 = 3,
        高中 = 4,
        考研 = 5,
        托福 = 6,
    }


    ///<summary>
    ///此处为咕所写的关于BLL层规范单词对象的接口范式
    ///可以随意修改，此为一种设想
    /// </summary>
    public interface IWord
    {
        //作为一个单词对象应被实现的字段包含以下  
        string word { get; } //单词  
        string pos { get; } //Part of Speech词性  
        string translation { get; } //释意  
        string phrase { get; } //短语  



        //定义一个单词的索引器  
        string this[int index] { get; }
        //希望单词能运用下标访问的语法 就是从0到4 一一对应返回上述的内容
        //而在上层BLL的时候，则会新建一个WordList列表 来存放单词对象 从而实现 WordList[0][1]的单词访问 
    }


    /// <summary>
    /// mouse:实现IWord接口,该类将封装一个按需求从数据库自动获取随机单词的类，用于逻辑层对数据库的单词操作
    /// mouse:目前就缺少调取功能，尚且不能使用
    /// </summary>
    public class Word : IWord
    {

        public string word { get; set; }
        public string pos { get; set; }
        public string translation { get; set; }
        public string phrase { get; set; }

        private formid tableid; //枚举编号，表示单词来自哪个词典
        /// <summary>
        /// mouse:内部采用枚举来表示单词来源，外部调用时传入对应枚举的数值即可
        /// </summary>
        /// <param name="id"></param>
        public Word(int id)
        {
            tableid = (formid)id;
        }


        /// <summary>
        /// mouse:索引器，0-3对应word、pos、translations、phrase
        /// mouse:有需求可改为1-4
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return word;
                    case 1:
                        return pos;
                    case 2:
                        return translation;
                    case 3:
                        return phrase;
                    default:
                        return null;
                }
            }
        }
    }
    /// <summary>
    /// mouse:单词搬运工，将封装查询单词，获取单词的方法等
    /// </summary>
    internal class Wordmover
    {

    }













    ///<summary>
    /// 连接数据库与读取数据
    /// 这里代码是``子布``用来测试数据库连接的。
    /// 这里直接使用了原生ADO.NET的SqlClient来连接数据库。<br/>
    /// 适用场景：需要极致性能、完全控制底层细节，或需要兼容旧代码。<br/>
    ///优势：<br/>
    ///直接通过DbConnection、DbCommand等类操作数据库。<br/>
    ///无额外依赖，适合小型项目或工具类程序。<br/>
    ///需要手动管理连接和命令对象。<br/>
    ///准备弃用
    ///</summary>
    public static class OldSqlOperation
    {
        /// <summary>
        /// 用于连接数据库的字符串。<br/>
        /// Server=10.151.196.28,1433;这是在寝室用有线网时的服务器地址。<br/>
        /// Server=10.162.28.183,1433;这是在自习教室用无线网时的服务器地址。
        /// </summary>
        public static string connectionString = "Server=10.162.28.183,1433; Database=背单词; User Id=sa; Password=114514; Encrypt=False;";

        /// <summary>
        /// 创建一个SqlConnection对象
        ///<br/>并连接数据库。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlConnection SqlConnection(string name)
        {
            //禁用了SSL证书验证（注意！）
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("连接成功！");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("连接失败：" + ex.Message);
            }
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("连接已打开！");
            }
            else
            {
                Console.WriteLine("连接未成功打开！");
            }
            return connection;
        }

        /// <summary>
        /// 读取数据库中的数据<br/>
        /// "name"是表名
        /// </summary>
        /// <param name="name"></param>
        public static List<string> ReadSqlData(string name)
        {
            List<string> list = new List<string>();
            SqlConnection connection = SqlConnection(name);
            //禁用了SSL证书验证（注意！）
            SqlCommand command = new SqlCommand($"SELECT * FROM [dbo].[{name}] ORDER BY LEFT(word, 1) ASC;", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["word"].ToString());
                list.Add(reader["translations"].ToString());
                if (reader["phrase"] != null)
                    list.Add(reader["phrase"].ToString());
            }
            //将数据存入list中
            reader.Close();
            return list;
        }
    }
    public class CET
    {
        [Key]
        public int number { get; set; }
        [Required]
        public string? word { get; set; }
        public string? translations { get; set; }
        public string? phrase { get; set; }
    }

    public class SqlDataContext : DbContext
    {
        // 对应数据库中的 CET 表
        public DbSet<CET> CET4 { get; set; }

        // 配置连接 SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 连接字符串（直接硬编码，实际项目建议放到配置文件中）
            optionsBuilder.UseSqlServer("Server=10.151.196.28,1433;Database=背单词;User Id=sa;Password=114514;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CET>().HasKey(c => c.number); // 假设 word 是唯一的
        }

    }

}

