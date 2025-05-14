using System.Text.RegularExpressions;
using DAL.ReturnFunction;

namespace BLL;

/// <summary>
///     这是有关用户数据的类，里面分别包含注册登录两个函数<br />
///     这个类由***子布***编写<br />
/// </summary>
public class UserData
{
    private readonly UserDataJudgment _userDataJudgment = new();

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
        if (_userDataJudgment.CheckUserPassword(username, password))
        {
            Console.WriteLine("登录成功");
            return 1; //登录成功
        }

        Console.WriteLine("登录失败");
        return 0; //登录失败(用户名不存在或密码错误)
    }

    /// <summary>
    ///     这是注册函数<br />
    ///     如果用户名和密码都匹配正则表达式、数据库中没有重名则返回1<br />
    ///     如果用户名已存在或者密码不匹配正则表达式则返回0<br />
    ///     抛出异常则返回-1<br />
    ///     密码正则表达式<br />
    ///     <code>"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$"</code>
    ///     用户名正则表达式<br />
    ///     <code>"^[a-zA-Z][a-zA-Z0-9_]{4,10}$"</code>
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public int UserRegister(string username, string password)
    {
        var patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]{8,20}$";
        //密码必须包含大小写字母和数字的组合，可以使用特殊字符，不能包含汉字和其他非ASCII字符，长度在8-20之间
        var patternUsername = @"^[a-zA-Z][a-zA-Z0-9_]{4,10}$";
        //用户名必须以字母开头，长度在5-11之间，只能包含字母、数字和下划线
        //可以去这个网站在线验证正则表达式"https://www.jyshare.com/front-end/854/"
        try
        {
            if (_userDataJudgment.InspectUser(username) == false && Regex.IsMatch(password, patternPassword) &&
                Regex.IsMatch(username, patternUsername))
            {
                _userDataJudgment.CreateUser(username, password);
                Console.WriteLine("注册成功");
                return 1; //注册成功
            }

            Console.WriteLine("注册失败");
            return 0; //注册失败
        }
        catch (Exception e)
        {
            Console.WriteLine("注册失败: " + e.Message);
            return -1; //注册失败（引发异常)
        }
    }
}