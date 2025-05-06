namespace IUIBridgeBLL;

public interface IReciterS :IReciter
{
    List<string> GetList();
    //获取展示列表
    
    bool CheckAnswer(string answer);
    //检查答案是否正确
    //返回值：true or false
    //这个怎么使用呢？
    //只需要再UI层的时候传入 Text 的参数应该就是可以了
    
    
    //按钮的Text文本的逻辑 是首先用IReciterS的接口实例化 一个对象
    //对象执行初始化方法InitalizeList();
    //当数据库内容做好之后我会对这个方法进行重载，参数表为空
    //可以利用这个正确和错误来确定来弹出选错了还是选对了的意思
    //用按钮调用这个函数即可
    
    bool IsTimeNext();
    //用于判断是否可以进入下一个选择 认识或者不认识的界面
    //每个按钮都可以调用，当条件符合真值时，
    //请你用它来跳转到下个页面（进入这次队列的认识或者不认识选择）
}
