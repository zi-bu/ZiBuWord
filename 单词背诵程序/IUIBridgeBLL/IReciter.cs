

namespace IUIBridgeBLL
{
    //此处为背诵器的通用接口层，
    //取决于使用场景 请使用对应的其他派生接口实例化*
    public interface IReciter
    {
        void InitializeList();
        //实际使用时会考虑是否修改为构造函数
        //如果是 选择正确的意思 请当一个选意页面生成时便初始化
        //如果是 认识or不认识 请当一个背诵器【一轮循环】开始时进行初始化

        //What should InitializeList do?
        //1. Initialize the list of words.
        //2. Set correct answer.
        //3. Replace the text of label.
        /// <summary>
        /// 组长阅：
        /// 1.都是中国人说洋文干嘛。<br/>
        /// 2.都三层架构了，搞个全局的你要干什么？<br/>
        /// </summary>
        //  回答：测试一下看着好玩,练练英语，看看有没有退化.

        void ReleaseList();
        
        //如果是选意界面中，请每次选择意结束后用于释放列表
        //如果是 认识 or 不认识的选择中 请在一轮循环结束时使用它
        
        //What should ReleaseList do?
        //1. Release the list of words.
        //2. Remove the answer.
        //Q:When should ReleaseList be called?
        /*A:In the TF , When the user clicks the "Next" button, the list of words should be released.
            In the S, When the user choose the true Answer*/
    }
}