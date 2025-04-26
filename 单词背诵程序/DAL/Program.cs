using Microsoft.Data.SqlClient;
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
            List<string> list = new List<string>();
            list = SqlReader.ReadSqlData("CET4-顺序");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static class SqlReader
        {
            ///<summary>
            /// 连接数据库与读取数据
            /// 这里代码是``子布``用来测试数据库连接的。
            ///</summary>

            public static string connectionString = "Server=10.151.196.28,1433; Database=背单词; User Id=sa; Password=114514; TrustServerCertificate=True;";

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
                    Console.WriteLine(reader["word"].ToString() + " " + reader["translations"].ToString());
                    list.Add(reader["word"].ToString());
                    list.Add(reader["translations"].ToString());
                }
                //将数据存入list中
                reader.Close();
                return list;
            }

            public class SqlWriter
            {
                public string word { get; set; }
                public string translations { get; set; }
            }
        }
    }
}
