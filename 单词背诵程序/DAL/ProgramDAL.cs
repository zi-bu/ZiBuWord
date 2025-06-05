
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
        ReviewListManagement reviewListManagement = new ReviewListManagement();
        UserDataNow.NowUser = "mouse";
        Word word1 = (Word)reviewListManagement.GetRandomWordForReview();
        Word word2 = (Word)reviewListManagement.GetRandomWordForReview();
        Word word3 = (Word)reviewListManagement.GetRandomWordForReview();
        Console.WriteLine("Word: " + word1.word);
        Console.WriteLine("Word: " + word2.word);
        Console.WriteLine("Word: " + word3.word);
        
    }
}