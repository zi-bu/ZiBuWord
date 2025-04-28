using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//注意这里引用的是Microsoft.Data.SqlClient而不是System.Data.SqlClient(高版本.NET框架已经迁移到Microsoft.Data.SqlClient)
namespace DAL
{
    /// <summary>
    /// 主程序类，用于测试数据库连接和数据操作。
    /// </summary>
    class Program
    {
        /// <summary>
        /// 程序入口点，主要用于测试数据库连接和读取数据。
        /// </summary>
        static void Main(string[] args)
        {
            #region "过时的测试代码"
            // 旧代码示例：通过 OldSqlOperation 读取数据。
            // List<string> list = new List<string>();
            // list = OldSqlOperation.ReadSqlData("考研-顺序");
            // foreach (var item in list)
            // {
            //     Console.WriteLine(item);
            // }
            #endregion

            // 使用 Entity Framework Core 连接数据库并读取数据。
            using (var db = new SqlDataContext()) // 创建数据库上下文。
            {
                var datas = db.考研.ToList(); // 从 考研 表中读取所有数据。
                foreach (var s in datas) // 遍历数据并输出到控制台。
                {
                    Console.WriteLine($"{s.word},{s.phrases},{s.translations}");
                }
            }
        }
    }
    /// <summary>
    /// 枚举类型，用于表示单词表的编号。
    /// 例如：考研 表示四级单词表，CET6 表示六级单词表。
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


    /// <summary>
    /// 单词对象的接口定义，规范单词对象的字段和访问方式。
    /// </summary>
    public interface IWord
    {
        string word { get; } // 单词
        string pos { get; } // 词性 (Part of Speech)
        string translation { get; } // 释义
        string phrase { get; } // 短语

        // 索引器：通过下标访问单词的不同属性。
        string this[int index] { get; }
    }


    /// <summary>
    /// 实现 IWord 接口的类，用于封装单词对象。
    /// </summary>
    public class Word : IWord
    {
        public string word { get; set; } // 单词
        public string pos { get; set; } // 词性
        public string translation { get; set; } // 释义
        public string phrase { get; set; } // 短语

        private formid tableid; // 单词来源的枚举编号。

        /// <summary>
        /// 构造函数：通过枚举编号指定单词来源。
        /// </summary>
        public Word(int id)
        {
            tableid = (formid)id;
        }

        /// <summary>
        /// 索引器：通过下标访问单词的不同属性。
        /// 例如：0 返回 word，1 返回 pos，依此类推。
        /// </summary>
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
                        return null; // 如果下标无效，返回 null。
                }
            }
        }
    }
    /// <summary>
    /// 单词搬运工类，计划封装查询单词和获取单词的方法（目前未实现）。
    /// </summary>
    internal class Wordmover
    {
        // 目前此类为空，未来可扩展为单词查询和操作的工具类。
    }













    /// <summary>
    /// 使用原生 ADO.NET 的类，用于直接操作数据库。
    /// 适合需要极致性能或兼容旧代码的场景，但已计划弃用。<br/>
    /// 这个库由```子布```书写完成，不要感谢他的贡献。
    /// </summary>
    public static class OldSqlOperation
    {
        /// <summary>
        /// 数据库连接字符串。
        /// 注意：不同网络环境下使用不同的服务器地址。
        /// </summary>
        public static string connectionString = "Server=10.162.28.183,1433; Database=背单词; User Id=sa; Password=114514; Encrypt=False;";

        /// <summary>
        /// 创建并打开一个 SqlConnection 对象。
        /// </summary>
        public static SqlConnection SqlConnection(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString); // 创建连接对象。
            try
            {
                connection.Open(); // 尝试打开连接。
                Console.WriteLine("连接成功！");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("连接失败：" + ex.Message); // 捕获连接失败的异常。
            }
            return connection;
        }

        /// <summary>
        /// 读取数据库中的数据。
        /// </summary>
        public static List<string> ReadSqlData(string name)
        {
            List<string> list = new List<string>(); // 用于存储读取的数据。
            SqlConnection connection = SqlConnection(name); // 获取数据库连接。
            SqlCommand command = new SqlCommand($"SELECT * FROM [dbo].[{name}] ORDER BY LEFT(word, 1) ASC;", connection); // 查询语句。
            SqlDataReader reader = command.ExecuteReader(); // 执行查询。
            while (reader.Read()) // 遍历查询结果。
            {
                list.Add(reader["word"].ToString()); // 添加单词。
                list.Add(reader["translations"].ToString()); // 添加释义。
                if (reader["phrase"] != null) // 如果短语不为空，添加短语。
                    list.Add(reader["phrase"].ToString());
            }
            reader.Close(); // 关闭读取器。
            return list;
        }
    }



    /// <summary>
    /// 数据库表 CET 的模型类。(类似于一个模版)
    /// 这个类对应数据库中的 考研 表，包含单词、释义和短语等字段。<br/>
    /// 这个类是由```子布```书写完成的，不要感谢他的贡献。
    /// </summary>
    public class CET
    {
        [Key] // 主键
        public int number { get; set; } // 单词编号
        [Required] // 必填字段
        public string? word { get; set; } // 单词
        public string? translations { get; set; } // 释义
        public string? phrases { get; set; } // 短语
    }




    /// <summary>
    /// 数据库上下文类，用于配置和操作数据库。
    /// 这个类使用 Entity Framework Core 进行数据库操作。<br/>
    /// 这个类是由```子布```书写完成的，不要感谢他的贡献。
    /// </summary>
    public class SqlDataContext : DbContext
    {
        /// <summary>
        /// 数据库表 CET 的 DbSet 属性。<br/>
        /// (传入一个模版)。
        /// </summary>
        public DbSet<CET> 考研 { get; set; } // 对应数据库中的 考研 表。

        /// <summary>
        /// 配置数据库连接。<br/>
        /// 此处不安全地暴露了数据库连接字符串，实际使用中应使用安全的配置方式。<br/>
        /// 在改了喵~在改了喵~<br/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.151.196.28,1433;Database=背单词;User Id=sa;Password=114514;Encrypt=False;");
        }

        /// <summary>
        /// 配置模型映射。<br/>
        /// 将数据库表映射到模型类。
        /// 虽然某些简单的映射可以通过默认约定完成，但复杂的场景（如自定义表名或关系）需要在 OnModelCreating 中显式配置。
        /// (貌似不写也能跑)？
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CET>().HasKey(c => c.number); // 配置主键。
        }
    }
}

