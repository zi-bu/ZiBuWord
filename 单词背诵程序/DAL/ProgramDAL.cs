
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
        using (Context.UserContext context = new Context.UserContext())
        {
            WordMover.AddReviewWord(UserDataMover.GetUserId("test"), "sound", WordMover.GetWordId("sound", Formid.CET4), Formid.CET4);
        }
    }
}