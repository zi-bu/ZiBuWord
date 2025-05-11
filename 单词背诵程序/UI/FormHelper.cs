using System;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// 窗体辅助类，提供窗体操作的通用方法
    /// mingfeng
    /// </summary>
    public static class FormHelper
    {
        /// <summary>
        /// 显示新窗口并隐藏当前窗口
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
        /// 这是关闭窗口的事件处理函数。
        /// </br>这段代码是由```子布```编写的。
        /// （可能会被改写成一个函数，或者直接删除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要退出吗？未保存的进度将会丢失！", "警告！", MessageBoxButtons.YesNo
                , MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true; // 取消关闭事件
            }
            else
            {
                System.Environment.Exit(0); // 退出程序
            }
        }
    }
} 