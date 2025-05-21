using BLL;
using MaterialSkin.Controls;

namespace UI;

public partial class UiSelectionOrder : MaterialForm
{
    private SelectionClass _selectionClass;

    public UiSelectionOrder()
    {
        _selectionClass = new SelectionClass(RiciterOrder.WordList[RiciterOrder.Index]);
        //选择器内容首次初始化
        InitializeComponent();
    }

    // 函数封装的区域
    private void RenderThePage() //渲染页面的函数 封装为函数便于后面调用
    {
        Question.Text = _selectionClass.AccurateWord.word;
        //对正确答案对应的单词进行初始化
        Button[] choices = [Choice1, Choice2, Choice3, Choice4];
        for (var i = 0; i < choices.Length; i++)
            choices[i].Text = $@"{_selectionClass.Selection[i].pos[0]},{_selectionClass.Selection[i].translations[0]}";
        //利用循环对按钮初始化
    }

    private void ReRenderThePage() //完成一次选择后对单词进行重新刷新
    {
        if (RiciterOrder.WordList.Count == 0)
        {
            MessageBox.Show(@"单词列表为空，无法刷新页面");
            Close();
            return;
        }

        if (RiciterOrder.Index >= RiciterOrder.WordList.Count)
            RiciterOrder.Index = 0;
        _selectionClass = new SelectionClass(RiciterOrder.WordList[RiciterOrder.Index]);
        RenderThePage();
    }

    private void SelectionOrder_Load(object sender, EventArgs e) //加载时渲染页面
    {
        RenderThePage();
    }

    //按钮的判断逻辑
    private void ButtonJudge(int sequence)
    {
        if (_selectionClass.AccurateWord == _selectionClass.Selection[sequence])
        {
            //选对了的情况
            MessageBox.Show(@"选对了，真棒！");
            RiciterOrder.Index++; //趋势递增
            if (!(RiciterOrder.Index < RiciterOrder.WordList.Count)) //序列索引回拨
                RiciterOrder.Index = 0;
            _selectionClass.AddWordToReViewList(); //将当前的单词加入到复习列表
            RiciterOrder.WordList.RemoveAt(RiciterOrder.Index); //将当前序列的内容移出列表
            _selectionClass.DeleteWordFromLearningList(); //将当前的单词移出学习列表
            if (RiciterOrder.WordList.Count == 0) //检验是否完成当前队列的背诵
            {
                MessageBox.Show(@"背诵队列完成,即将关闭该界面");
                RiciterOrder.Index = 0; //回拨索引
                RiciterOrder.CreateOrRefreshNewWordList(); //创建新的列表
                Close(); //关闭当前窗口
            }
        }
        else
        {
            //选错了的情况
            RiciterOrder.Index++; //趋势递增
            if (!(RiciterOrder.Index < RiciterOrder.WordList.Count)) //序列索引回拨
                RiciterOrder.Index = 0;
            MessageBox.Show(@"选错了嘞，之后再试试吧");
        }

        ReRenderThePage();
    }


    //选项区域

    private void Choice1_Click(object sender, EventArgs e)
    {
        ButtonJudge(0);
    }

    private void Choice2_Click(object sender, EventArgs e)
    {
        ButtonJudge(1);
    }

    private void Choice3_Click(object sender, EventArgs e)
    {
        ButtonJudge(2);
    }

    private void Choice4_Click(object sender, EventArgs e)
    {
        ButtonJudge(3);
    }

    private void GoHome_Click(object sender, EventArgs e)
    {
        HomePage homePage = new HomePage(); //创建一个新的主页窗口对象
        FormHelper.ShowNewForm(this, homePage); //显示新窗口
        Close(); //关闭当前窗口
    }
}