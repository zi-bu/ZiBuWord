namespace IUIBridgeBLL
{
    //此处为背诵器的通用接口层，
    //取决于使用场景 请使用对应的其他派生接口实例化*
    public interface IReciter
    {
        //如何初始化？请使用IReciter派生类 ReciterS等等自身的构造函数
        //请在创建实例时不要使用IReciter类型
        void ReleaseList();//用于释放列表的函数
        //如果是选意界面中，请每次选择意结束后用于释放列表
        //如果是 认识 or 不认识的选择中 请在一轮循环结束时使用它
    }
}