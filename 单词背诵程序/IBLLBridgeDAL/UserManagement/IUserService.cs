namespace IBLLBridgeDAL.UserManagement;

public interface IUserService//用户服务接口
{
    void CreateUser(string username, string password);//创建一个新用户
    bool InspectUser(string username);//检测一个用户是否存在
    bool InspectUser(string username, string password);//检测一个已经存在的用户密码是否正确
}