using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                var datas = db.托福.ToList(); // 从 托福？CET4（√） 表中读取所有数据。
                foreach (var s in datas) // 遍历数据并输出到控制台。
                {
                    try
                    {
                        string fixedJson = s.phrases
                        .Replace("'", "\"") // 替换单引号为双引号
                        .Replace(",}", "}") // 移除多余的逗号
                        .Replace(",]", "]"); // 移除多余的逗号

                        var options = new JsonSerializerOptions
                        {
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // 忽略空值
                        };

                        var phrasesList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(fixedJson, options);
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

