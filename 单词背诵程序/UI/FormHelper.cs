namespace UI;

/// <summary>
///     窗体辅助类，提供窗体操作的通用方法
///     mingfeng
/// </summary>
public static class FormHelper
{
    /// <summary>
    ///     显示新窗口并隐藏当前窗口
    /// </summary>
    /// <param name="currentForm">当前窗口</param>
    /// <param name="newForm">要显示的新窗口</param>
    public static void ShowNewForm(Form currentForm, Form newForm)
    {
        newForm.StartPosition = FormStartPosition.Manual;
        newForm.Location = currentForm.Location;
        newForm.Show();
        currentForm.Hide();
    }
    /// <summary>
    /// 显示主页面并关闭当前窗口
    /// </summary>
    /// <param name="currentForm"></param>
    /// <param name="newForm"></param>
    public static void ShowForm(Form currentForm, HomePage homePage)
    {
        homePage.Show();
        currentForm.Close();
    }
    /// <summary>
    ///     处理窗体关闭事件，显示确认对话框并决定是否退出程序
    /// </summary>
    /// <param name="sender">事件源对象</param>
    /// <param name="e">包含事件数据的FormClosingEventArgs</param>
    public static void CloseForm(object sender, FormClosingEventArgs e)
    {
        // 检查关闭原因，避免重复提示（如用户点击标题栏关闭按钮或Alt+F4）
        if (e.CloseReason == CloseReason.UserClosing)
        {
            var result = MessageBox.Show(
                "真的要退出吗？未保存的进度将会丢失！",
                "警告！",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            e.Cancel = result == DialogResult.No;

            // 只在用户明确选择"是"时才退出
            if (!e.Cancel) Application.Exit(); // 统一退出整个应用
        }
    }
    /// <summary>
    /// 返回主页面，包装起来绑定关闭事件用的
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void ReturnHomepage(object sender, FormClosingEventArgs e)
    {
        Program.homePage.Show();
    }
}