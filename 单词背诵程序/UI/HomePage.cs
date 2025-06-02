using MaterialSkin.Controls;
using MaterialSkin;
using BLL.HandleUserInput;
namespace UI;

public partial class HomePage : MaterialForm
{
    // 词典列表
    private readonly Dictionary<string, string> dictionaries = new()
    {
        { "四级词汇", "CET4" },
        { "六级词汇", "CET6" },
        { "初中词汇", "MiddleSchool" },
        { "高中词汇", "HighSchool" },
        { "考研词汇", "KY" },
        { "托福词汇", "TF" }
    };

    public HomePage()
    {
        InitializeComponent();
        FormClosing += FormHelper.CloseForm; // 绑定 FormClosing 事件

        // 初始化ComboBox
        InitializeDictionaryComboBox();
    }

    /// <summary>
    ///     获取当前选中的词典代码
    ///     mingfeng
    /// </summary>
    public string SelectedDictionaryCode
    {
        get
        {
            if (comboBoxSelectDict.SelectedItem != null &&
                dictionaries.TryGetValue(comboBoxSelectDict.SelectedItem.ToString(), out var code))
                return code;
            return "CET4"; // 默认返回四级词汇
        }
    }

    /// <summary>
    ///     初始化词典选择ComboBox
    ///     mingfeng
    /// </summary>
    private void InitializeDictionaryComboBox()
    {
        comboBoxSelectDict.DropDownStyle = ComboBoxStyle.DropDownList; // 设置为下拉列表，不可编辑
        comboBoxSelectDict.Items.Clear();

        // 添加词典名称到ComboBox
        foreach (var dict in dictionaries.Keys) comboBoxSelectDict.Items.Add(dict);

        // 默认选择第一个词典
        if (comboBoxSelectDict.Items.Count > 0) comboBoxSelectDict.SelectedIndex = 0;
    }

    /// <summary>
    ///     这是退出登录按钮的点击事件处理函数。
    ///     这段代码是由```子布```编写的。
    ///     (可能会被改写成一个函数，或者直接删除)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Exit(object sender, EventArgs e)
    {
        FormHelper.CloseForm(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("要返回登录界面吗", " 警告！",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            return;
        UserStateDeliver.RememberUser(null);//清空存储用户名的静态变量。
        var login = new Login();
        FormHelper.ShowNewForm(this, login);
    }

    private void btnFavorite_Click(object sender, EventArgs e)
    {
        var favorite = new Favorite();
        FormHelper.ShowNewForm(this, favorite);
    }

    private void btnStartMemory_Click(object sender, EventArgs e)
    {
        var memory = new UiSelectionOrder();
        FormHelper.ShowNewForm(this, memory);
    }

    private void btnStartReview_Click(object sender, EventArgs e)
    {
        var review = new Reviewer();
        FormHelper.ShowNewForm(this, review);
    }

    private void HomePage_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 当用户在下拉框选择词典时，触发事件传输数据到下层
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void comboBoxSelectDict_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserStateDeliver.DeliverDictionarySelect(SelectedDictionaryCode);//传递选表数据
        UserStateDeliver.ProgressSync(); // 同步进度信号
    }

    private void button1_Click(object sender, EventArgs e)
    {
        SearchWord searchWord = new SearchWord();
        searchWord.Show(); // 显示搜索单词窗口
        Hide(); // 隐藏当前窗口
    }

    private void test(object sender, EventArgs e)
    {
        Hide(); // 隐藏当前窗口  
        new 测试().Show(); // 显示测试窗口
    }
}