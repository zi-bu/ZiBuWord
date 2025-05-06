using GlobalIterface;

namespace IUIBridgeBLL
{
    public interface IBetweenUiAndBll
    {
        void InitializeList(List<IWord> tempWordList);
       
        //What should InitializeList do?
        //1. Initialize the list of words.
        //2. Set correct answer.
        //3. Replace the text of label.

        
        void ReleaseList();
        
        //What should ReleaseList do?
        //1. Release the list of words.
        //2. Remove the answer.
        //Q:When should ReleaseList be called?
        /*A:In the TF , When the user clicks the "Next" button, the list of words should be released.
            In the S, When the user choose the true Answer*/
    }
}