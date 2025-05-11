namespace IBLLBridgeDAL.UserManagement;

public interface IUserRegisterService//用户注册服务接口
{
    void CreateUser(string username, string password);//创建一个新用户
    bool InspectUser(string username);//检测一个用户是否存在
}
public interface IUserLoginService//用户注册服务接口
{
    bool CheckUserPassword(string username,string password);//检测一个用户密码是否正确
}