using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

public class ReviewClass(IWord w1)
{
    public static IReviewListManagement 接口实现占位 { get; }//接口注入
    public IWord Word { get; } = w1;//用于背诵的单词对象导入

    public void RemoveWordReviewList()
    {
        接口实现占位.RemoveWordFromReview(Word);
    }
    
    public string OutPutWordInfo()//输出单词其他信息
    {
        return typeof(IWord)//获取类型元数据(用于获取单词的属性)
            .GetProperties()//获取反射类型中的所有的属性，得到一个PropertyInfo数组
            .Select(p => //在这个数组中遍历每一个属性
                p.GetValue(Word)?//获取属性的值         <-对象在这里被输入
                    .ToString() ?? string.Empty)//转换成字符串
            .Aggregate((a, b) => a + Environment.NewLine + b);//将字符串合并
    }
    
    
}