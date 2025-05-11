using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ���ݿ⵼�����
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // ��ȡJSON�ļ���·��
                string folderPath = "D:/��/��ҵ/c#С����Ŀ/english-vocabulary-master/json";
                Console.WriteLine($"���ڴ��ļ��е���JSON: {folderPath}");

                // ��ȡ����JSON�ļ�
                var jsonFiles = Directory.GetFiles(folderPath, "*.json");
                Console.WriteLine($"�ҵ� {jsonFiles.Length} ��JSON�ļ�");

                if (jsonFiles.Length == 0)
                {
                    Console.WriteLine("δ�ҵ�JSON�ļ�");
                    return;
                }

                // �������ݿ�����
                string connectionString = "Server=127.0.0.1;Database=word1;User Id=sa;Password=114514;Encrypt=False;";

                // ����ÿ��JSON�ļ�
                foreach (var jsonFile in jsonFiles)
                {
                    // ���ļ�����ȡ����
                    string fileName = Path.GetFileNameWithoutExtension(jsonFile);
                    string tableName = SanitizeTableName(fileName);

                    Console.WriteLine($"\n��ʼ�����ļ�: {Path.GetFileName(jsonFile)}");
                    Console.WriteLine($"��Ӧ�ı���: {tableName}");

                    // ��ȡ������JSON�ļ����±�
                    await ImportJsonFileToNewTable(jsonFile, tableName, connectionString);
                    
                    // ��������ŵ����ʱ�
                    await AddRandomOrderToTable(tableName, connectionString);
                }

                Console.WriteLine("\n�����ļ��������!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"����������: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\n��������˳�...");
            Console.ReadKey();
        }

        // Ϊ���������Ϸ��ַ�
        private static string SanitizeTableName(string name)
        {
            // �Ƴ����Ϸ��ַ�����������ĸ�����ֺ��»���
            string sanitized = new string(name.Select(c => char.IsLetterOrDigit(c) || c == '_' ? c : '_').ToArray());

            // ȷ���������ֿ�ͷ
            if (char.IsDigit(sanitized[0]))
                sanitized = "Table_" + sanitized;

            return sanitized;
        }

        // ����JSON�ļ����±�
        private static async Task ImportJsonFileToNewTable(string jsonFilePath, string tableName, string connectionString)
        {
            try
            {
                // 1. ��ȡ�������л� JSON
                string json = await File.ReadAllTextAsync(jsonFilePath);
                var jsonWords = JsonSerializer.Deserialize<List<JsonWord>>(json);

                if (jsonWords == null || jsonWords.Count == 0)
                {
                    Console.WriteLine("  JSON �ļ�Ϊ�ջ��ʽ����ȷ");
                    return;
                }
                
                // �Ե����б����������
                Random random = new Random();
                jsonWords = jsonWords.OrderBy(x => random.Next()).ToList();
                
                Console.WriteLine($"  �ɹ���ȡ�������� {jsonWords.Count} ��������Ŀ");

                // 2. �������ݿ��ṹ
                await CreateTablesIfNotExist(tableName, connectionString);

                // 3. �������ݿⲢ��������
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // ���뵥��
                            foreach (var word in jsonWords)
                            {
                                // ���뵥������
                                int wordId = await InsertWordAndGetId(connection, transaction, tableName, word.Word);

                                // ���뷭��
                                if (word.Translations?.Count > 0)
                                {
                                    foreach (var translation in word.Translations)
                                    {
                                        await InsertTranslation(connection, transaction, tableName, wordId,
                                            translation.Translation, string.IsNullOrEmpty(translation.Type) ? "δ֪" : translation.Type);
                                    }
                                }

                                // �������
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
                            Console.WriteLine($"  ���ݳɹ����뵽�� {tableName}��");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"  ���ݵ���ʧ��: {ex.Message}");
                            if (ex.InnerException != null)
                            {
                                Console.WriteLine($"  �ڲ��쳣: {ex.InnerException.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  �����ļ�ʱ����: {ex.Message}");
            }
        }

        // ������ṹ
        private static async Task CreateTablesIfNotExist(string tableName, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // �����Ƿ����
                string checkTableSql = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = @WordTableName)
                        BEGIN
                            CREATE TABLE [dbo].[" + tableName + @"_Words] (
                                [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                [Word] NVARCHAR(255) NOT NULL,
                                [RandomOrder] INT NULL
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
                        END
                        ELSE
                        BEGIN
                            -- ����Ƿ����RandomOrder�У���������������
                            IF NOT EXISTS (SELECT * FROM sys.columns 
                                           WHERE object_id = OBJECT_ID('[dbo].[" + tableName + @"_Words]') 
                                           AND name = 'RandomOrder')
                            BEGIN
                                ALTER TABLE [dbo].[" + tableName + @"_Words] ADD [RandomOrder] INT NULL;
                            END
                        END";

                using (var command = new SqlCommand(checkTableSql, connection))
                {
                    command.Parameters.AddWithValue("@WordTableName", tableName + "_Words");
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine($"  ��ȷ���� {tableName}_Words��{tableName}_Translations �� {tableName}_Phrases ����");
                }
            }
        }

        // Ϊ���ʱ����������
        private static async Task AddRandomOrderToTable(string tableName, string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    
                    // ������е��ܼ�¼��
                    string countSql = $"SELECT COUNT(*) FROM [dbo].[{tableName}_Words]";
                    int totalCount = 0;
                    
                    using (var countCommand = new SqlCommand(countSql, connection))
                    {
                        totalCount = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
                    }
                    
                    if (totalCount == 0)
                    {
                        Console.WriteLine($"  �� {tableName}_Words ��û�м�¼����������������");
                        return;
                    }
                    
                    Console.WriteLine($"  ��ʼΪ {tableName}_Words ���е� {totalCount} ����¼����������");

                    // SQL Server������ʹ��ROW_NUMBER��NEWID()������������
                    string updateSql = $@"
                        WITH RandomCTE AS (
                            SELECT 
                                Id, 
                                ROW_NUMBER() OVER (ORDER BY NEWID()) AS RandomOrder
                            FROM [dbo].[{tableName}_Words]
                        )
                        UPDATE w
                        SET w.RandomOrder = r.RandomOrder
                        FROM [dbo].[{tableName}_Words] w
                        INNER JOIN RandomCTE r ON w.Id = r.Id";
                    
                    using (var command = new SqlCommand(updateSql, connection))
                    {
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        Console.WriteLine($"  �ѳɹ�Ϊ {rowsAffected} ����¼����������");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ����������ʱ����: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"  �ڲ��쳣: {ex.InnerException.Message}");
                }
            }
        }

        // ���뵥�ʲ�����ID
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

        // ���뷭��
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

        // �������
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

        // JSON�����л��õ���ʱ��
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
            public string Type { get; set; } = "δ֪";  // �Ƴ� required������Ĭ��ֵ
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
