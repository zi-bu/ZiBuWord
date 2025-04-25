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
            string connectionString = "Server=10.151.196.28,1433; Database=背单词; User Id=sa; Password=114514; TrustServerCertificate=True;";
            //禁用了SSL证书验证（注意！）
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
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
                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[CET4-顺序]", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["word"].ToString() + " " + reader["translations"].ToString());
                }
                reader.Close();
            }
        }
    }
}
