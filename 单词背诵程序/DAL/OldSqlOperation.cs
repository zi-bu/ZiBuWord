namespace DAL;
#if HHHH
        [Obsolete("mouse:旧的类，已被zibu弃用", true)]
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
        public static string connectionString =
 "Server=10.162.28.183,1433; Database=背单词; User Id=sa; Password=114514; Encrypt=False;";

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
            SqlCommand command =
 new SqlCommand($"SELECT * FROM [dbo].[{name}] ORDER BY LEFT(word, 1) ASC;", connection); // 查询语句。
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
#endif