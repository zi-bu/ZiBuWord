using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
//注意这里引用的是Microsoft.Data.SqlClient而不是System.Data.SqlClient(高版本.NET框架已经迁移到Microsoft.Data.SqlClient)
namespace DAL
{
    /// <summary>
    /// 主程序类，用于测试数据库连接和数据操作。
    /// </summary>
    class ProgramDAL
    {
        static void Main(string[] args)
        {
            using (var db = new SqlDataContext())
            {
                var datas = db.CET4.ToList(); // 从 CET4 表中读取所有数据。
                foreach (var s in datas) // 遍历数据并输出到控制台。
                {
                    try
                    {
                        // 将 phrases 字段的 JSON 转换为 List<Dictionary<string, object>>
                        var phrasesList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(s.phrases);

                        Console.WriteLine($"Word: {s.word}");
                        foreach (var phrase in phrasesList)
                        {
                            foreach (var keyValue in phrase)
                            {
                                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
                            }
                        }
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"JSON 解析失败: {ex.Message}");
                    }
                }
            }
        }
    }



























}

