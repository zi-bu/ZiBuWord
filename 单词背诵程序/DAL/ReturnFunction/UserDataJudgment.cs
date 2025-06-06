﻿using DAL.Context;
using IBLLBridgeDAL.UserManagement;



namespace DAL.ReturnFunction;

/// <summary>
///     这是有关用户数据的类，里面分别包含注册登录两个函数<br />
///     两个函数会对BLL层返回的内容进行判断<br />
///     由***子布***编写<br />
/// </summary>
public class UserDataJudgment : IUserRegisterService, IUserLoginService
{
    /// <summary>
    ///     这个函数会通过用户名来返回hash密码<br />
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public string ReturnUserPassword(string username)
    {
        using (var db = new UserContext())
        {
            try
            {
                //使用LINQ查询数据库中的用户数据(第一次匹配)
                var user = db.UserData.FirstOrDefault(u => u.UserName == username);
                if (user != null)
                {
                    return user.UserPassword; // 返回用户密码
                }
                return "用户不存在";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return "Error";
            }
        }
    }

    /// <summary>
    ///     检测用户名是否已经存在<br />
    ///     如果存在返回true<br />
    ///     如果不存在返回false<br />
    ///     报错时返回false冰抛出异常<br />
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public bool InspectUser(string username)
    {
        using (var db = new UserContext())
        {
            try
            {
                var user = db.UserData.FirstOrDefault(u => u.UserName == username);
                //使用LINQ查询数据库中的用户数据(第一次匹配)
                if (user != null) return true; // 用户名已存在

                return false; // 用户名可用
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }

    /// <summary>
    ///     创建一个新用户<br />
    ///     若果用户名已存在则抛出异常<br />
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <exception cref="Exception"></exception>
    public void CreateUser(string username, string password)
    {
        if (InspectUser(username) != true)
            using (var db = new UserContext())
            {
                try
                {
                    var user = new User
                    {
                        UserName = username,
                        UserPassword = password,
                        UserWord = new UserWord
                        {
                            MiddleSchool = 1,
                            HighSchool = 1,
                            KY = 1,
                            SAT = 1,
                            TF = 1,
                            CET4 = 1,
                            CET6 = 1,
                        }
                    };
                    db.UserData.Add(user);
                    //添加新的用户数据
                    db.SaveChanges(); //保存更改

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        else
            throw new Exception("用户名已存在");
    }

}