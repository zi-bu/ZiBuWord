
//注意这里引用的是Microsoft.Data.SqlClient而不是System.Data.SqlClient(高版本.NET框架已经迁移到Microsoft.Data.SqlClient)
using DAL.ReturnFunction;
using Microsoft.EntityFrameworkCore;

namespace DAL;

/// <summary>
///     主程序类，用于测试数据库连接和数据操作。
/// </summary>
internal class ProgramDAL
{
    private static void Main(string[] args)
    {
        using(Context.UserContext context = new Context.UserContext())
        {
            var user = context.UserData;
            Console.WriteLine(user.First(f=>f.UserID==1).UserName);

            Console.WriteLine(user.Include(f=>f.UserWord).First(f=>f.UserID==1).UserWord.TF);

            int a =UserDataMover.GetFormProgress("test", Formid.CET4);
            Console.WriteLine(a);
        }
    }
}