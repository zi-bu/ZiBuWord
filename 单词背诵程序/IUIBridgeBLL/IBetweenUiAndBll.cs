

namespace IUIBridgeBLL
{
    public interface IBetweenUiAndBll
    {
        //void InitializeList(List<IWord> tempWordList);存在问题

        //What should InitializeList do?
        //1. Initialize the list of words.
        //2. Set correct answer.
        //3. Replace the text of label.
        /// <summary>
        /// 组长阅：
        /// 1.都是中国人说洋文干嘛。<br/>
        /// 2.都三层架构了，搞个全局的你要干什么？<br/>
        /// </summary>


        void ReleaseList();
        
        //What should ReleaseList do?
        //1. Release the list of words.
        //2. Remove the answer.
        //Q:When should ReleaseList be called?
        /*A:In the TF , When the user clicks the "Next" button, the list of words should be released.
            In the S, When the user choose the true Answer*/
    }
}