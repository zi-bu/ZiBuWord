namespace IUIBridgeBLL;

//这里是复习器的对应接口 只是为了提高可读性做出区分而已
//因为基本逻辑完全一致 可以直接继承 对于IReciterTf所拥有的所有方法
//都可以直接使用
public interface IReviewer:IReciter
{
    void IfInsertToDal();
    
    //用于将已经复习积累了三次的单词插入到数据库中 未实现 只是做占位符
}