using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ReturnFunction
{
    /// <summary>
    ///  这是有关用户数据的类，里面分别包含注册登录两个函数<br/>
    ///  由***子布***编写<br/>
    ///</summary>
    public static class UserData
    {
        /// <summary>
        /// 注册函数。<br/>
        /// 需要传入用户名和密码<br/>
        /// 返回值为true说明注册成功<br/>
        /// 返回值为false说明注册失败<br/>
        /// </summary>
        /// <param name="NewUserName"></param>
        /// <param name="NewUserPassword"></param>
        public static bool Register(string NewUserName, string NewUserPassword)
        {
            using (var db = new Context.UserContext())
            {
                try
                {
                    var user = db.UserData.FirstOrDefault(u => u.UserName == NewUserName);
                    //使用LINQ查询数据库中的用户数据
                    if (user != null)
                    {
                        return false;
                    }
                    else
                    {
                        db.UserData.Add(new User() { UserName = NewUserName, UserPassword = NewUserPassword });
                        //添加新的用户数据
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
        /// <summary>
        /// 登录函数。<br/>
        /// 需要传入用户名和密码<br/>
        /// 此函数会检查用户名和密码是否正确<br/>
        /// 返回值为true说明登录成功<br/>
        /// 返回值为false说明登录失败<br/>
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        public static bool Login(string UserName, string UserPassword)
        {
            using (var db = new Context.UserContext())
            {
                try
                {
                    var user = db.UserData.FirstOrDefault(u => u.UserName == UserName && u.UserPassword == UserPassword);
                    //使用LINQ查询数据库中的用户数据
                    if (user != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
