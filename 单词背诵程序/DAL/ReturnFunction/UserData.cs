using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReturnFunction
{
    public static class UserData
    {
        public static void Register(string NewUserName,string NewUserPassword)
        {
            using(var db = new Context.UserContext())
            {
                db.UserData.Add(new User() {UserName=NewUserName,UserPassword=NewUserPassword});
                db.SaveChanges();
            }
        }
        public static void Login(string UserName, string UserPassword)
        {
            using (var db = new Context.UserContext())
            {
                var user = db.UserData.FirstOrDefault(u => u.UserName == UserName && u.UserPassword == UserPassword);
                if (user != null)
                {
                    Console.WriteLine($"Welcome back, {user.UserName}!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
        }
    }
}
