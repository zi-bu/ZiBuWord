namespace IBLLBridgeDAL.UserManagement;

public interface IUserRegisterService //用户注册服务接口
{
    /// <summary>
    ///     创建一个新用户
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    void CreateUser(string username, string password);

    /// <summary>
    ///     检查用户名是否已经存在
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    bool InspectUser(string username);
}

public interface IUserLoginService //用户登录服务接口
{
    /// <summary>
    ///     检测一个用户密码是否正确
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    bool CheckUserPassword(string username, string password);
}