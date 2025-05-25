using DAL;
using IBLLBridgeDAL;
using IBLLBridgeDAL.WordOperation;

namespace BLL;

/// <summary>
///     单词选择器，实例化传入四个单词对象
/// </summary>
public class SelectionClass(IWord w1)
{
    /// <summary>
    ///     对将接口注入于选择器
    /// </summary>
    public static IWordManagement WordManagement { get; } = new WordManagement();

    /// <summary>
    ///     被设为正确答案的单词对象
    /// </summary>
    public IWord AccurateWord { get; private set; } = w1; //正确的单词

    /// <summary>
    ///     被作为选项的列表
    /// </summary>
    public List<IWord> Selection { get; private set; } = //一键洗好排序的选项列表
        ShuffleList
        (Enumerable
            .Range(0, 3)
            .Select(_ => WordManagement.GetRandomWordForReciter())
            .Append(w1)
            .ToList()
        );

    //打乱传入元素作为将被显示的对象的对象
    /// <summary>
    ///     用于打乱列表的洗牌算法,可以移出用于任何类型的列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputList"></param>
    /// <returns></returns>
    private static List<T> ShuffleList<T>(List<T> inputList) //洗牌算法
    {
        var random = new Random();
        for (var i = inputList.Count - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (inputList[i], inputList[j]) = (inputList[j], inputList[i]);
        }

        return inputList;
    }

    /// <summary>
    ///     用于将单词加入到复习列表
    /// </summary>

    public void AddWordToReViewList()//加入复习列表
    {
        WordManagement.AddWordToReview(AccurateWord);
    }
    public void ReflashSelection()//刷新选项
    {
        AccurateWord = RiciterOrder.WordList[RiciterOrder.Index];//刷新正确的单词
        Selection = ShuffleList(Enumerable.Range(0, 3).Select(_ => WordManagement.GetRandomWordForReciter()).Append(AccurateWord).ToList());//刷新选项
    }
}