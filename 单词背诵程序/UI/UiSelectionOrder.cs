using BLL;

namespace UI;

public partial class UiSelectionOrder : Form
{
    private SelectionOrder _selectionOrder;

    public UiSelectionOrder()
    {
        _selectionOrder = new SelectionOrder(RiciteOrder.WordList[RiciteOrder.Index]);
        //选择器内容首次初始化
        InitializeComponent();
    }

    // 函数封装的区域
    private void RenderThePage() //渲染页面的函数 封装为函数便于后面调用
    {
        Question.Text = _selectionOrder.AccurateWord.word;
        //对正确答案对应的单词进行初始化
        Button[] choices = [Choice1, Choice2, Choice3, Choice4];
        for (var i = 0; i < choices.Length; i++)
            choices[i].Text = $@"{_selectionOrder.Selection[i].pos},{_selectionOrder.Selection[i].translations}";
        //利用循环对按钮初始化
    }

    private void ReRenderThePage() //完成一次选择后对单词进行重新刷新
    {
        _selectionOrder = new SelectionOrder(RiciteOrder.WordList[RiciteOrder.Index]);
        RenderThePage();
    }

    private void SelectionOrder_Load(object sender, EventArgs e) //加载时渲染页面
    {
        RenderThePage();
    }

    //按钮的判断逻辑
    private void ButtonJudge(int sequence)
    {
        if (_selectionOrder.AccurateWord == _selectionOrder.Selection[sequence])
        {
            //选对了的情况
            MessageBox.Show(@"选对了，真棒！");
            RiciteOrder.Index++; //趋势递增
            if (!(RiciteOrder.Index < RiciteOrder.WordList.Count)) //序列索引回拨
                RiciteOrder.Index = 0;
            _selectionOrder.AddWordToReViewList(); //将当前的单词加入到复习列表
            RiciteOrder.WordList.RemoveAt(RiciteOrder.Index); //将当前序列的内容移出列表
            _selectionOrder.DeleteWordFromLearningList();//将当前的单词移出学习列表
            if (RiciteOrder.WordList.Count == 0) //检验是否完成当前队列的背诵
            {
                MessageBox.Show(@"背诵队列完成,即将关闭该界面");
                RiciteOrder.Index = 0; //回拨索引
                RiciteOrder.CreateOrRefreshNewWordList(); //创建新的列表
                Close(); //关闭当前窗口
            }
        }
        else
        {
            //选错了的情况
            RiciteOrder.Index++; //趋势递增
            if (!(RiciteOrder.Index < RiciteOrder.WordList.Count)) //序列索引回拨
                RiciteOrder.Index = 0;
            MessageBox.Show(@"选错了嘞，之后再试试吧");
        }

        ReRenderThePage();
    }


    //选项区域

    private void Choice1_Click(object sender, EventArgs e)
    {
        ButtonJudge(0);
    }

    private void Choice2_Click_1(object sender, EventArgs e)
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
}