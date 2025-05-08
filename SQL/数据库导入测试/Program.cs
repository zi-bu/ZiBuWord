using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace 数据库导入测试
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // 获取JSON文件夹路径
                string folderPath = "D:/杂/作业/c#小组项目/english-vocabulary-master/json";
                Console.WriteLine($"正在从文件夹导入JSON: {folderPath}");

                // 获取所有JSON文件
                var jsonFiles = Directory.GetFiles(folderPath, "*.json");
                Console.WriteLine($"找到 {jsonFiles.Length} 个JSON文件");

                if (jsonFiles.Length == 0)
                {
                    Console.WriteLine("未找到JSON文件");
                    return;
                }

                // 配置数据库连接
                string connectionString = "Server=127.0.0.1;Database=word;User Id=sa;Password=114514;Encrypt=False;";

                // 处理每个JSON文件
                foreach (var jsonFile in jsonFiles)
                {
                    // 从文件名获取表名
                    string fileName = Path.GetFileNameWithoutExtension(jsonFile);
                    string tableName = SanitizeTableName(fileName);

                    Console.WriteLine($"\n开始处理文件: {Path.GetFileName(jsonFile)}");
                    Console.WriteLine($"对应的表名: {tableName}");

                    // 读取并导入JSON文件到新表
                    await ImportJsonFileToNewTable(jsonFile, tableName, connectionString);
                }

                Console.WriteLine("\n所有文件处理完成!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序发生错误: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }

        // 为表名清理不合法字符
        private static string SanitizeTableName(string name)
        {
            // 移除不合法字符，仅保留字母、数字和下划线
            string sanitized = new string(name.Select(c => char.IsLetterOrDigit(c) || c == '_' ? c : '_').ToArray());

            // 确保不以数字开头
            if (char.IsDigit(sanitized[0]))
                sanitized = "Table_" + sanitized;

            return sanitized;
        }

        // 导入JSON文件到新表
        private static async Task ImportJsonFileToNewTable(string jsonFilePath, string tableName, string connectionString)
        {
            try
            {
                // 1. 读取并反序列化 JSON
                string json = await File.ReadAllTextAsync(jsonFilePath);
                var jsonWords = JsonSerializer.Deserialize<List<JsonWord>>(json);

                if (jsonWords == null || jsonWords.Count == 0)
                {
                    Console.WriteLine("  JSON 文件为空或格式不正确");
                    return;
                }

                Console.WriteLine($"  成功读取 {jsonWords.Count} 个单词条目");

                // 2. 创建数据库表结构
                await CreateTablesIfNotExist(tableName, connectionString);

                // 3. 连接数据库并导入数据
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 插入单词
                            foreach (var word in jsonWords)
                            {
                                // 插入单词主表
                                int wordId = await InsertWordAndGetId(connection, transaction, tableName, word.Word);

                                // 插入翻译
                                if (word.Translations?.Count > 0)
                                {
                                    foreach (var translation in word.Translations)
                                    {
                                        await InsertTranslation(connection, transaction, tableName, wordId,
                                            translation.Translation, string.IsNullOrEmpty(translation.Type) ? "未知" : translation.Type);
                                    }
                                }

                                // 插入短语
                                if (word.Phrases?.Count > 0)
                                {
                                    foreach (var phrase in word.Phrases)
                                    {
                                        await InsertPhrase(connection, transaction, tableName, wordId,
                                            phrase.Phrase, phrase.Translation);
                                    }
                                }
                            }

                            transaction.Commit();
                            Console.WriteLine($"  数据成功导入到表 {tableName}！");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"  数据导入失败: {ex.Message}");
                            if (ex.InnerException != null)
                            {
                                Console.WriteLine($"  内部异常: {ex.InnerException.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  处理文件时出错: {ex.Message}");
            }
        }

        // 创建表结构
        private static async Task CreateTablesIfNotExist(string tableName, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // 检查表是否存在
                string checkTableSql = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = @WordTableName)
                        BEGIN
                            CREATE TABLE [dbo].[" + tableName + @"_Words] (
                                [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                [Word] NVARCHAR(255) NOT NULL
                            );
                            
                            CREATE TABLE [dbo].[" + tableName + @"_Translations] (
                                [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                [WordId] INT NOT NULL,
                                [Translation] NVARCHAR(MAX) NOT NULL,
                                [Type] NVARCHAR(50) NOT NULL,
                                CONSTRAINT [FK_" + tableName + @"_Translations_Words] FOREIGN KEY ([WordId]) 
                                REFERENCES [dbo].[" + tableName + @"_Words] ([Id]) ON DELETE CASCADE
                            );
                            
                            CREATE TABLE [dbo].[" + tableName + @"_Phrases] (
                                [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                [WordId] INT NOT NULL,
                                [Phrase] NVARCHAR(MAX) NOT NULL,
                                [Translation] NVARCHAR(MAX) NOT NULL,
                                CONSTRAINT [FK_" + tableName + @"_Phrases_Words] FOREIGN KEY ([WordId]) 
                                REFERENCES [dbo].[" + tableName + @"_Words] ([Id]) ON DELETE CASCADE
                            );
                        END";

                using (var command = new SqlCommand(checkTableSql, connection))
                {
                    command.Parameters.AddWithValue("@WordTableName", tableName + "_Words");
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine($"  已确保表 {tableName}_Words、{tableName}_Translations 和 {tableName}_Phrases 存在");
                }
            }
        }

        // 插入单词并返回ID
        private static async Task<int> InsertWordAndGetId(SqlConnection connection, SqlTransaction transaction, string tableName, string word)
        {
            string insertSql = $"INSERT INTO [dbo].[{tableName}_Words] ([Word]) VALUES (@Word); SELECT SCOPE_IDENTITY();";

            using (var command = new SqlCommand(insertSql, connection, transaction))
            {
                command.Parameters.AddWithValue("@Word", word);
                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }

        // 插入翻译
        private static async Task InsertTranslation(SqlConnection connection, SqlTransaction transaction,
                                                 string tableName, int wordId, string translation, string type)
        {
            string insertSql = $"INSERT INTO [dbo].[{tableName}_Translations] ([WordId], [Translation], [Type]) VALUES (@WordId, @Translation, @Type)";

            using (var command = new SqlCommand(insertSql, connection, transaction))
            {
                command.Parameters.AddWithValue("@WordId", wordId);
                command.Parameters.AddWithValue("@Translation", translation);
                command.Parameters.AddWithValue("@Type", type);
                await command.ExecuteNonQueryAsync();
            }
        }

        // 插入短语
        private static async Task InsertPhrase(SqlConnection connection, SqlTransaction transaction,
                                            string tableName, int wordId, string phrase, string translation)
        {
            string insertSql = $"INSERT INTO [dbo].[{tableName}_Phrases] ([WordId], [Phrase], [Translation]) VALUES (@WordId, @Phrase, @Translation)";

            using (var command = new SqlCommand(insertSql, connection, transaction))
            {
                command.Parameters.AddWithValue("@WordId", wordId);
                command.Parameters.AddWithValue("@Phrase", phrase);
                command.Parameters.AddWithValue("@Translation", translation);
                await command.ExecuteNonQueryAsync();
            }
        }

        // JSON反序列化用的临时类
        public class JsonWord
        {
            [JsonPropertyName("word")]
            public required string Word { get; set; }

            [JsonPropertyName("translations")]
            public List<JsonTranslation> Translations { get; set; } = new();

            [JsonPropertyName("phrases")]
            public List<JsonPhrase> Phrases { get; set; } = new();
        }

        public class JsonTranslation
        {
            [JsonPropertyName("translation")]
            public required string Translation { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; } = "未知";  // 移除 required，设置默认值
        }

        public class JsonPhrase
        {
            [JsonPropertyName("phrase")]
            public required string Phrase { get; set; }

            [JsonPropertyName("translation")]
            public required string Translation { get; set; }
        }
    }
}

