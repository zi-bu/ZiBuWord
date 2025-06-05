using BLL;
using MaterialSkin.Controls;

namespace UI;

public partial class Reviewer : MaterialForm
{
    private ReviewClass _reviewer;

    public Reviewer() //构造函数，该页面对内容进行初始化
    {
        InitializeComponent();
        FormClosing += FormHelper.CloseForm;//绑定关闭事件
        _reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
        Question.Text = _reviewer.Word.word;
    }

    // 函数封装的区域
    private void ShowInfoOfWord() //显示单词其余信息
    {
        Context.Text = _reviewer.OutPutWordInfo();
    }

    private void HandleButtonClick(bool remove) //按钮事件出发的逻辑函数
    {
        ShowInfoOfWord(); //展示其他信息
        if (remove)
        {
            _reviewer.RemoveWordReviewList(); //如果是认识的将会执行下面的内容，移出复习列表
            if (ReviewOrder.CheckOutWordList()) //做复习完成检验
            {
                MessageBox.Show(@"已完成当前的复习列表"); //返回结果
                Close(); //完成时关闭
                new HomePage().Show(); //打开主页
            }

            ReviewOrder.ResetIndex(); //对于选择认识时的下标回拨检验
            _reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
            Question.Text = _reviewer.Word.word;
        }
        else
        {
            ReviewOrder.ResetIndex(); //下标回拨检验，如果不认识则提前返回
            _reviewer = new ReviewClass(ReviewOrder.WordList[ReviewOrder.Index]);
            Question.Text = _reviewer.Word.word;
        }
    }

    //组件事件
    private void ButtonYes_Click(object sender, EventArgs e)
    {
        HandleButtonClick(true);
    }

    private void ButtonNo_Click(object sender, EventArgs e)
    {
        HandleButtonClick(false);
    }

    private void Context_TextChanged(object sender, EventArgs e)
    {

    }

    private void materialButton1_Click(object sender, EventArgs e)
    {
        FormHelper.ShowNewForm(this, Program.homePage);
    }
}