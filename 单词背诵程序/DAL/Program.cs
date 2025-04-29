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
            //using(var db = new SqlDataContext())
            //{
            //    var datas = db.考研.ToList(); // 从 考研 表中读取所有数据。
            //    foreach (var s in datas) // 遍历数据并输出到控制台。
            //    {
            //        Console.WriteLine($"{s.word},{s.phrases},{s.translations}");
            //    }
            //}
            Word word = new Word(1);
            Console.WriteLine(word[0]);

        }
    }
    


   
   












    



  




   
}

