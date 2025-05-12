using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using DAL.ReturnFunction;
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
            Word word = new Word(1);
            Console.WriteLine(word.word);
            Console.WriteLine(word.translation);
            Console.WriteLine(word.phrase);
            //UserDataJudgment userDataJudgment = new UserDataJudgment();
            //string username = "testuser";
            //string password = "testpassword";
            //userDataJudgment.CreateUser(username, password);
            //Console.WriteLine("User created successfully.");
        }



























    }
}
