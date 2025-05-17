using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;

namespace DAL.ReturnFunction
{
    public class UserWordAdd
    {
        public void AddUserWord(int userid) 
        {
            using(var db = new UserContext())
            {
                var userWord = new UserWord
                {
                    UserID = userid,
                    MiddleSchool = 1,
                    HighSchool= 1,
                    KY = 1,
                    SAT = 1,
                    TF = 1,
                    CET4 = 1,
                    CET6 = 1,
                };
                db.UserWord.Add(userWord);
                db.SaveChanges();
            }
        }
    }
}
