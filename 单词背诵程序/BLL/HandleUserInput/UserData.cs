using System.Text.RegularExpressions;
using DAL.ReturnFunction;

namespace BLL.HandleUserInput;

/// <summary>
///     这是有关用户数据的类，里面分别包含注册登录两个函数<br />
///     这个类由***子布***编写<br />
///     我怀疑有人直接用IDE的重构功能把我写的代码改了<br />
///     坏了，吃语法糖吃死了<br />
/// </summary>
public class UserData
{
    private readonly UserDataJudgment _userDataJudgment = new();

    /// <summary>
    /// 这是一个函数，会对密码进行哈希处理<br />
    /// 返回一个哈希处理过的密码<br />
    /// </summary>
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        ///使用BCrypt.Net库进行密码哈希处理
    }

    /// <summary>
    /// 这是一个函数，会对哈希处理过的密码进行验证<br />
    /// 返回一个bool值来表示密码是否匹配<br />
    /// </summary>
    private bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }

    /// <summary>
    ///     这是登录函数<br />
    ///     如果用户名和密码正确则返回1<br />
    ///     如果用户名不存在或者密码错误则返回0<br />
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public int UserLogin(string username, string password)
    {
        try
        {
            // 首先检查用户是否存在
            if (_userDataJudgment.InspectUser(username))
            {
                // 用户存在，验证密码
                string hashedPassword = _userDataJudgment.ReturnUserPassword(username);
                if (VerifyPassword(password, hashedPassword))
                {
                    Console.WriteLine("登录成功");
                    return 1; // 登录成功
                }
                else
                {
                    // 为安全起见，不应该明确指出密码错误
                    Console.WriteLine("用户名或密码错误");
                    return 0; // 登录失败（密码错误）
                }
            }
            else
            {
                // 为安全起见，不应该明确指出用户不存在
                Console.WriteLine("用户名或密码错误");
                return 0; // 登录失败（用户不存在）
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("登录失败: " + e.Message);
            return -1; // 登录失败（引发异常）
        }
    }

    /// <summary>
    ///     这是注册函数<br />
    ///     如果用户名和密码都匹配正则表达式、数据库中没有重名则返回1<br />
    ///     如果用户名已存在则返回10<br/>若密码不匹配正则表达式则返回11<br />
    ///     抛出异常则返回-1<br />
    ///     用户名正则表达式<br />
    ///     <code>"^[a-zA-Z][a-zA-Z0-9_]{4,10}$"</code>
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public int UserRegister(string username, string password)
    {
        try
        {
            if (_userDataJudgment.InspectUser(username) == false)
            //用户名不存在
            {
                    _userDataJudgment.CreateUser(username, HashPassword(password));
                    Console.WriteLine("注册成功");
                    return 1; //注册成功
            }
            else
            {
                Console.WriteLine("用户名已存在");
                return 10; //注册失败（用户名已存在）
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("注册失败: " + e.Message);
            return -1; //注册失败（引发异常)
        }
    }
}