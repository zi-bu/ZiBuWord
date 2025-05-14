using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using DAL.ReturnFunction;
using IBLLBridgeDAL;
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
            //Word word = new Word(1);
            //Console.WriteLine(word.word);
            
            //UserDataJudgment userDataJudgment = new UserDataJudgment();
            //string username = "testuser";
            //string password = "testpassword";
            //userDataJudgment.CreateUser(username, password);
            //Console.WriteLine("User created successfully.");

            WordManagement wordManager = new WordManagement();

            IWord word = wordManager.GetRandomWordForReciter();
            Console.WriteLine(word.word);
            Console.WriteLine("翻译:");
            for (int i = 0; i < word.pos.Count; i++)
            {
                Console.WriteLine(word.pos[i] + ". " + word.translations[i]);
            }
            Console.WriteLine("短语:");
            for (int i = 0; i < word.phrases.Count; i++)
            {
                Console.WriteLine(word.phrases[i] + " : " + word.phraseTranslations[i]);
            }
        }



























    }
}
