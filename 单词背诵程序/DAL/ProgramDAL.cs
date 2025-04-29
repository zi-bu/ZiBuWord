using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//注意这里引用的是Microsoft.Data.SqlClient而不是System.Data.SqlClient(高版本.NET框架已经迁移到Microsoft.Data.SqlClient)
namespace DAL
{
    /// <summary>
    /// 主程序类，用于测试数据库连接和数据操作。
    /// </summary>
    class ProgramDAL
    {
        /// <summary>
        /// 程序入口点，主要用于测试数据库连接和读取数据。
        /// </summary>
        static void Main(string[] args)
        {

            Word word = new Word(1);
            Console.WriteLine(word[0]);

        }
    }
    


   
   












    



  




   
}

